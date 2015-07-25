using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Cambridge.Talks.Utility;

namespace Cambridge.Talks
{
    /// <summary>
    /// Represents a feed.
    /// </summary>
    public class Feed
    {
        #region Constants
        /// <summary>
        /// The base url of all talks.cam feeds.
        /// </summary>
        public const String BASE_URL = "http://www.talks.cam.ac.uk/show/xml/{0}";
        #endregion

        #region Instance members
        /// <summary>
        /// The unique id of this feed.
        /// </summary>
        private Int32 id;
        /// <summary>
        /// The name of this feed.
        /// </summary>
        private String name;
        /// <summary>
        /// A description of the contents of this feed.
        /// </summary>
        private String details;
        /// <summary>
        /// A URL pointing to this list.
        /// </summary>
        private String url;
        /// <summary>
        /// A list of talks in this feed.
        /// </summary>
        private List<Talk> talks;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the unique ID of this feed.
        /// </summary>
        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }
        /// <summary>
        /// Gets the name of this feed.
        /// </summary>
        public String Name
        {
            get
            {
                return this.name;
            }
        }
        /// <summary>
        /// Gets a description of the contents of this feed.
        /// </summary>
        public String Details
        {
            get
            {
                return this.details;
            }
        }
        /// <summary>
        /// Gets the URL of this feed.
        /// </summary>
        public String URL
        {
            get
            {
                return this.url;
            }
        }
        /// <summary>
        /// Gets the list of talks in this feed.
        /// </summary>
        public List<Talk> Talks
        {
            get
            {
                return this.talks;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new instance of a talk with the specified ID.
        /// </summary>
        /// <param name="id">The unique ID of the feed.</param>
        private Feed(Int32 id)
        {
            this.id = id;
            this.url = String.Format(BASE_URL, id);
            this.talks = new List<Talk>();
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads the feed with the specified ID.
        /// </summary>
        /// <param name="id">The unique ID of the feed to load.</param>
        /// <param name="limit">The maximum number of talks to load. Unlimited if null.</param>
        /// <param name="startTime">Talks which start before the value of this DateTime object will not be loaded.</param>
        /// <param name="endTime">Talks which start later than the value of this DateTime object will not be loaded.</param>
        /// <param name="reverseOrder">A value indicating whether results should be returned in reverse order.</param>
        /// <returns>Returns a snapshot of the feed with the specified ID.</returns>
        public static Feed Load(
            Int32 id, 
            Int32? limit = null, 
            DateTime? startTime = null, 
            DateTime? endTime = null, 
            Boolean reverseOrder = false)
        {
            Feed result = new Feed(id);

            // construct a URL for the requested feed
            StringBuilder urlBuilder = new StringBuilder(result.url);
            urlBuilder.AppendFormat("?reverse_order={0}", reverseOrder);

            if (limit != null)
                urlBuilder.AppendFormat("&limit={0}", limit);
            if (startTime.HasValue)
                urlBuilder.AppendFormat("&start_time={0}", startTime.Value.ToUnix());
            if (endTime.HasValue)
                urlBuilder.AppendFormat("&end_time={0}", endTime.Value.ToUnix());
            
            // load the xml
            XmlReader reader = XmlReader.Create(urlBuilder.ToString());
            XDocument doc = XDocument.Load(reader);
            XElement root = doc.Root;

            result.name = root.Element("name").Value;
            result.details = root.Element("details").Value;
            result.url = root.Element("url").Value;

            foreach (XElement talk in root.Elements("talk"))
            {
                Talk t = Talk.Load(talk);
                result.talks.Add(t);
            }

            return result;
        }
        #endregion
    }
}
