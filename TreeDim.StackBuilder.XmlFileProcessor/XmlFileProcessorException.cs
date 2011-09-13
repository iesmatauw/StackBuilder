#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.XmlFileProcessor
{
    class XmlFileProcessorException : Exception
    {
        #region Constructor overrides
        public XmlFileProcessorException()
            : base()
        { 
        }
        public XmlFileProcessorException(string message)
            : base(message)
        { 
        }
        public XmlFileProcessorException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
        #endregion
    }
}
