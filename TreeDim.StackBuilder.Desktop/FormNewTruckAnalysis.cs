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
        private TruckProperties[] _truckProperties;
        private TruckAnalysis _truckAnalysis;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysis));
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
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="document">Parent document</param>
        public FormNewTruckAnalysis(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);

        }
        /// <summary>
        /// Constructor used when editing an existing analysis
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="truckAnalysis">Truck analysis</param>
        public FormNewTruckAnalysis(Document document, TruckAnalysis truckAnalysis)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // set truck analysis ref
            _truckAnalysis = truckAnalysis;
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

                if (null == _truckAnalysis)
                {
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
                }
                else
                {
                    for (int i = 0; i < cbTruck.Items.Count; ++i)
                    {
                        // selected index
                        TruckItem truckItem = cbTruck.Items[i] as TruckItem;
                        if (truckItem.Item == _truckAnalysis.TruckProperties)
                        {
                            cbTruck.SelectedIndex = i;
                            break;
                        }
                        // allow several pallet layers
                        AllowSeveralPalletLayers = _truckAnalysis.ConstraintSet.MultilayerAllowed;
                        // allowed pallet orientations
                        AllowPalletOrientationX = _truckAnalysis.ConstraintSet.AllowPalletOrientationX;
                        AllowPalletOrientationY = _truckAnalysis.ConstraintSet.AllowPalletOrientationY;
                        // min distance
                        MinDistancePalletTruckRoof = _truckAnalysis.ConstraintSet.MinDistancePalletTruckRoof;
                        MinDistancePalletTruckWall = _truckAnalysis.ConstraintSet.MinDistancePalletTruckWall;
                    }
                }
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
        public TruckProperties[] Trucks
        {
            get { return _truckProperties; }
            set { _truckProperties = value; }
        }
        public TruckProperties SelectedTruck
        {
            get { return _truckProperties[cbTruck.SelectedIndex]; }
            set { }
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
