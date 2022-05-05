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
    public class OptionsViewModel :BaseViewModel, IPageViewModel
    {

        IGameController game = GameController.Instance;

        private ICommand _gameStart;

        public ICommand GameStart
        {
            get
            {
                return _gameStart ?? (_gameStart = new RelayCommand(x =>
                {
                    game.CurrentLocation.RemovePlayer();
                    game.CurrentLocation = game.GameMap.Rooms[0];
                    game.GameMap.Rooms[game.CurrentLocation.Id].AddPlayer(game.CurrentPlayer);
                    Mediator.Notify("GameStart","");
                }));
            }
        }

        private ICommand _gameLoad;

        public ICommand LoadMenu
        {
            get
            {
                return _gameLoad ?? (_gameLoad = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoadMenu", "");
                }));
            }
        }

        private DelegateCommand _exitGameCommand;
        public DelegateCommand ExitGameCommand =>
        _exitGameCommand ?? (_exitGameCommand = new DelegateCommand(ExecuteExitGameCommand, CanExecuteExitGameCommand));
        void ExecuteExitGameCommand()
        {
            System.Windows.Application.Current.Shutdown();
        }
        bool CanExecuteExitGameCommand()
        {
            return true;
        }

    }
}

