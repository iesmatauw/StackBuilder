#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class CaseSolutionViewer
    {
        #region Data members
        private CaseSolution _caseSolution;
        #endregion

        #region Constructor
        public CaseSolutionViewer(CaseSolution caseSolution)
        { 
        }
        #endregion
        #region Public methods
        public void Draw(Graphics3D graphics)
        {
            if (null == _caseSolution)
                throw new Exception("No case solution defined!");

            // draw case
            BoxProperties boxProperties = null;
            Case case_ = new Case(boxProperties);
            case_.Draw(graphics);
            // draw solution
            uint pickId = 0;
            foreach (ILayer layer in _caseSolution)
            {
            
            }


        }
        public void Draw(Graphics2D graphics)
        {
            if (null == _caseSolution)
                throw new Exception("No case solution defined!");
        }
        #endregion
    }
}
