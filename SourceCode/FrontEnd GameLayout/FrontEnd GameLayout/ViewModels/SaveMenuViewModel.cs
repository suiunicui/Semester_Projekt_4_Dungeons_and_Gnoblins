using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using GameEngine.Models.DTO;
using Prism.Commands;
using GameEngine.Implementations;

namespace FrontEnd_GameLayout.ViewModels
{
    public class SaveMenuViewModel :BaseViewModel, IPageViewModel
    {
        ScreenInfo Res = ScreenInfo.Instance;

        BackEndController backEndController = BackEndController.Instance;

        public SaveMenuViewModel()
        {
            getListOfSaves();
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

        private async void getListOfSaves()
        {
            // Only loads if user is signed in
            if (backEndController.token != null)
            {
                SavedGames = await backEndController.GetListOfSave();
            }
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

        public string SaveName
        {
            get { return SelectedSave.SaveName; }
            set
            {
                if (value != SelectedSave.SaveName)
                {
                    SelectedSave.SaveName = value;
                    OnPropertyChanged("SaveName");
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

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToInGameMenu", "");
                }));
            }
        }

        private DelegateCommand _saveGame;
        
        public DelegateCommand SaveGame => _saveGame ?? (_saveGame = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand));

        async void ExecuteSaveCommand()
        {
            if (SelectedSave != null)
            {
                await GameController.Instance.SaveGame(SelectedSave.ID, SaveName);
                Mediator.Notify("GameStart", "");
            }
        }

        bool CanExecuteSaveCommand()
        {
            return true;
        }

        #endregion
    }
}
