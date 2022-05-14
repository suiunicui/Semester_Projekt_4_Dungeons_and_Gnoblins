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
        ViewInfo Res = ViewInfo.Instance;
        
        public List<Resolution> Resolutions { get; set; } = new List<Resolution>();

        public OptionsViewModel()
        {
            Window_Width = Res.Width;
            Window_Height = Res.Height;
            SliderVal = Res.UselessSlider;
            VolumeSliderVal = Res.Volume;
            Resolutions.Add(new Resolution(2048, 1152));
            Resolutions.Add(new Resolution(1920, 1080));
            Resolutions.Add(new Resolution(1280, 720));


            ChosenResolution = Resolutions[0];
            foreach (Resolution resolution in Resolutions)
            {
                if(resolution.Width == Window_Width)
                {
                    ChosenResolution = resolution;
                }
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

        public bool MusicPlaying
        {
            get { return Res.MusicPlaying; }
            set
            {
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
                    SliderVal = 0;
                    ChosenResolution = Resolutions[1];
                    VolumeSliderVal = 0.5;
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

