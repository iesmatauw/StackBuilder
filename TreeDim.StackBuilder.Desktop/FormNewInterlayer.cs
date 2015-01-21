#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewInterlayer : Form, IDrawingContainer
    {
        #region Data members
        private Document _document;
        private InterlayerProperties _interlayerProperties;
        #endregion

        #region Constructor
        public FormNewInterlayer(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name / description
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_INTERLAYER);
            tbDescription.Text = tbName.Text;
            // initialize value
            InterlayerLength = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            InterlayerWidth = UnitsManager.ConvertLengthFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            // disable Ok button
            UpdateButtonOkStatus();
        }
        public FormNewInterlayer(Document document, InterlayerProperties interlayerProperties)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _interlayerProperties = interlayerProperties;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _interlayerProperties.Name);
            // initialize value
            tbName.Text = _interlayerProperties.Name;
            tbDescription.Text = _interlayerProperties.Description;
            InterlayerLength = _interlayerProperties.Length;
            InterlayerWidth = _interlayerProperties.Width;
            Thickness = _interlayerProperties.Thickness;
            Weight = _interlayerProperties.Weight;
            this.Color = _interlayerProperties.Color;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.Invalidate();
        }
        #endregion

        #region Public properties
        public string InterlayerName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double InterlayerLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double InterlayerWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value; }
        }
        public double Thickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        public double Weight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion

        #region Handlers
        private void onInterlayerPropertyChanged(object sender, EventArgs e)
        {
            graphCtrl.Invalidate();
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _interlayerProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // button OK
            bnOk.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        { 
            InterlayerProperties interlayerProperties = new InterlayerProperties(
                null, tbName.Text, tbDescription.Text
                , InterlayerLength, InterlayerWidth
                , Thickness, Weight, Color);
            Box box = new Box(0, interlayerProperties);
            graphics.AddBox(box);
        }
        #endregion

        #region Load / FormClosing
        private void FormNewInterlayer_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition.Restore(this);
            graphCtrl.Invalidate();
        }
        private void FormNewInterlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition = new WindowSettings();
            Settings.Default.FormNewInterlayerPosition.Record(this);
        }
        #endregion
    }
}