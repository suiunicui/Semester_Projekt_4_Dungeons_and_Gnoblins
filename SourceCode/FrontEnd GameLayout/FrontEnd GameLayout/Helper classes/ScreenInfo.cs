using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FrontEnd_GameLayout.Helper_classes
{
    public class ScreenInfo
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string LastScreen { get; set; }
        public int UselessSlider { get; set; }
        public bool MusicPlaying { get; set; } = true;
        private TimeSpan timeSpan { get; set; } = TimeSpan.Zero;
        private MediaPlayer MusicBot { get; set; }
        public double Volume 
        { 
            get { return MusicBot.Volume; }
            set { MusicBot.Volume = value; }
        }

        private static volatile ScreenInfo instance;


        public ScreenInfo()
        {
            MusicBot = new MediaPlayer();
            //Start the MusicPlayer With the file located in bin/debug/net6.0 or bin/release/net6.0
            MusicBot.Open(new Uri(String.Format("{0}\\Music\\Music.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            //Set up event for loop music
            MusicBot.MediaEnded += new EventHandler(Media_Ended);
            MusicBot.Volume = 0.10;

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

        public void Toggle_Music()
        {
            if (MusicPlaying)
            {
                MusicBot.Position = timeSpan;
                MusicBot.Play();
            }
            else
            {
                timeSpan = MusicBot.Position;
                MusicBot.Stop();
            }
        }


        // makes the musicBot loop around when it ends
        private void Media_Ended(object sender, EventArgs e)
        {
            if (MusicPlaying == true)
            {
                MusicBot.Position = TimeSpan.Zero;
                MusicBot.Play();
            }

        }

    }
}
