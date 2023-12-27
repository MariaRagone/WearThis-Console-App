using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WearThis_Console_App
{
    internal class Bottom : Clothing //this is a child class of the type outfit
    {
        //properties
        //all of the partent properties come down to the child (color, hasPattern, category)
        public string fit { get; set; } //skinny, straight, boot, A-line, shift
        public string length { get; set; }   //mini, short, medium, ankle, long
        public string type { get; set; }  //dress, jeans, pants, shorts, skirts
        //constructors
        public Bottom (string _color, bool _hasPattern, string _category, string _fit, string _length, string _type)
            : base //relates back to parent constructor, defines what part of the constructor is the parent
            (_color, _hasPattern, _category)
        {
            fit = _fit;
            length = _length;
            type = _type;

        }

        //methods
        //public void GetOutfit
        public override string MakeOutfit(string color, bool hasPattern, string category)
        {
            base.MakeOutfit(color, hasPattern, category);
            return color;

        }

    }
}
