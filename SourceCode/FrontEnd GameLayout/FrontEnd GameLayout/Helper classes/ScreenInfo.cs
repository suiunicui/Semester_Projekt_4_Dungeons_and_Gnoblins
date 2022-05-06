using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd_GameLayout.Helper_classes
{
    public class ScreenInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string LastScreen { get; set; }
        public int UselessSlider { get; set; }

        private static volatile ScreenInfo instance;

        public ScreenInfo()
        {
            Width = 1920;
            Height = 1080;
            LastScreen = "MainMenu";
            UselessSlider = 0;
        }
        public static ScreenInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenInfo();
                }
                return instance;
            }
        }
    }
}
