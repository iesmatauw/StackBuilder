#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public class Exception : System.Exception
    {
        /// <summary>
        /// Expected exception types
        /// </summary>
        public enum ErrorType
        {
            ERROR_INVALIDCARDBOARD
            , ERROR_INVALIDCASETYPE
            , ERROR_INVALIDFORMULATYPE
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Exception()
            :base()
        {
        }
        /// <summary>
        /// Constructor with message
        /// </summary>
        public Exception(string message)
            : base(message)
        { 
        }
        /// <summary>
        /// Constructor with message + inner exception
        /// </summary>
        public Exception(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
        /// <summary>
        /// Customized exception
        /// </summary>
        public Exception(Exception.ErrorType error, string arg)
            : base(Exception.ExceptionMessage(error, arg))
        { 
        }

        public static string ExceptionMessage(ErrorType error, string arg)
        {
            switch (error)
            {
                case ErrorType.ERROR_INVALIDCARDBOARD:
                    return string.Format(TreeDim.EdgeCrushTest.Properties.Resource.EXCEPTION_INVALIDCARDBOARDID, arg);
                case ErrorType.ERROR_INVALIDCASETYPE:
                    return string.Format(TreeDim.EdgeCrushTest.Properties.Resource.EXCEPTION_INVALIDCASETYPE, arg);
                case ErrorType.ERROR_INVALIDFORMULATYPE:
                    return TreeDim.EdgeCrushTest.Properties.Resource.EXCEPTION_INVALIDFORMULA;
                default:
                    return string.Empty;
            }
        }
    }
}
