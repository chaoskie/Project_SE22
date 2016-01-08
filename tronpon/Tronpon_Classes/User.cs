using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Layer;
using System.Data;

namespace Tronpon_Classes
{
    public class User
    {
        public List<Image> ListImages;
        public List<Favourite> ListFavourites;
        public List<Comment> ListOwnComments;

        public int UserID;
        public string Name;
        public string Email;


        public User(int id, string name, string email)
        {
            this.UserID = id;
            this.Name = name;
            this.Email = email;

            /* TODO
            ListFavourites = Favourite.GetUserFavourites(this.UserID);
            ListImages = Image.GetUserImages(this.UserID);
            ListOwnComments = Comment.GetUserComments(this.UserID);
             */
        }

        public static bool Login(string username, string password, out User user)
        {
            user = null;
            int ID;
            if (GetUserID(username, out ID))
            { 
                DataTable dt = Database.RetrieveQuery("SELECT * FROM \"User\" WHERE \"ID\" = " + ID);
                user = new User(Convert.ToInt32(dt.Rows[0]["ID"]),
                    dt.Rows[0]["Username"].ToString(),
                    dt.Rows[0]["Email"].ToString());
                return PasswordHash.ValidatePassword(password, dt.Rows[0]["PassHash"].ToString());
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Uploads an image to the server and adds a reference to the database
        /// </summary>
        /// <param name="url">Url for the reference</param>
        /// <param name="errorMessage">Message of the error</param>
        /// <returns>Whether there has been an error or not</returns>
        public bool UploadImage(string url, out string errorMessage)
        {
            //TODO: Download image to server

            //Add image to the database
            Image.AddImage(this.UserID, url);

            bool finished = false;
            errorMessage = "Nog niet afgemaakt!";
            return finished;
        }

        /// <summary>
        /// Adds a comment to the referenced image
        /// </summary>
        /// <param name="imageID">The ID of targeted image</param>
        /// <param name="text">The text of the comment</param>
        /// <returns>Whether there has been an error or not</returns>
        public bool PostComment(int imageID, string text)
        {
            ListOwnComments.Add(new Comment(this.UserID, imageID, text));
            return Comment.PostComment(this.UserID, imageID, text);
        }
        /// <summary>
        /// method to fetch the user ID
        /// </summary>
        /// <param name="username">username to find the id of</param>
        /// <returns>the ID of the user</returns>
        public static bool GetUserID(string username, out int result)
        {
            DataTable dt = Database.GetUserID(username);
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0]["ID"]);
                return true;
            }
            result = -1;
            return false;
        }
    }
}
