using System;
#region Using directives
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.EdgeCrushTest;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewStackingStrengthAnalysis : Form
    {
        #region Data members
        private Document _document;
        #endregion

        #region Constructor
        public FormNewStackingStrengthAnalysis(Document document)
        {
            InitializeComponent();
            _document = document;
        }
        #endregion

        #region Loading
        private void FormNewStackingStrengthAnalysis_Load(object sender, EventArgs e)
        {
            // cases
            foreach (BProperties bproperties in _document.Cases)
                cbCases.Items.Add(bproperties.Name);
            // cardboards
            
            // rate of humidity
            foreach (string s in McKeeFormula.HumidityCoefDictionnary.Keys)
                cbRateOfHumidity.Items.Add(s);
            // storage duration
            foreach (string s in McKeeFormula.JStockCoefDictionnary.Keys)
                cbStorageDuration.Items.Add(s);

            // initialization
            cbCases.SelectedIndex = 0;
            cbRateOfHumidity.SelectedIndex = 0;
            cbStorageDuration.SelectedIndex = 0;


        }
        #endregion

        #region Event handlers
        private void onDataChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
