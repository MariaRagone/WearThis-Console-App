using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearThis_Console_App
{
    internal class Clothing //parent class
    {
        //properties
        public string Color { get; set; }
        public bool HasPattern { get; set; }
        public string Category { get; set; } //casual, dressy, business casual, business, party

        //contstructor
        //assigns all of the properties
        public Clothing() //the defaults
        {
            Color = "";
            HasPattern = false;
            Category = ""; //casual, dressy, business casual, business
        }

        public Clothing(string _color, bool _hasPattern, string _category)
        {
            Color = _color;
            HasPattern = _hasPattern;
            Category = _category;
        }

        //methods
        //virtual methods can be overwritten
        public override string ToString()
        {
            return String.Format("{0,20} {1,20} {2,20}", Color, HasPattern, Category);
        }

    }
}
