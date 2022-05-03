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
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;

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

        #region Map visibility

        private Visibility room_2_Visibility = Visibility.Hidden;
        public Visibility Room_2_Visibility
        {
            get { return room_2_Visibility; }
            set
            {
                room_2_Visibility = value;
            }
        }

        private Visibility room_3_Visibility = Visibility.Hidden;
        public Visibility Room_3_Visibility
        {
            get { return room_3_Visibility; }
            set
            {
                room_3_Visibility = value;
            }
        }

        private Visibility room_4_Visibility = Visibility.Hidden;
        public Visibility Room_4_Visibility
        {
            get { return room_4_Visibility; }
            set
            {
                room_4_Visibility = value;
            }
        }


        private Visibility room_5_Visibility = Visibility.Hidden;
        public Visibility Room_5_Visibility
        {
            get { return room_5_Visibility; }
            set
            {
                room_5_Visibility = value;
            }
        }


        private Visibility room_6_Visibility = Visibility.Hidden;
        public Visibility Room_6_Visibility
        {
            get { return room_6_Visibility; }
            set
            {
                room_6_Visibility = value;
            }
        }


        private Visibility room_7_Visibility = Visibility.Hidden;
        public Visibility Room_7_Visibility
        {
            get { return room_7_Visibility; }
            set
            {
                room_7_Visibility = value;
            }
        }


        private Visibility room_8_Visibility = Visibility.Hidden;
        public Visibility Room_8_Visibility
        {
            get { return room_8_Visibility; }
            set
            {
                room_8_Visibility = value;
            }
        }


        private Visibility room_9_Visibility = Visibility.Hidden;
        public Visibility Room_9_Visibility
        {
            get { return room_9_Visibility; }
            set
            {
                room_9_Visibility = value;
            }
        }


        private Visibility room_10_Visibility = Visibility.Hidden;
        public Visibility Room_10_Visibility
        {
            get { return room_10_Visibility; }
            set
            {
                room_10_Visibility = value;
            }
        }


        private Visibility room_11_Visibility = Visibility.Hidden;
        public Visibility Room_11_Visibility
        {
            get { return room_11_Visibility; }
            set
            {
                room_11_Visibility = value;
            }
        }


        private Visibility room_12_Visibility = Visibility.Hidden;
        public Visibility Room_12_Visibility
        {
            get { return room_12_Visibility; }
            set
            {
                room_12_Visibility = value;
            }
        }


        private Visibility room_13_Visibility = Visibility.Hidden;
        public Visibility Room_13_Visibility
        {
            get { return room_13_Visibility; }
            set
            {
                room_13_Visibility = value;
            }
        }


        private Visibility room_14_Visibility = Visibility.Hidden;
        public Visibility Room_14_Visibility
        {
            get { return room_14_Visibility; }
            set
            {
                room_14_Visibility = value;
            }
        }


        private Visibility room_15_Visibility = Visibility.Hidden;
        public Visibility Room_15_Visibility
        {
            get { return room_15_Visibility; }
            set
            {
                room_15_Visibility = value;
            }
        }


        private Visibility room_16_Visibility = Visibility.Hidden;
        public Visibility Room_16_Visibility
        {
            get { return room_16_Visibility; }
            set
            {
                room_16_Visibility = value;
            }
        }


        private Visibility room_17_Visibility = Visibility.Hidden;
        public Visibility Room_17_Visibility
        {
            get { return room_17_Visibility; }
            set
            {
                room_17_Visibility = value;
            }
        }


        private Visibility room_18_Visibility = Visibility.Hidden;
        public Visibility Room_18_Visibility
        {
            get { return room_18_Visibility; }
            set
            {
                room_18_Visibility = value;
            }
        }


        private Visibility room_19_Visibility = Visibility.Hidden;
        public Visibility Room_19_Visibility
        {
            get { return room_19_Visibility; }
            set
            {
                room_19_Visibility = value;
            }
        }


        private Visibility room_20_Visibility = Visibility.Hidden;
        public Visibility Room_20_Visibility
        {
            get { return room_20_Visibility; }
            set
            {
                room_20_Visibility = value;
            }
        }

        #endregion

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
            var RoomView = new Views.Room();
            MovePlayerOnMap(RoomView);
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
                    Room_2_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_2_Visibility");
                    break;
                case 3:
                    PlayerRow = 3;
                    PlayerColumn = 2;
                    Room_3_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_3_Visibility");
                    break;
                case 4: 
                    PlayerRow = 2;
                    playerColumn = 2;
                    Room_4_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_4_Visibility");
                    break;
                case 5:
                    PlayerRow = 4;
                    playerColumn = 2;
                    Room_5_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_5_Visibility");
                    break;
                case 6:
                    PlayerRow = 4;
                    playerColumn = 1;
                    Room_6_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_6_Visibility");
                    break;
                case 7:
                    PlayerRow = 5;
                    playerColumn = 1;
                    Room_7_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_7_Visibility");
                    break;
                case 8:
                    PlayerRow = 1;
                    playerColumn = 2;
                    Room_8_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_8_Visibility");
                    break;
                case 9:
                    PlayerRow = 1;
                    playerColumn = 3;
                    Room_9_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_9_Visibility");
                    break;
                case 10:
                    PlayerRow = 1;
                    playerColumn = 4;
                    Room_10_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_10_Visibility");
                    break;
                case 11:
                    PlayerRow = 2;
                    playerColumn = 4;
                    Room_11_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_11_Visibility");
                    break;
                case 12:
                    PlayerRow = 2;
                    playerColumn = 5;
                    Room_12_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_12_Visibility");
                    break;
                case 13:
                    PlayerRow = 2;
                    playerColumn = 3;
                    Room_13_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_13_Visibility");
                    break;
                case 14:
                    PlayerRow = 3;
                    playerColumn = 3;
                    Room_14_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_14_Visibility");
                    break;
                case 15:
                    PlayerRow = 3;
                    playerColumn = 4;
                    Room_15_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_15_Visibility");
                    break;
                case 16:
                    PlayerRow = 4;
                    playerColumn = 4;
                    Room_16_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_16_Visibility");
                    break;
                case 17:
                    PlayerRow = 4;
                    playerColumn = 5;
                    Room_17_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_17_Visibility");
                    break;
                case 18:
                    PlayerRow = 4;
                    playerColumn = 3;
                    Room_18_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_18_Visibility");
                    break;
                case 19:
                    PlayerRow = 5;
                    playerColumn = 3;
                    Room_19_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_19_Visibility");
                    break;
                case 20:
                    PlayerRow = 5;
                    playerColumn = 4;
                    Room_20_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_20_Visibility");
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
            GameController.Instance.Savegame();
        }
        bool CanExecuteInteractCommand(string direction)
        {
            return true;
        }

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
        