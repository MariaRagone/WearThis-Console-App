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
        public string Fit { get; set; } //skinny, straight, boot, A-line, shift
        public string Length { get; set; } //mini, short, medium, ankle, long
        public string Type { get; set; } //dress, jeans, pants, shorts, skirts

        //constructors
        public Bottom(string _color, bool _hasPattern, string _category, string _fit, string _length, string _type)
            : base //relates back to parent constructor, defines what part of the constructor is the parent
            (_color, _hasPattern, _category)

        {//these are the new properties for BOTTOMS
            Fit = _fit;
            Length = _length;
            Type = _type;
        }

        //methods
        //public void GetOutfit
        public override string ToString() //overrides the parent
        {
            return base.ToString() + String.Format("{0,10}, {1,10}, {2,10}", Fit, Length, Type); //ToString()
        }

    }
}
