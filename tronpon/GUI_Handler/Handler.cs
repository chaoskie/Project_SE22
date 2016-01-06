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
        public static List<Image> GetContent(int max, int min)
        {
            return Tronpon_Classes.Image.LoadPageContent(max, min);
        }
    }
}
