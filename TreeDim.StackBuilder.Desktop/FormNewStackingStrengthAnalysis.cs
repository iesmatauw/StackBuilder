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
            // cardboards
            foreach (string s in McKeeFormula.CardboardQualityDictionary.Keys)
                cbCardboard.Items.Add(s);            
            // rate of humidity
            foreach (string s in McKeeFormula.HumidityCoefDictionary.Keys)
                cbRateOfHumidity.Items.Add(s);
            // storage duration
            foreach (string s in McKeeFormula.StockCoefDictionary.Keys)
                cbStorageDuration.Items.Add(s);
            // initialization
            if (cbCardboard.Items.Count > 0)
                cbCardboard.SelectedIndex = 0;
            if (cbRateOfHumidity.Items.Count > 0)
                cbRateOfHumidity.SelectedIndex = 0;
            if (cbStorageDuration.Items.Count > 0)
                cbStorageDuration.SelectedIndex = 0;
        }
        #endregion

        #region Event handlers
        private void onDataChanged(object sender, EventArgs e)
        {
            // selected case
            /*
            BoxProperties case = null;
            McKeeFormula.FormulaOption1()
            */
        }
        #endregion
    }
}
