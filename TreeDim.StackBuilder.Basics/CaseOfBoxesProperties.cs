#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CaseOfBoxesProperties : BoxProperties
    {
        #region Data members
        private BoxProperties _boxProperties;
        private CaseDefinition _caseDefinition;
        private CaseOptimConstraintSet _constraintSet;
        #endregion

        #region Constructor
        /// <summary>
        /// Instantiate a new case from a box, a case definition and a case optimization constraintset
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="bProperties">Box properties</param>
        /// <param name="constraintSet">Case optimization constraint set</param>
        public CaseOfBoxesProperties(Document document
            , BoxProperties boxProperties
            , CaseDefinition caseDefinition
            , CaseOptimConstraintSet constraintSet)
            : base(document)
        {
            _boxProperties = boxProperties;
            _boxProperties.AddDependancie(this);
            _caseDefinition = caseDefinition;
            _constraintSet = constraintSet;

            OnAttributeModified(boxProperties);
        }
        #endregion

        #region Public properties
        public BoxProperties InsideBoxProperties
        { get { return _boxProperties; } }
        public CaseDefinition CaseDefinition
        { get { return _caseDefinition; } }
        public CaseOptimConstraintSet CaseOptimConstraintSet
        { get { return _constraintSet; } }
        #endregion

        #region Dependancies
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            Vector3D outerDim = _caseDefinition.OuterDimensions(_boxProperties, _constraintSet);
            Length = outerDim.X;
            Width = outerDim.Y;
            Height = outerDim.Z;

            Vector3D innerDim = _caseDefinition.InnerDimensions(_boxProperties);
            InsideLength = innerDim.X;
            InsideWidth = innerDim.Y;
            InsideHeight = innerDim.Z;
        }
        protected override void RemoveItselfFromDependancies()
        {
            _boxProperties.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            Modify();
            base.OnEndUpdate(updatedAttribute);
        }
        #endregion
    }
}
