using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using FrontEnd_GameLayout.Helper_classes;
using GameEngineLibrary;

namespace FrontEnd_GameLayout.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        GameController game = GameController.Instance;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

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

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new MainMenuViewModel());
            PageViewModels.Add(new RoomViewModel());
            PageViewModels.Add(new LoadMenuViewModel());
            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("GoToMainMenu", OnGoToMainMenu);
            Mediator.Subscribe("GameStart", OnGameStart);
            Mediator.Subscribe("GoToLoadMenu", OnGoToLoadMenu);
        }
    }
}
