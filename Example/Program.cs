using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cambridge.Talks;

namespace Example
{
    class Program
    {
        /// <summary>
        /// Shows all talks in a feed.
        /// </summary>
        /// <param name="feed"></param>
        private static void ShowTalks(Feed feed)
        {
            foreach (Talk talk in feed.Talks)
            {
                Console.WriteLine("[{0}] {1} ({2})", talk.StartTime, talk.Title, talk.Speaker);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // show upcoming talks at the computer lab
                Feed cl = Feed.Load(6330);

                Console.WriteLine("Upcoming talks at the Computer Lab:");
                ShowTalks(cl);

                Console.WriteLine();

                // show the previous 10 talks at the computer lab
                cl = Feed.Load(6330, limit: 10, endTime: DateTime.Now, reverseOrder: true);

                Console.WriteLine("Most recent talks at the Computer Lab:");
                ShowTalks(cl);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't load talks: {0}", ex.Message);
            }
        }
    }
}
