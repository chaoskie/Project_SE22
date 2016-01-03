using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tronpon_Classes
{
    class Image
    {
        private int ID;
        private string URL;

        private Image(int id, string url)
        {
            this.ID = id;
            this.URL = url;
        }

        /// <summary>
        /// Retrieves all the user images through the User's ID
        /// </summary>
        /// <param name="userid">The ID as stored in the database</param>
        /// <returns>A list of all the images</returns>
        public static List<Image> GetUserImages(int userID)
        {
            //TODO: fire a query at the database, yielding all the results for images
            return new List<Image>();
        }

        public static Image AddImage(int userID, string url)
        {
            //TODO: fire an insert query at the database, adding the new image
            return new Image(userID, url);
        }
    }
}
