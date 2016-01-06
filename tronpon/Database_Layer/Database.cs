using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;
using Database_Layer.Exceptions;

namespace Database_Layer
{
    /// <summary>
    /// The database class to communicate between the application and the database
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// The host IP address
        /// </summary>
        private static string host = "192.168.20.27";

        /// <summary>
        /// The username of the host
        /// </summary>
        private static string username = "Lars";

        /// <summary>
        /// The password of the host
        /// </summary>
        private static string dbpassword = "tronpon";

        /// <summary>
        /// The connection string to connect to the host
        /// </summary>
        private static string connectionstring = "User Id=" + username + ";Password=" + dbpassword + ";Data Source= //" + host + ":1521/XE;";

        /// <summary>
        /// Selects and retrieves values from the database 
        /// </summary>
        /// <param name="query">The selection statement</param>
        /// <returns>A DataTable with the retrieved values></returns>
        public static DataTable RetrieveQuery(string query)
        {
            if (Regex.IsMatch(query, @"-{2,}"))
            {
                throw new SQLInjectionException();
            }

            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                try
                {
                    c.Open();
                    OracleCommand cmd = new OracleCommand(@query);
                    cmd.Connection = c;
                    try
                    {
                        OracleDataReader r = cmd.ExecuteReader();
                        DataTable result = new DataTable();
                        result.Load(r);
                        c.Close();
                        return result;
                    }
                    catch (OracleException e)
                    {
                        Console.Write(e.Message);
                        throw;
                    }
                }
                catch (OracleException e)
                {
                    Console.Write(e.Message);
                    return new DataTable();
                }
            }
        }

        #region comments

        public static bool InsertComment(int USER_ID, int IMAGE_ID, string Text)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Comment\" (\"USER_ID\", \"IMAGE_ID\", \"Text\") VALUES (:UI, :II, :TXT)");
                cmd.Parameters.Add(new OracleParameter("UI", USER_ID));
                cmd.Parameters.Add(new OracleParameter("II", IMAGE_ID));
                cmd.Parameters.Add(new OracleParameter("TXT", Text));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Removes a comment from the database
        /// </summary>
        /// <param name="commentID">The ID of the comment</param>
        /// <param name="adminDel">Whether or not the admin or user has deleted the message</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteComment(int commentID, bool adminDel)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                //// when an admin deletes the comment
                if (adminDel)
                {
                    OracleCommand cmd = new OracleCommand("UPDATE \"Comment\" SET \"Text\" = 'Administrator heeft reactie verwijderd.' WHERE \"ID\" = :A");
                    cmd.Parameters.Add(new OracleParameter("A", commentID));
                    cmd.Connection = c;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                    c.Close();
                    return true;
                }
                else
                {
                    //// when a user deletes the comment
                    OracleCommand cmd = new OracleCommand("UPDATE \"Comment\" SET \"Text\" = 'Gebruiker heeft reactie verwijderd.' WHERE \"ID\" = :A");
                    cmd.Parameters.Add(new OracleParameter("A", commentID));
                    cmd.Connection = c;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                    c.Close();
                    return true;
                }
            }
        }

        #endregion

        #region User

        public static bool InsertUser(string Username, string PassHash, string Email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {

                OracleCommand cmd = new OracleCommand("INSERT INTO \"User\" (\"Username\" ,\"Email\" ,\"PassHash\") VALUES(:un, :em, :ph)");

                cmd.Parameters.Add(new OracleParameter("un", Username));
                cmd.Parameters.Add(new OracleParameter("em", Email));
                cmd.Parameters.Add(new OracleParameter("ph", PassHash));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        public static bool UpdateUser(string Username, string PassHash, string Email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"User\" SET \"Email\" = :em \"PassHash\" = :ph WHERE \"Username\" = :un");

                cmd.Parameters.Add(new OracleParameter("em", Email));
                cmd.Parameters.Add(new OracleParameter("ph", PassHash));
                cmd.Parameters.Add(new OracleParameter("un", Username));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        public static bool DeactivateUser(string Username)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"User\" SET \"PassHash\" = '0' WHERE \"Username\" = :un");

                cmd.Parameters.Add(new OracleParameter("un", Username));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion

        #region Image

        public static bool InsertImage(int USER_ID, string URL, string Description)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Image\" (\"USER_ID\", \"URL\", \"Description\") VALUES (:UI, :URL, :DC)");
                cmd.Parameters.Add(new OracleParameter("UI", USER_ID));
                cmd.Parameters.Add(new OracleParameter("URL", URL));
                cmd.Parameters.Add(new OracleParameter("DC", Description));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        public static bool InsertImage(int USER_ID, string URL)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Image\" (\"USER_ID\", \"URL\") VALUES (:UI, :URL)");
                cmd.Parameters.Add(new OracleParameter("UI", USER_ID));
                cmd.Parameters.Add(new OracleParameter("URL", URL));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        public static bool DeleteImage(int ID, string URL)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Image\" WHERE \"ID\" = :ID AND  \"URL\" = :URL");

                cmd.Parameters.Add(new OracleParameter("ID", ID));
                cmd.Parameters.Add(new OracleParameter("URL", URL));

                OracleCommand cmd2 = new OracleCommand("DELETE FROM \"Comment\" WHERE \"IMAGE_ID\" = :ID");
                cmd2.Parameters.Add(new OracleParameter("ID", ID));

                OracleCommand cmd3 = new OracleCommand("DELETE FROM \"Image_Tag\" WHERE \"IMAGE_ID\" = :ID");
                cmd3.Parameters.Add(new OracleParameter("ID", ID));

                OracleCommand cmd4 = new OracleCommand("DELETE FROM \"Favourite\" WHERE \"IMAGE_ID\" = :ID");
                cmd4.Parameters.Add(new OracleParameter("ID", ID));

                cmd.Connection = cmd2.Connection = cmd3.Connection = cmd4.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        #endregion

        #region Tag

        public static bool InsertTag(string Tag)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Tag\" (\"Name\") VALUES (:TAG)");
                cmd.Parameters.Add(new OracleParameter("TAG", Tag));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion

        #region ImageTag

        public static bool InsertImageTag(string Tag, int IMG_ID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Image_Tag\" (\"IMAGE_ID\", \"TAG\") VALUES (:ID, :TAG)");
                cmd.Parameters.Add(new OracleParameter("ID", IMG_ID));
                cmd.Parameters.Add(new OracleParameter("TAG", Tag));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        public static bool DeleteImageTag(int ID, string Tag)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Image_Tag\" WHERE \"IMAGE_ID\" = :ID AND \"TAG\" = :TAG");
                cmd.Parameters.Add(new OracleParameter("ID", ID));
                cmd.Parameters.Add(new OracleParameter("TAG", Tag));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion

        #region Favourite

        public static bool InsertFavourite(int User_ID, int IMG_ID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Favourite\" (\"USER_ID\", \"IMAGE_ID\") VALUES (:UI, :II)");
                cmd.Parameters.Add(new OracleParameter("UI", User_ID));
                cmd.Parameters.Add(new OracleParameter("II", IMG_ID));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        public static bool DeleteFavourite(int User_ID, int IMG_ID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Favourite\" WHERE \"User_ID\" = :UI AND \"IMAGE_ID\" = :II");
                cmd.Parameters.Add(new OracleParameter("UI", User_ID));
                cmd.Parameters.Add(new OracleParameter("II", IMG_ID));

                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion


    }
}
