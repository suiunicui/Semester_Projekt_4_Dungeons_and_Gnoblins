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

namespace FrontEnd_GameLayout.ViewModels
{
    public class LoadMenuViewModel :BaseViewModel, IPageViewModel
    {
        public LoadMenuViewModel()
        {
            
        }


        private  async void getListOfSaves()
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

        

        private int _selectedSave;

        public int SelectedSave
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

        private ICommand _loadGame;

        public ICommand LoadGame
        {
            get
            {
                return _loadGame ?? (_loadGame = new RelayCommand(x =>
                {
                    GameController.Instance.LoadGame(SelectedSave);
                }));
            }
        }

        #endregion
    }
}
