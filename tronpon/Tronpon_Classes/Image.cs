using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Database_Layer;

namespace Tronpon_Classes
{
    public class Image : IComparer<Image>
    {
        private int ID;
        public string URL;
        private string desc;

        private Image(int id, string url)
        {
            this.ID = id;
            this.URL = url;
        }
        private Image(int id, string url, string description)
        {
            this.ID = id;
            this.URL = url;
            this.desc = description;
        }
        /// <summary>
        /// Gets images for the page to display
        /// </summary>
        /// <param name="max">maximum amount of images to display according to the ID</param>
        /// <param name="min">minimal amount of images to display according to the ID</param>
        /// <returns>a list of the found images, never exceeds the count of 9</returns>
        public static List<Image> LoadPageContent(int max, int min)
        {
            List<Image> images = new List<Image>();
            DataTable content = Database.RetrieveQuery("SELECT \"URL\", rn FROM (SELECT \"URL\", rownum as rn FROM \"Image\" WHERE rn < " +
                max + ") WHERE rn > " + min);
            foreach (DataRow dr in content.Rows)
            {
                images.Add(new Image((int)dr["USER_ID"], (string)dr["URL"]));
            }
            return images;
        }
      
        public static List<Image> GetUserImages(int userID)// for later use of profile image or searching with images
        {
            //TODO: fire a query at the database, yielding all the results for images 
            return new List<Image>();
        }

        public static Image AddImage(int userID, string url)
        {
            bool succes = Database_Layer.Database.InsertImage(userID, url);
            return new Image(userID, url);
        }
         public static Image AddImage(int userID, string url, string description)
        {
            Database_Layer.Database.InsertImage(userID, url, description);
            return new Image(userID, url, description);
        }
     
        public int Compare(Image x, Image y)
        {
            if (Object.ReferenceEquals(x, y))
                return 0;
            else if (Object.ReferenceEquals(x, null))
                return -1;
            else if (Object.ReferenceEquals(null, y))
                return 1;
            return string.Compare(x.URL, y.URL);
        }
    }
}
