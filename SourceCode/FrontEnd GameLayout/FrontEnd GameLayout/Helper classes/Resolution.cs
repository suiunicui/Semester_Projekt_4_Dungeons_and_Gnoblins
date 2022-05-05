using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd_GameLayout.Helper_classes
{
    public class Resolution
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private static volatile Resolution instance;

        public Resolution()
        {
            Width = 1920;
            Height = 1080;
        }
        public static Resolution Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Resolution();
                }
                return instance;
            }
        }
    }
}
