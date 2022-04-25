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
    public class LoadMenuViewModel :BaseViewModel, IPageViewModel
    {
        public LoadMenuViewModel()
        {
            SavedGames.Add("testGame1");
            SavedGames.Add("testGame2");
            
        }

        #region Properties

        private List<String> _savedGames = new List<string>();

        public List<String> SavedGames {
            get { return _savedGames; }
            set
            {
                if (value != _savedGames)
                {
                    _savedGames = value;
                    OnPropertyChanged("SavedGames");
                }
            }
        }

        

        private String _selectedSave;

        public String SelectedSave
        {
            get { return _selectedSave; }
            set
            {
                if (value != _selectedSave)
                {
                    _selectedSave = value;
                    OnPropertyChanged("SelectedSave");
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _mainMenu;

        public ICommand MainMenu
        {
            get
            {
                return _mainMenu ?? (_mainMenu = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToMainMenu", "");
                }));
            }
        }

        #endregion
    }
}
