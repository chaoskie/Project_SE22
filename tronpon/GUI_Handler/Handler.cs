using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tronpon_Classes;
using Database_Layer;

namespace GUI_Handler
{
    public class Handler
    {
        private static User mainuser;
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


        public static List<string> GetContent(int max, int min)
        {
            return Tronpon_Classes.Image.LoadPageContent(max, min).Select(i => i.URL).ToList();
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
           return  NewUser(username, email, password);            
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
        public static void LogoutUser()
        {
            mainuser = null;
        }

        public static bool isUserLoggedIn()
        {
            return MainUser == null ? false : true;
        }

    }
}

