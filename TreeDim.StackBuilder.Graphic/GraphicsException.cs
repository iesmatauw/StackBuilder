#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class GraphicsException : Exception
    {
        #region Constructor
        public GraphicsException()
            : base()
        { 
        }
        public GraphicsException(string message)
            : base(message)
        { 
        }
        public GraphicsException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
        #endregion
    }
}
