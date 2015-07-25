using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambridge.Talks.Utility
{
    /// <summary>
    /// Helper class to construct URLs with query parameters.
    /// </summary>
    public class QueryBuilder
    {
        #region Instance members
        /// <summary>
        /// The URL without query parameters.
        /// </summary>
        private String baseUrl;
        /// <summary>
        /// A dictionary mapping parameters to their values.
        /// </summary>
        private Dictionary<String, Object> parameters;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the dictionary which maps parameters to their values.
        /// </summary>
        public Dictionary<String, Object> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new QueryBuilder object with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The URL without any query parameters.</param>
        public QueryBuilder(String baseUrl)
        {
            this.baseUrl = baseUrl;
            this.parameters = new Dictionary<String, Object>();
        }
        #endregion

        #region ToString
        /// <summary>
        /// Converts the query to a System.String.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder(this.baseUrl);

            for (Int32 i = 0; i < this.parameters.Count; i++)
            {
                var parameter = this.parameters.ElementAt(i);

                // if this is the first parameter we need a ?
                // otherwise an &
                if (i == 0)
                {
                    sb.Append('?');
                }
                else
                {
                    sb.Append('&');
                }

                // append the parameter and value
                sb.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
            }

            return sb.ToString();
        }
        #endregion
    }
}
