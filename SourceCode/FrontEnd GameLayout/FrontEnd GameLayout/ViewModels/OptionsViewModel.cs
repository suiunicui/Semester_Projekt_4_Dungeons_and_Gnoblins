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



        public OptionsViewModel()
        {
            Window_Width = Res.Width;
            Window_Height = Res.Height;
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

        private ICommand _applyCommand;

        public ICommand ApplyCommand
        {
            get
            {
                return _applyCommand ?? (_applyCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToSettingsMenu", "");
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
                    if (ScreenInfo.Instance.LastScreen == "InGameMenu")
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
    }
}

