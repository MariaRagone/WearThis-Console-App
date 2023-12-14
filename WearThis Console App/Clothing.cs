using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearThis_Console_App
{
    public class Outfit
    {
        //PROPERTIES------------------------------------
        public string color { get; set; }
        public bool hasPattern { get; set; }

        //casual, dressy, business casual, business
        public string category { get; set; }

        //CONSTRUCTOR------------------------------------
        public Outfit(string _color, bool _hasPattern, string _category)
        {
            color = _color;
            hasPattern = _hasPattern;
            category = _category;
        }

        //METHODS---------------------------------------
        public void GetOutfit(Top top, Bottom bottom)

        {
            Console.WriteLine($"Your outfit is {top} and {bottom}");
        }
    }

    Top TopPart = new Top();
    Bottom bottomPart = new Bottom(Bottom.color);

    public class Top : Outfit
    {
        //strapless, tank, cap, short, 3/4, long
        public string sleeveLength { get; set; }

        //fitted, loose
        public string fit { get; set; }

        //short,medium, long
        public string length { get; set; }

        //blouse, cardigan, collared, sweater, tank, t-shirt
        public string type { get; set; }
    }

    public class Bottom : Outfit
    {
        //skinny, straight, boot, A-line, shift
        public string fit { get; set; }

        //mini, short, medium, ankle, long
        public string length { get; set; }

        //dress, jeans, pants, shorts, skirts
        public string type { get; set; }
    }


}
