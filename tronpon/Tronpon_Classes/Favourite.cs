using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tronpon_Classes
{
   public class Favourite
    {
        private int UserID;
        private int ImageID;

        private Favourite(int userid, int imageID)
        {
            this.UserID = userid;
            this.ImageID = imageID;
        }

        /// <summary>
        /// Retrieves all the user favourites through the User's ID
        /// </summary>
        /// <param name="userid">The ID as stored in the database</param>
        /// <returns>A list of all the favourites</returns>
        public static List<Favourite> GetUserFavourites(int userid)
        {
            //TODO: fire a query at the database, yielding all the results for favourites
            return new List<Favourite>();
        }
    }
}
