using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using Prism.Commands;
using GameEngine.Implementations;
using GameEngine.Interfaces;

namespace FrontEnd_GameLayout.ViewModels
{
    public class OptionsViewModel : BaseViewModel, IPageViewModel
    {

        IGameController game = GameController.Instance;
        ScreenInfo Res = ScreenInfo.Instance;
        
        public List<Resolution> Resolutions { get; set; } = new List<Resolution>();

        public OptionsViewModel()
        {
            Window_Width = Res.Width;
            Window_Height = Res.Height;
            SliderVal = Res.UselessSlider;
            VolumeSliderVal = Res.Volume;
            Resolutions.Add(new Resolution(1080, 1920));
            Resolutions.Add(new Resolution(720, 1280));
            if(Window_Height == 1080)
            {
                ChosenResolution = Resolutions[0];
            }
            else
            {
                ChosenResolution = Resolutions[1];
            }

        }

        #region Properties

        Resolution _chosenResolution;

        public Resolution ChosenResolution
        {
            get { return _chosenResolution; }
            set
            {
                _chosenResolution = value;
                OnPropertyChanged("ChosenResolution");
            }
        }


        int _sliderVal;

        public int SliderVal
        {
            get { return _sliderVal; }
            set 
            { 
                _sliderVal = value;
                OnPropertyChanged("SliderVal");
            }
        }

        bool _musicPlaying = true;

        public bool MusicPlaying
        {
            get { return _musicPlaying; }
            set
            {
                _musicPlaying = value;
                Res.MusicPlaying = value;
                Res.Toggle_Music();
            }
        }

        double _volumeSliderVal;

        public double VolumeSliderVal 
        { 
            get { return _volumeSliderVal; }
            set
            {
                _volumeSliderVal = value;
                Res.Volume = value;
                OnPropertyChanged("VolumeSliderVal");
            }
        }

        int _chosenWindowHeight;

        public int ChoosenWindowHeight
        {
            get { return _chosenWindowHeight; }
            set
            {
                _chosenWindowHeight = value;
                OnPropertyChanged("ChoosenWindowHeight");
            }
        }

        int _chosenWindowWidth;

        public int ChoosenWindowWidth
        {
            get { return _chosenWindowWidth; }
            set
            {
                _chosenWindowWidth = value;
                OnPropertyChanged("ChoosenWindowHeight");
            }
        }


        static int window_Width;
        public int Window_Width
        {
            get { return window_Width; }
            set
            {
                window_Width = value;
                OnPropertyChanged("Window_Width");
            }
        }

        static int window_Height = 1080;
        public int Window_Height
        {
            get { return window_Height; }
            set
            {
                window_Height = value;
                OnPropertyChanged("Window_Height");
            }
        }
        #endregion

        #region Methods

        void saveSettings()
        {
            Res.UselessSlider = SliderVal;
            Res.Width = ChosenResolution.Width;
            Res.Height = ChosenResolution.Height;
        }

        #endregion

        #region Commands

        private ICommand _applyCommand;

        public ICommand ApplyCommand
        {
            get
            {
                return _applyCommand ?? (_applyCommand = new RelayCommand(x =>
                {
                    saveSettings(); 
                    Window_Width = Res.Width;
                    Window_Height = Res.Height;
                }));
            }
        }

        private ICommand _resetSettings;

        public ICommand ResetSettings
        {
            get
            {
                return _resetSettings ?? (_resetSettings = new RelayCommand(x =>
                {
                    //Mediator.Notify("", "");
                }));
            }
        }

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(x =>
                {
                    if (Res.LastScreen == "InGameMenu")
                    {
                        Mediator.Notify("GoToInGameMenu", "");
                    }
                    else
                    {
                        Mediator.Notify("GoToMainMenu", "");
                    }

                }));


            }
        }

        #endregion
    }
}

