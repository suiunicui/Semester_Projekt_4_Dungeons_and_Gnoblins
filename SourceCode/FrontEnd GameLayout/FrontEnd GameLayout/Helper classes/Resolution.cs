using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd_GameLayout.Helper_classes
{
    public class Resolution
    {
        public int Width { get; }
        public int Height { get; }
        public string Name { get; }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
            Name =Height.ToString() + 'x' + Width.ToString() ;
        }
    }
}
