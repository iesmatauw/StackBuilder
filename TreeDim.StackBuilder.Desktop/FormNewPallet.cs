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
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPallet : Form
    {
        #region Data members
        #endregion

        #region Constructor
        public FormNewPallet()
        {
            InitializeComponent();

            // initialize data
            PalletLength = 1200;
            PalletWidth = 1000;
            PalletHeight = 100;
            Weight = 20;
            AdmissibleLoadWeight = 1000;
            AdmissibleLoadHeight = 3000;

            // select radio button
            radioButtonPallet1.Checked = false;
            radioButtonPallet2.Checked = true;

            // initialize type combo
            for (int i = 0; i < 1; ++i)
                cbType.Items.Add(PalletProperties.PalletTypeNames[i]);
            cbType.SelectedIndex = 0;

            // initialize database pallet combo
            if (0 == cbPallet.Items.Count)
            {
                radioButtonPallet1.Checked = false;
                radioButtonPallet2.Checked = true;
            }
            onPalletInsertionModeChanged(this, null);
            UpdateButtonOkStatus();
        }
        #endregion

        #region Public properties
        public string PalletName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }

        public double PalletLength
        {
            get { return System.Convert.ToDouble(nudLength.Text); }
            set { nudLength.Text = string.Format("{0}", value); }
        }

        public double PalletWidth
        {
            get { return System.Convert.ToDouble(nudWidth.Text); }
            set { nudWidth.Text = string.Format("{0}", value); }
        }

        public double PalletHeight
        {
            get { return System.Convert.ToDouble(nudHeight.Text); }
            set { nudHeight.Text = string.Format("{0}", value); }
        }

        public double Weight
        {
            get { return System.Convert.ToDouble(nudWeight.Text); }
            set { nudWeight.Text = string.Format("{0}", value); }
        }

        public double AdmissibleLoadHeight
        {
            get { return System.Convert.ToDouble(nudAmissibleLoadHeight.Text); }
            set { nudAmissibleLoadHeight.Text = string.Format("{0}", value); }
        }

        public double AdmissibleLoadWeight
        {
            get { return System.Convert.ToDouble(nudAdmissibleLoadWeight.Text); }
            set { nudAdmissibleLoadWeight.Text = string.Format("{0}", value); }
        }

        public Color Color
        {
            get { return cbColor.Color; }
        }

        public PalletProperties.PalletType PalletType
        {
            get { return (PalletProperties.PalletType)cbType.SelectedIndex; }
        }
        #endregion

        #region Draw pallet
        private void DrawPallet()
        {
            double angle = trackBarHorizAngle.Value;
            Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

            PalletProperties palletProperties = new PalletProperties(PalletType, PalletLength, PalletWidth, PalletHeight);
            palletProperties.Color = Color;
            Pallet pallet = new Pallet(palletProperties);
            foreach (Face face in pallet.Faces)
                graphics.AddFace(face);
            graphics.Flush();
            pictureBox.Image = graphics.Bitmap;
        }
        #endregion

        #region Handlers
        private void onPalletPropertyChanged(object sender, EventArgs e)
        {
            DrawPallet();
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawPallet();
        }
        private void onPalletInsertionModeChanged(object sender, EventArgs e)
        {
            cbPallet.Enabled = radioButtonPallet1.Checked;
            tbPalletProperties.Enabled = radioButtonPallet1.Checked;

            lbName.Enabled = radioButtonPallet2.Checked;
            tbName.Enabled = radioButtonPallet2.Checked;
            lbDescription.Enabled = radioButtonPallet2.Checked;
            tbDescription.Enabled = radioButtonPallet2.Checked;
            lbType.Enabled = radioButtonPallet2.Checked;
            cbType.Enabled = radioButtonPallet2.Checked;
            lbColor.Enabled = radioButtonPallet2.Checked;
            cbColor.Enabled = radioButtonPallet2.Checked;
            lbLength.Enabled = radioButtonPallet2.Checked;
            nudLength.Enabled = radioButtonPallet2.Checked;
            lbWidth.Enabled = radioButtonPallet2.Checked;
            nudWidth.Enabled = radioButtonPallet2.Checked;
            lbHeight.Enabled = radioButtonPallet2.Checked;
            nudHeight.Enabled = radioButtonPallet2.Checked;
            lbWeight.Enabled = radioButtonPallet2.Checked;
            nudWeight.Enabled = radioButtonPallet2.Checked;
            lbAdmissibleHeight.Enabled = radioButtonPallet2.Checked;
            nudAmissibleLoadHeight.Enabled = radioButtonPallet2.Checked;
            lbAdmissibleWeight.Enabled = radioButtonPallet2.Checked;
            nudAdmissibleLoadWeight.Enabled = radioButtonPallet2.Checked;
            lbMm1.Enabled = radioButtonPallet2.Checked;
            lbMm2.Enabled = radioButtonPallet2.Checked;
            lbMm3.Enabled = radioButtonPallet2.Checked;
            lbMm4.Enabled = radioButtonPallet2.Checked;
            lbKg1.Enabled = radioButtonPallet2.Checked;
            lbKg2.Enabled = radioButtonPallet2.Checked;
        }
        private void UpdateButtonOkStatus()
        {
            bnAccept.Enabled = tbName.Text.Length > 0 && tbDescription.Text.Length > 0;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion
    }
}