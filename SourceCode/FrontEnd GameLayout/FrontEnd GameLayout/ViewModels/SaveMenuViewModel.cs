using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using GameEngineLibrary;
using Backend_API.Models.DTO;
using Backend_API;
using TestHttpClient;
using Prism.Commands;

namespace FrontEnd_GameLayout.ViewModels
{
    public class SaveMenuViewModel :BaseViewModel, IPageViewModel
    {
        public SaveMenuViewModel()
        {  
            getListOfSaves();
        }


        private async void getListOfSaves()
        {
            HttpController httpHandler = new HttpController();
            SavedGames = await httpHandler.GetListOfSave();
        }


        #region Properties

        private List<SaveDTO> _savedGames = new List<SaveDTO>();

        public List<SaveDTO> SavedGames {
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

        

        private SaveDTO _selectedSave;

        public SaveDTO SelectedSave
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

        private DelegateCommand _loadGame;
        
        public DelegateCommand LoadGame => _loadGame ?? (_loadGame = new DelegateCommand(ExecuteLoadCommand, CanExecuteLoadCommand));

        async void ExecuteLoadCommand()
        {
            await GameController.Instance.LoadGame(SelectedSave.ID);
            Mediator.Notify("GameStart", "");
        }

        bool CanExecuteLoadCommand()
        {
            return true;
        }

        #endregion
    }
}
