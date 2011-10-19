using System.Text;

namespace ExceptionReporting.Core
{
    /// <summary>
    /// Encapsulates the concept of an ExceptionReport
    /// </summary>
    public class ExceptionReport
    {
        private readonly StringBuilder _reportString;

		/// <summary>
		/// Construct an ExceptionReport from a StringBuilder
		/// </summary>
        public ExceptionReport(StringBuilder stringBuilder)
        {
            _reportString = stringBuilder;
        }
        #region System.Object Overrides
        /// <summary>
        /// ToString()
        /// </summary>
        public override string ToString()
        {
            return _reportString.ToString();
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to
        /// the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
    	private bool Equals(ExceptionReport obj)
        {
            return Equals(obj._reportString.ToString(), _reportString.ToString());
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to
        /// the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        public override bool Equals(object obj)
        {
            return Equals((ExceptionReport) obj);
        }
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _reportString.GetHashCode();
        }
        #endregion
    }
}