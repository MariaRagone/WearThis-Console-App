using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WearThis_Console_App
{
    internal class Top : Outfit //this is a child class of the type outfit
    {
        //properties
        //all of the partent properties come down to the child (color, hasPattern, category)
        public string sleeveLength { get; set; } //strapless, tank, cap, short, 3/4, long
        public string fit { get; set; } //fitted, loose
        public string length { get; set; } //short,medium, long
        public string type { get; set; } //blouse, cardigan, collared, sweater, tank, t-shirt

        //constructors
        public Top(string _color, bool _hasPattern, string _category, string _sleeveLength,  string _fit, string _length, string _type)
            : base //relates back to parent constructor, defines what part of the constructor is the parent
            (_color, _hasPattern, _category)
        {
            sleeveLength = _sleeveLength;
            fit = _fit;
            length = _length;
            type = _type;

        }

        //methods
    }
}
