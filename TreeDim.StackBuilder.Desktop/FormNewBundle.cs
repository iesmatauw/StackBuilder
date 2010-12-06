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
using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewBundle : Form
    {
        #region Data members
        private Document _document;
        private BundleProperties _bundleProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBundle));
        #endregion

        #region Constructor
        public FormNewBundle(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            // initialize value
            BundleLength = 400.0;
            BundleWidth = 300.0;
            UnitThickness = 5.0;
            NoFlats = 10;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
            // disable Ok buttons
            UpdateButtonOkStatus();
        }
        public FormNewBundle(Document document, BundleProperties bundleProperties)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            _bundleProperties = bundleProperties;
            // set caption text
            Text = string.Format("Edit {0}...", _bundleProperties.Name);
            // initialize value
            tbName.Text = bundleProperties.Name;
            tbDescription.Text = bundleProperties.Description;
            BundleLength = bundleProperties.Length;
            BundleWidth = bundleProperties.Width;
            UnitThickness = bundleProperties.UnitThickness;
            UnitWeight = bundleProperties.UnitWeight;
            NoFlats = bundleProperties.NoFlats;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
            // disable Ok buttons
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event handlers
        private void FormNewBundle_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewBundlePosition)
                Settings.Default.FormNewBundlePosition.Restore(this);
        }
        private void FormNewBundle_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewBundlePosition)
                Settings.Default.FormNewBundlePosition = new WindowSettings();
            Settings.Default.FormNewBundlePosition.Record(this);
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
            DrawBundle();
            base.OnResize(e);
        }
        #endregion

        #region Public properties
        public string BundleName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double BundleLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double BundleWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value; }
        }
        public double UnitThickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        public double UnitWeight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public int NoFlats
        {
            get { return (int)nudNoFlats.Value; }
            set { nudNoFlats.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value;}
        }
        #endregion

        #region Handlers
        private void onBundlePropertyChanged(object sender, EventArgs e)
        {
            DrawBundle();
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawBundle();
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _bundleProperties))
                message = Resources.ID_INVALIDNAME;
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

        #region Draw bundle
        private void DrawBundle()
        {
            try
            {
                // get horizontal angle
                double angle = trackBarHorizAngle.Value;
                // graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

                BundleProperties bundleProperties = new BundleProperties(
                    null, BundleName, Description
                    , BundleLength, BundleWidth, UnitThickness, UnitWeight, NoFlats, Color);
                Box box = new Box(0, bundleProperties);
                graphics.AddBox(box);
                graphics.AddDimensions(new DimensionCube(BundleLength, BundleWidth, UnitThickness * NoFlats));
                graphics.Flush();
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
    }
}