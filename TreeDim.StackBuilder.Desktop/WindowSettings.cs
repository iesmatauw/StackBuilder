#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /* Author: Don Kirkby http://donkirkby.googlecode.com/
     * Released under the MIT licence http://www.opensource.org/licenses/mit-license.php
     * Installation:
     * - Copy this file into your project.
     * - Change the namespace above to match your project's namespace.
     * - Compile your project.
     * - Edit the project properties using the Project Properties... item in 
     * the project menu.
     * - Go to the settings tab.
     * - Add a new setting for each form whose position you want to save, and 
     * type a name for it like MainFormPosition.
     * - In the type column, select Browse... from the bottom of the list.
     * - You won't see WindowSettings in the list, but you can just type the
     * namespace and class name, and click OK. For example, if you changed this
     * class's namespace to UltimateApp, then you would type 
     * UltimateApp.WindowSettings and click OK.
     * - Add Load and FormClosing event handlers to any forms you want to save.
     * See the forms in this project for example code.
     * - Add a call to Settings.Default.Save() somewhere in your shutdown code.
     * The FormClosed event of your main form is a good spot. If you have 
     * subforms open, you may have to explicitly call their FormClosing events 
     * when shutting down the app, because they're not called by default.
     */
    /// <summary>
    /// Serializes a window's location, size, state, and any splitter 
    /// positions to a single application setting. Then you can just create a 
    /// setting of this type for each form in the application, save on close, 
    /// and restore on load.
    /// </summary>
    [Serializable()]
    public class WindowSettings
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public FormWindowState WindowState { get; set; }
        public int[] SplitterDistances { get; set; }

        public void Record(Form form, params SplitContainer[] splitters)
        {
            bool shouldRecordSplitters;
            switch (form.WindowState)
            {
                case FormWindowState.Maximized:
                    RecordWindowPosition(form.RestoreBounds);
                    shouldRecordSplitters = true;
                    break;
                case FormWindowState.Normal:
                    shouldRecordSplitters =
                        RecordWindowPosition(form.Bounds);
                    break;
                default:
                    // Don't record anything when closing while minimized.
                    return;
            }
            WindowState = form.WindowState;
            if (shouldRecordSplitters)
            {
                RecordSplitters(splitters);
            }

        }

        public void Restore(Form form, params SplitContainer[] splitters)
        {
            if (IsOnScreen(Location, Size))
            {
                form.Location = Location;
                form.Size = Size;
                form.WindowState = WindowState;
                RestoreSplitters(splitters);
            }
            else
            {
                form.WindowState = WindowState;
            }
        }

        private void RestoreSplitters(SplitContainer[] splitters)
        {
            for (int i = 0; i < splitters.Length && i < SplitterDistances.Length; i++)
            {
                var splitter = splitters[i];
                int splitterDistance = SplitterDistances[i];
                int splitterSize =
                    splitter.Orientation == Orientation.Vertical
                    ? splitter.Width
                    : splitter.Height;
                bool isDistanceLegal =
                    splitter.Panel1MinSize <= splitterDistance
                    && splitterDistance <= splitterSize - splitter.Panel2MinSize;
                if (isDistanceLegal)
                {
                    splitter.SplitterDistance = splitterDistance;
                }
            }
        }

        private bool RecordWindowPosition(Rectangle bounds)
        {
            bool isOnScreen = IsOnScreen(bounds.Location, bounds.Size);
            if (isOnScreen)
            {
                Location = bounds.Location;
                Size = bounds.Size;
            }
            return isOnScreen;
        }

        private void RecordSplitters(SplitContainer[] splitters)
        {
            SplitterDistances = new int[splitters.Length];
            for (int i = 0; i < splitters.Length; i++)
            {
                SplitterDistances[i] = splitters[i].SplitterDistance;
            }
        }

        private bool IsOnScreen(Point location, Size size)
        {
            return IsOnScreen(location) && IsOnScreen(location + size);
        }

        private bool IsOnScreen(Point location)
        {
            foreach (var screen in Screen.AllScreens)
            {
                Rectangle recScreen = screen.WorkingArea;
                recScreen.Inflate(new Size(1,1));
                if (recScreen.Contains(location))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
