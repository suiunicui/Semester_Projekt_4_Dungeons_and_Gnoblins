using FrontEnd_GameLayout.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using GameEngineLibrary;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FrontEnd_GameLayout.ViewModels
{
    public class RoomViewModel : BaseViewModel, IPageViewModel
    {

        GameController game = GameController.Instance;


    public RoomViewModel()
        {
            Description = game.CurrentRoom.Description;
            MovePlayerOnMap();
        }

        #region Properties


        public string Name
        {
            get
            {
                return "Room";
            }
        }


        private int playerRow;
        public int PlayerRow
        {
            get { return playerRow; }
            set { playerRow = value;
            }
        }

        private int playerColumn;
        public int PlayerColumn
        {
            get { return playerColumn; }
            set
            {
                playerColumn = value;
            }
        }


        private string description;

        public string Description 
        { 
            get { return description; } 
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private Log log;

        public Log Log
        {
            get { return log; }
            set
            {
                if (value != log)
                {
                    log = value;
                }
            }
        }

        #endregion

        #region Methods


        #endregion

        #region Commands

        private DelegateCommand<string> _moveCommand;
        public DelegateCommand<string> MoveCommand =>
        _moveCommand ?? (_moveCommand = new DelegateCommand<string>(ExecuteMoveCommand, CanExecuteMoveCommand));
        void ExecuteMoveCommand(string direction)
        {
            Log = new Log();
            Log = game.MovePlayer(game.CurrentRoom, direction);
            //Description = Log.GetEventRecord("New Room Description");
            Description = game.CurrentRoom.Description;
            var Maroom = new Views.Room();
            MovePlayerOnMap(Maroom);
        }
        bool CanExecuteMoveCommand(string direction)
        { 
            
            return true;
        }

        void MovePlayerOnMap(Views.Room Room = null)
        {

            switch (game.CurrentRoom.RoomId + 1)
            {
                case 1:
                    PlayerRow = 2;
                    PlayerColumn = 1;
                    break;
                case 2:
                    PlayerRow = 3;
                    PlayerColumn = 1;
                    break;
                case 3:
                    PlayerRow = 3;
                    PlayerColumn = 2;
                    break;
                case 4:
                    PlayerRow = 2;
                    playerColumn = 2;
                    break;
                case 5:
                    PlayerRow = 4;
                    playerColumn = 2;
                    break;
                case 6:
                    PlayerRow = 4;
                    playerColumn = 1;
                    break;
                case 7:
                    PlayerRow = 5;
                    playerColumn = 1;
                    break;
                case 8:
                    PlayerRow = 1;
                    playerColumn = 2;
                    break;
                case 9:
                    PlayerRow = 1;
                    playerColumn = 3;
                    break;
                case 10:
                    PlayerRow = 1;
                    playerColumn = 4;
                    break;
                case 11:
                    PlayerRow = 2;
                    playerColumn = 4;
                    break;
                case 12:
                    PlayerRow = 2;
                    playerColumn = 5;
                    break;
                case 13:
                    PlayerRow = 2;
                    playerColumn = 3;
                    break;
                case 14:
                    PlayerRow = 3;
                    playerColumn = 3;
                    break;
                case 15:
                    PlayerRow = 3;
                    playerColumn = 4;
                    break;
                case 16:
                    PlayerRow = 4;
                    playerColumn = 4;
                    break;
                case 17:
                    PlayerRow = 4;
                    playerColumn = 5;
                    break;
                case 18:
                    PlayerRow = 4;
                    playerColumn = 3;
                    break;
                case 19:
                    PlayerRow = 5;
                    playerColumn = 3;
                    break;
                case 20:
                    PlayerRow = 5;
                    playerColumn = 4;
                    break;

            }

            OnPropertyChanged("PlayerRow");
            OnPropertyChanged("PlayerColumn");
        }

        private DelegateCommand<string> _interactCommand;
        public DelegateCommand<string> InteractCommand =>
        _interactCommand ?? (_interactCommand = new DelegateCommand<string>(ExecuteInteractCommand, CanExecuteInteractCommand));
        void ExecuteInteractCommand(string direction)
        {
        }
        bool CanExecuteInteractCommand(string direction)
        {
            return true;
        }

        #endregion

    }
}
        