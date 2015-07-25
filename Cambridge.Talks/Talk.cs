using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cambridge.Talks
{
    /// <summary>
    /// Represents a talk.
    /// </summary>
    public class Talk
    {
        #region Instance members
        /// <summary>
        /// The unique ID of this talk.
        /// </summary>
        private Int32 id;
        /// <summary>
        /// The title of this talk.
        /// </summary>
        private String title;
        /// <summary>
        /// The summary of this talk.
        /// </summary>
        private String summary;
        /// <summary>
        /// The description of the speaker.
        /// </summary>
        private String speaker;
        /// <summary>
        /// The description of the venue.
        /// </summary>
        private String venue;
        /// <summary>
        /// A special message.
        /// </summary>
        private String specialMessage;
        /// <summary>
        /// The URL of this talk.
        /// </summary>
        private String url;
        /// <summary>
        /// The start time of this talk.
        /// </summary>
        private DateTime startTime;
        /// <summary>
        /// The end time of this talk.
        /// </summary>
        private DateTime endTime;
        /// <summary>
        /// A description of the series in which this talk appears.
        /// </summary>
        private String series;
        /// <summary>
        /// The time when this talk was created.
        /// </summary>
        private DateTime createdAt;
        /// <summary>
        /// The time when this talk was last updated.
        /// </summary>
        private DateTime updatedAt;
        /// <summary>
        /// A description of the organiser of this talk.
        /// </summary>
        private String organiser;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the unique ID of this talk.
        /// </summary>
        public Int32 ID
        {
            get { return this.id; }
        }
        /// <summary>
        /// Gets the title of this talk.
        /// </summary>
        public String Title
        {
            get { return title; }
        }
        /// <summary>
        /// Gets the abstract of this talk.
        /// </summary>
        public String Abstract
        {
            get { return summary; }
        }
        /// <summary>
        /// Gets a description of the speaker (typically consisting of the name and affiliation, 
        /// but there is no fixed format for this information).
        /// </summary>
        public String Speaker
        {
            get { return speaker; }
        }
        /// <summary>
        /// Gets a description of the venue in which this talk takes place.
        /// </summary>
        public String Venue
        {
            get { return venue; }
        }
        /// <summary>
        /// Gets a special message which may be associated with this talk.
        /// </summary>
        public String SpecialMessage
        {
            get { return specialMessage; }
        }
        /// <summary>
        /// Gets the URL of this talk.
        /// </summary>
        public String URL
        {
            get { return url; }
        }
        /// <summary>
        /// Gets the start time of this talk.
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
        }
        /// <summary>
        /// Gets the end time of this talk.
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
        }
        /// <summary>
        /// Gets a description of the series in which this talk appears.
        /// </summary>
        public String Series
        {
            get { return series; }
        }
        /// <summary>
        /// Gets the time when this talk was created.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return createdAt; }
        }
        /// <summary>
        /// Gets the time when this talk was last updated.
        /// </summary>
        public DateTime UpdatedAt
        {
            get { return updatedAt; }
        }
        /// <summary>
        /// Gets a description of the organiser of this talk (not all talks have this information).
        /// </summary>
        public String Organiser
        {
            get { return organiser; }
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads a talk from an XML element.
        /// </summary>
        /// <param name="talk"></param>
        /// <returns></returns>
        internal static Talk Load(XElement talk)
        {
            if (talk == null)
                throw new ArgumentNullException("talk");

            Talk t = new Talk();

            t.id = Convert.ToInt32(talk.Element("id").Value);
            t.title = talk.Element("title").Value;
            t.summary = talk.Element("abstract").Value;
            t.speaker = talk.Element("speaker").Value;
            t.venue = talk.Element("venue").Value;
            t.specialMessage = talk.Element("special_message").Value;
            t.url = talk.Element("url").Value;
            t.startTime = DateTime.Parse(talk.Element("start_time").Value);
            t.endTime = DateTime.Parse(talk.Element("end_time").Value);
            t.series = talk.Element("series").Value;
            t.createdAt = DateTime.Parse(talk.Element("created_at").Value);
            t.updatedAt = DateTime.Parse(talk.Element("updated_at").Value);

            if (talk.Element("organiser") != null)
                t.organiser = talk.Element("organiser").Value;

            return t;
        }
        #endregion
    }
}
