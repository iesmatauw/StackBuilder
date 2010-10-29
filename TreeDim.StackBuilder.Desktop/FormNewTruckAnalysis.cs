#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Desktop.Properties;
using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewTruckAnalysis : Form
    {
        #region Data members
        private Document _document;
        private TruckProperties[] _truckProperties;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysis));
        #endregion
 
        #region Combo box item private classes
        private class TruckItem
        {
            private TruckProperties _truckProperties;
            public TruckItem(TruckProperties truckProperties)
            {
                _truckProperties = truckProperties;
            }
            public TruckProperties Item
            {
                get { return _truckProperties; }
            }
            public override string ToString()
            {
                return _truckProperties.Name;
            } 
        }
        #endregion

        #region Constructor
        public FormNewTruckAnalysis(Document document)
        {
            InitializeComponent();
        }
        #endregion
        
        #region Load / FormClosing event
        private void FormNewTruckAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                // fill boxes combo
                foreach (TruckProperties truck in _truckProperties)
                    cbTruck.Items.Add(new TruckItem(truck));

                if (cbTruck.Items.Count > 0)
                    cbTruck.SelectedIndex = 0;

                // allow several pallet layers
                AllowSeveralPalletLayers = Settings.Default.AllowSeveralPalletLayers;
                // allowed pallet orientations
                AllowPalletOrientationX = Settings.Default.AllowPalletOrientationX;
                AllowPalletOrientationY = Settings.Default.AllowPalletOrientationY;
                // min distances
                MinDistancePalletTruckWall = Settings.Default.MinDistancePalletTruckWall;
                MinDistancePalletTruckRoof = Settings.Default.MinDistancePalletTruckRoof;

                // windows settings
                if (null != Settings.Default.FormNewTruckAnalysisPosition)
                    Settings.Default.FormNewTruckAnalysisPosition.Restore(this);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void FormNewTruckAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // allow several pallet layers
                Settings.Default.AllowSeveralPalletLayers = AllowSeveralPalletLayers;
                // allowed pallet orientations
                Settings.Default.AllowPalletOrientationX = AllowPalletOrientationX;
                Settings.Default.AllowPalletOrientationY = AllowPalletOrientationY;
                // min distances
                Settings.Default.MinDistancePalletTruckWall = MinDistancePalletTruckWall;
                Settings.Default.MinDistancePalletTruckRoof = MinDistancePalletTruckRoof;
                // window position
                if (null == Settings.Default.FormNewTruckAnalysisPosition)
                    Settings.Default.FormNewTruckAnalysisPosition = new WindowSettings();
                Settings.Default.FormNewTruckAnalysisPosition.Record(this);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Public properties
        public TruckProperties[] TruckProperties
        {
            get { return _truckProperties; }
            set { _truckProperties = value; }
        }
        public TruckProperties SelectedTruck
        {
            get { return _truckProperties[cbTruck.SelectedIndex]; }
        }
        public bool AllowSeveralPalletLayers
        {
            get { return checkBoxAllowSeveralLayers.Checked;   }
            set { checkBoxAllowSeveralLayers.Checked = value; }
        }
        public bool AllowPalletOrientationX
        {
            get { return checkBoxAllowPalletOrientationX.Checked; }
            set { checkBoxAllowPalletOrientationX.Checked = value; }
        }
        public bool AllowPalletOrientationY
        {
            get { return checkBoxAllowPalletOrientationY.Checked; }
            set { checkBoxAllowPalletOrientationY.Checked = value; } 
        }
        public double MinDistancePalletTruckWall
        {
            get { return (double)nudDistancePalletWall.Value; }
            set { nudDistancePalletWall.Value = (decimal)value; }
        }
        public double MinDistancePalletTruckRoof
        {
            get { return (double)nudDistancePalletRoof.Value; }
            set { nudDistancePalletRoof.Value = (decimal)value; }
        }
        #endregion
    }
}
