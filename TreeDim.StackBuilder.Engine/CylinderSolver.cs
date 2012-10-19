#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    public interface ICylinderSolver
    {
        void ProcessAnalysis(PalletAnalysisCylinder truckAnalysis);
    }
}
