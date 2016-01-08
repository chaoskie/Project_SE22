using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tronpon_Classes
{
    public class Comment
    {
        //fields
        private int UserID;
        private int ImgID;
        private string Text;

        //constructor
        public Comment(int userid, int imgid, string text)
        {
            this.UserID = userid;
            this.ImgID = imgid;
            this.Text = text;
        }

        //methods

        /// <summary>
        /// Retrieves all the user comments through the User's ID
        /// </summary>
        /// <param name="userid">The ID as stored in the database</param>
        /// <returns>A list of all the comments</returns>
        public static List<Comment> GetUserComments(int userid)
        {
            //TODO: ophalen van user comments via database
            //niet toegevoegd in huidige versie
            return new List<Comment>();
        }

        public static bool PostComment(int userid, int imgid, string text)
        {
            //TODO: insert comment in database
            //niet toegevoegd in huidige versie
            return true;
        }
    }
}
