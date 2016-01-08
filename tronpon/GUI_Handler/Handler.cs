using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tronpon_Classes;
using Database_Layer;

namespace GUI_Handler
{
    public class Handler
    {
        public static List<string> GetContent(int max, int min)
        {
            return Tronpon_Classes.Image.LoadPageContent(max, min).Select(i => i.URL).ToList();
        }

        public static bool NewUser(string username, string email, string password)
        {//TODO
            //if(string.IsNullOrEmpty())
            return false;
        }
    }
}
