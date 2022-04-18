using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;

namespace FrontEnd_GameLayout.ViewModels
{
    public class MainMenuViewModel :BaseViewModel, IPageViewModel
    {
        private ICommand _goToRoomScreen;

        public ICommand GoToRoomScreen
        {
            get
            {
                return _goToRoomScreen ?? (_goToRoomScreen = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToRoomScreen", "");
                }));
            }
        }
    }
}

