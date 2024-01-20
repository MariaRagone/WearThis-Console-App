using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearThis_Console_App
{
    internal class SimpleClothing
    {
        public string Type { get; set; } //top, bottom
        public string Name { get; set; } // jeans
        public string Color { get; set; }

        public SimpleClothing(string _type, string _name, string _color)
        {
            Type = _type;
            Name = _color;
            Color = _color;
        }
        public override string ToString()
        {
            return String.Format("{0,10} {1,20}", Type, Name, Color);
        }

    }
}
