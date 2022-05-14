using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using FrontEnd_GameLayout.Helper_classes;
using GameEngine.Implementations;
using GameEngine.Interfaces;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using FrontEnd_GameLayout.Views;

namespace FrontEnd_GameLayout.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        ScreenInfo Res = ScreenInfo.Instance;
        IGameController game = GameController.Instance;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;


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

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGoToMainMenu(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGameStart(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void OnGoToLoadMenu(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void OnGoToSaveMenu(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void OnGoToInGameMenu(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }
        private void OnGoToSettingsMenu(object obj)
        {
            ChangeViewModel(PageViewModels[5]);
        }

        private void OnGoToRegisterMenu(object obj)
        {
            ChangeViewModel(PageViewModels[6]);
        }

        private void OnGoToLoginMenu(object obj)
        {
            ChangeViewModel(PageViewModels[7]);
        }

        public MainWindowViewModel()
        {
            Res.Toggle_Music();
            //Set Up the resolution of the views
            Window_Height = Res.Height;
            Window_Width = Res.Width;

            // Add available pages and set page
            PageViewModels.Add(new MainMenuViewModel());
            PageViewModels.Add(new RoomViewModel());
            PageViewModels.Add(new LoadMenuViewModel());
            PageViewModels.Add(new SaveMenuViewModel());
            PageViewModels.Add(new InGameMenuViewModel());
            PageViewModels.Add(new OptionsViewModel());
            PageViewModels.Add(new RegisterMenuViewModel());
            PageViewModels.Add(new LoginMenuViewModel());
            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("GoToMainMenu", OnGoToMainMenu);
            Mediator.Subscribe("GameStart", OnGameStart);
            Mediator.Subscribe("GoToLoadMenu", OnGoToLoadMenu);
            Mediator.Subscribe("GoToSaveMenu", OnGoToSaveMenu);
            Mediator.Subscribe("GoToInGameMenu", OnGoToInGameMenu);
            Mediator.Subscribe("GoToSettingsMenu", OnGoToSettingsMenu);
            Mediator.Subscribe("GoToRegisterMenu", OnGoToRegisterMenu);
            Mediator.Subscribe("GoToLoginMenu", OnGoToLoginMenu);

            //game.GetRoomDescriptionAsync();

        }
    }
}
