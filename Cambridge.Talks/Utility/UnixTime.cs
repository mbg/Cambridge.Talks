using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambridge.Talks.Utility
{
    /// <summary>
    /// Provides helper methods to work with unix timestamps.
    /// </summary>
    public static class UnixTime
    {
        /// <summary>
        /// Converts a DateTime object to a unix timestamp.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>Returns the number of seconds since the start of 1970.</returns>
        public static Int32 ToUnix(this DateTime dateTime)
        {
            return (Int32)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
