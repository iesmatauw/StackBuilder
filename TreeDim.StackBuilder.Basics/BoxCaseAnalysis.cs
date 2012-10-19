#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region BoxCaseAnalysis
    public class BoxCaseAnalysis : ItemBase
    {
        #region Data members
        BoxProperties _boxProperties;
        BoxProperties _caseProperties;
        BoxCaseConstraintSet _constraintSet;
        /// <summary>
        /// List of solutions
        /// </summary>
        List<BoxCaseSolution> _solutions;
        /// <summary>
        /// reference to solver used when updating is needed
        /// </summary>
        private static IBoxCaseAnalysisSolver _solver;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(BoxCaseAnalysis));
        #endregion

        #region Constructor
        public BoxCaseAnalysis(BoxProperties boxProperties, BoxProperties caseProperties, BoxCaseConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            if (!constraintSet.IsValid)
                throw new Exception("Using invalid box/case constraintset -> Can not instantiate box/case analysis!");
            _boxProperties = boxProperties;
            _caseProperties = caseProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public BoxProperties BoxProperties
        { get { return _boxProperties; } }

        public BoxProperties CaseProperties
        { get { return _caseProperties; } }

        public BoxCaseConstraintSet ConstraintSet
        { get { return _constraintSet; } }

        public List<BoxCaseSolution> Solutions
        {
            get { return _solutions; }
            set { _solutions = value; }
        }
        #endregion

        #region Depandancies
        protected override void OnDispose()
        {
            base.OnDispose();
        }
        protected override void RemoveItselfFromDependancies()
        {
            _boxProperties.RemoveDependancie(this);
            _caseProperties.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear solutions
            _solutions.Clear();
        }
        #endregion
    }
    #endregion

    #region IBoxCaseAnalysisSolver
    public interface IBoxCaseAnalysisSolver
    {
        void ProcessAnalysis(BoxCaseAnalysis analysis);
    }
    #endregion
}
