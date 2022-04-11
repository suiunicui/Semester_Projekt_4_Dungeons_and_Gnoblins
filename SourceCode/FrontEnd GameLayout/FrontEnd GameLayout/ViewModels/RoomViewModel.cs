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

       GameController game = new GameController();

        public RoomViewModel()
        {
        }

        #region Properties

        public string Name
        {
            get
            {
                return "Room";
            }
        }


        private int playerRow = 2;
        public int PlayerRow
        {
            get { return playerRow; }
            set { playerRow = value;
            }
        }

        private int playerColumn = 1;
        public int PlayerColumn
        {
            get { return playerColumn; }
            set
            {
                playerColumn = value;
            }
        }


        private string description = "Hello i am test";

        public string Description 
        { 
            get { return description; } 
            set
            {
                if (value != description)
                {
                    description = value;
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
            Description = Log.GetEventRecord("New Room Description");
        }
        bool CanExecuteMoveCommand(string direction)
        { 
            return true;
        }


        private DelegateCommand<string> _interactCommand;
        public DelegateCommand<string> InteractCommand =>
        _interactCommand ?? (_interactCommand = new DelegateCommand<string>(ExecuteInteractCommand, CanExecuteInteractCommand));
        void ExecuteInteractCommand(string direction)
        {
            PlayerRow = 3;
            PlayerColumn = 1;
            OnPropertyChanged("PlayerRow");
            OnPropertyChanged("PlayerColumn");
        }
        bool CanExecuteInteractCommand(string direction)
        {
            return true;
        }

        #endregion

    }
}
        