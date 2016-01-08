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
        //fields
        public int ID;
        public string URL;
        private string desc;

        //constructor
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

        //methods

        /// <summary>
        /// Gets images for the page to display
        /// </summary>
        /// <param name="max">maximum amount of images to display according to the ID</param>
        /// <param name="min">minimal amount of images to display according to the ID</param>
        /// <returns>a list of the found images, never exceeds the count of 9</returns>
        public static List<Image> LoadPageContent(int max, int min)
        {
            List<Image> images = new List<Image>();
            DataTable content = Database.RetrieveQuery("SELECT \"URL\", \"ID\", rn FROM (SELECT \"URL\", \"ID\", rownum as rn FROM \"Image\" WHERE rownum <= " +
                max + " ORDER BY \"ID\" DESC" + ") WHERE rn > " + min);
            foreach (DataRow dr in content.Rows)
            {
                images.Add(new Image(Convert.ToInt32(dr["ID"]), dr["URL"].ToString()));
            }
            return images;
        }
        /// <summary>
        /// haalt alle user images op 
        /// </summary>
        /// <param name="userID">user id to get images from</param>
        /// <returns></returns>
        public static List<Image> GetUserImages(int userID)// for later use of profile image or searching with images
        {
            //TODO: zoek alle user image resultaten in de database
            return new List<Image>();
        }
        /// <summary>
        /// image toevoegen aan database
        /// </summary>
        /// <param name="userID">uploader id</param>
        /// <param name="url">path of the image</param>
        /// <returns></returns>
        public static Image AddImage(int userID, string url)
        {
            bool succes = Database_Layer.Database.InsertImage(userID, url);
            return new Image(userID, url);
        }
        /// <summary>
        /// add image with description
        /// </summary>
        /// <param name="userID">uploader id</param>
        /// <param name="url">path of the image</param>
        /// <param name="description">description of image</param>
        /// <returns></returns>
        public static Image AddImage(int userID, string url, string description)
        {
            Database_Layer.Database.InsertImage(userID, url, description);
            return new Image(userID, url, description);
        }
        /// <summary>
        /// compare method
        /// </summary>
        /// <param name="x">object 1</param>
        /// <param name="y">object 2</param>
        /// <returns></returns>
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
