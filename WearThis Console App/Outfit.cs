using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearThis_Console_App
{
    internal class Outfit //parent class
    {
        //properties
        public string color { get; set; }
        public bool hasPattern { get; set; }
        public string category { get; set; } //casual, dressy, business casual, business

        //contstructor
        //assigns all of the properties
        public Outfit(string _color, bool _hasPattern, string _category)
        {
            color = _color;
            hasPattern = _hasPattern;
            category = _category;
        }

        //methods
        //virtual methods can be overwritten

        public virtual string MakeOutfit(string color, bool hasPattern, string category)
        {
            if (hasPattern)
            {
                return $"Your {category} outfit is {color} and it has a pattern";
            }
            else
            {
                return $"Your {category} outfit is {color} and it does not have a pattern";
            }
        }
    }
}
