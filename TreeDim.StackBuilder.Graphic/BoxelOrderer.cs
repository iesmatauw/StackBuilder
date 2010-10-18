using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Graphics
{
    internal class BoxComparerZ : IComparer<Box>
    {
        #region IComparer<Box> implementation
        public int Compare(Box b1, Box b2)
        {
            if (b1.Center.Z > b2.Center.Z)
                return 1;
            else if (b1.Center.Z == b2.Center.Z)
                return 0;
            else
                return -1;
        }
        #endregion
    }
    internal class BoxComparerXMin : IComparer<Box>
    {
        #region IComparer<Box> implementation
        public int Compare(Box b1, Box b2)
        {
            if (b1.XMin > b2.XMin)
                return 1;
            else if (b1.XMin == b2.XMin)
                return 0;
            else
                return -1;
        }
        #endregion
    }

    public class BoxelOrderer
    {
        #region Data members
        private List<Box> _boxes = new List<Box>();
        private static readonly double _epsilon = 0.0001;
        #endregion

        public void Add(Box b)
        { _boxes.Add(b); }

        public List<Box> GetSortedList()
        {
            // first sort by Z
            BoxComparerZ boxComparer = new BoxComparerZ();
            _boxes.Sort(boxComparer);


            List<Box> _sortedList = new List<Box>();
            if (_boxes.Count == 0)
                return _sortedList;

            // build same Z layers
            int index = 0;
            double zCurrent = _boxes[index].Center.Z;
            List<Box> tempList = new List<Box>();
            while (index < _boxes.Count)
            {
                if (Math.Abs(zCurrent - _boxes[index].Center.Z) < _epsilon)
                    tempList.Add(_boxes[index]);
                else
                {
                    // sort layer
                    SortLayer(ref tempList);
                    // add to sorted list
                    _sortedList.AddRange(tempList);
                    // start new layer
                    zCurrent = _boxes[index].Center.Z;
                    tempList.Clear();
                    tempList.Add(_boxes[index]);
                }
                ++index;
            }
            // processing last layer
            SortLayer(ref tempList);
            _sortedList.AddRange(tempList);

            return _sortedList;
        }

        private void SortLayer(ref List<Box> layerList)
        { 
            // build y list
            List<double> yList = new List<double>();
            foreach (Box b in layerList)
            {
                if (!yList.Contains(b.YMin)) yList.Add(b.YMin);
                if (!yList.Contains(b.YMax)) yList.Add(b.YMax);
            }
            yList.Sort();

            List<Box> treeList = new List<Box>();
            List<Box> resList = new List<Box>();
            // sweep stage
            foreach (double y in yList)
            {
                // clean treelist
                CleanByYMax(treeList, y);

                // add new 
                List<Box> listYMin = GetByYMin(layerList, y);

                foreach (Box by in listYMin)
                {
                    treeList.Add(by);
                    treeList.Sort(new BoxComparerXMin());
                    // find successor of by
                    int id = treeList.FindIndex(delegate(Box b) { return b.PickId == by.PickId; });
                    Box successor = null;
                    if (id < treeList.Count - 1)
                        successor = treeList[id + 1];

                    // insert by
                    if (null == successor)
                        resList.Add(by);
                    else
                    {
                        int idBefore = resList.FindIndex(delegate(Box b) { return b.PickId == successor.PickId; });
                        resList.Insert(idBefore, by);
                    }
                }
            }

            layerList.Clear();
            resList.Reverse();
            layerList.AddRange(resList);
        }

        private List<Box> GetByYMin(List<Box> inList, double y)
        {
            List<Box> outList = new List<Box>();
            foreach (Box b in inList)
                if (Math.Abs(b.YMin - y) < _epsilon)
                    outList.Add(b);
            return outList;
        }

        private void CleanByYMax(List<Box> lb, double y)
        { 
            bool found = true;
            while (found)
            {
                found = false;
                for (int i = 0; i < lb.Count; ++i)
                {
                    Box b = lb[i];
                    if (b.YMax == y)
                    {
                        lb.Remove(b);
                        found = true;
                        break;
                    }
                }
            }
        }
    }
}
