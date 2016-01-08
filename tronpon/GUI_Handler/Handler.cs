using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using Tronpon_Classes;
using Database_Layer;

namespace GUI_Handler
{
    public class Handler
    {
        //fields
        private static User mainuser;

        //getters - setters
        public static User MainUser
        {
            get
            {
                return HttpContext.Current.Session["MainUser"] as User;
            }
            set
            {
                HttpContext.Current.Session["MainUser"] = value;
            }
        }

        //methods

        /// <summary>
        /// Retrieve content from database
        /// </summary>
        /// <param name="max">maximum images</param>
        /// <param name="min">minimum images</param>
        /// <returns></returns>
        public static List<string> GetContent(int max, int min)
        {
            return Tronpon_Classes.Image.LoadPageContent(max, min).Select(i => String.Format("{0}{1}{2}", @"..\..\images\uploads\", i.ID, i.URL)).ToList();
        }
        /// <summary>
        /// register new user in the database
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>succes boolean</returns>
        public static bool NewUser(string username, string email, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                Database.InsertUser(username, PasswordHash.CreateHash(password), email);
                return true;
            }
            return false;
        }
        /// <summary>
        /// fetch the userID from the user
        /// </summary>
        /// <param name="username">name of the user</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool GetUserID(string username, out int id)
        {
            if (User.GetUserID(username, out id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// alias functie of the newUser
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>succes boolean</returns>
        public static bool RegisterUser(string username, string email, string password)
        {
            return NewUser(username, email, password);
        }

        /// <summary>
        /// login user 
        /// </summary>
        /// <param name="username">username of the login user</param>
        /// <param name="password">password of the login user</param>
        /// <returns>succes boolean</returns>
        public static bool LoginUser(string username, string password)
        {
            bool succ = User.Login(username, password, out mainuser);
            MainUser = mainuser;
            return succ;
        }
        /// <summary>
        /// User logout, set mainuser to null
        /// </summary>
        public static void LogoutUser()
        {
            mainuser = null;
        }
        /// <summary>
        /// verify that user is logged in
        /// </summary>
        /// <returns></returns>
        public static bool isUserLoggedIn()
        {
            return MainUser == null ? false : true;
        }

        /// <summary>
        /// retrieve last uploaded image by this user
        /// </summary>
        /// <param name="userID">id of the user</param>
        /// <returns>id of the image in string</returns>
        public static string GetLastUpload(int? userID = null)
        {
            int posterid = userID == null ? MainUser.UserID : (int)userID;
            DataTable dt = Database.RetrieveQuery("SELECT MAX(\"ID\") as id FROM \"Image\" WHERE \"USER_ID\" = " + posterid);
            return dt.Rows[0]["id"].ToString();
        }
        /// <summary>
        /// insert an image into the database
        /// </summary>
        /// <param name="f">file upload entity that needs to be placed in the server</param>
        /// <param name="message">error message</param>
        /// <returns>succes boolean</returns>
        public static bool InsertImage(System.Web.UI.WebControls.FileUpload f, out string message)
        {

            User poster = MainUser == null ? new User(2, "Anonymous", "anon@ymo.us") : MainUser;
            if (f != null)
            {
                string filename = System.IO.Path.GetFileName(f.PostedFile.FileName);

                //Get extension
                string ext = "." + filename.Split('.').Last();

                if ((ext.ToLower() != ".jpg") && (ext.ToLower() != ".jpeg") && (ext.ToLower() != ".gif") && (ext.ToLower() != ".png"))
                {
                    message = "bestandstype niet ondersteund";
                    return false;
                }

                Image.AddImage(poster.UserID, ext);
                string lastUploadID = GetLastUpload(poster.UserID);

                return Upload(f, lastUploadID, out message);
            }
            else
            {
                message = "geef bestand in";
                return false;
            }
        }

        /// <summary>
        /// Downloads the file to the server
        /// </summary>
        /// <param name="File1"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Upload(System.Web.UI.WebControls.FileUpload File1, string filename, out string message)
        {
            //Data storage
            string
                SaveLocation,
                fn = System.IO.Path.GetFileName(File1.PostedFile.FileName),
                loc = "images\\uploads",
                //Filename
                file = File1.PostedFile.FileName;

            //Get extension
            string ext = "." + file.Split('.').Last();

            if ((ext.ToLower() != ".jpg") && (ext.ToLower() != ".jpeg") && (ext.ToLower() != ".gif") && (ext.ToLower() != ".png"))
            {
                message = "bestandstype niet ondersteund";
                //return false;
            }
            string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            string physicalPath = System.Web.HttpContext.Current.Request.MapPath(appPath);

            SaveLocation = physicalPath + loc + "\\" + filename + ext;
            try
            {
                File1.PostedFile.SaveAs(SaveLocation);
                message = "het bestand is geupload";

                return true;
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;

                return false;
            }

            throw new NotSupportedException();
        }
    }
}

