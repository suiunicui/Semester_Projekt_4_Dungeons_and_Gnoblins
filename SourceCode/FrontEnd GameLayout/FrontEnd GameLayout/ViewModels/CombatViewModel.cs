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
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using GameEngine.Implementations;
using GameEngine.Interfaces;

namespace FrontEnd_GameLayout.ViewModels
{
    
    public class CombatViewModel : BaseViewModel, IPageViewModel
    {

        IGameController game = GameController.Instance;
        ScreenInfo Res = ScreenInfo.Instance;
        
        public CombatViewModel()
        {
            Description = "Fight!!";//= game.CurrentLocation.Description;
            if(game.CurrentLocation.Enemy != null) {
                CombatLog = "You face a" + game.CurrentLocation.Enemy.Id + "\n"; //Make it a name...
                CombatLog += "You have " + game.CurrentLocation.Player.HP + " hitpoint left. \n";
                CombatLog += "The enemy has " + game.CurrentLocation.Enemy.HP + " hitpoints \n";
            }
            loadMap();
            MovePlayerOnMap();
            Window_Height = Res.Height;
            Window_Width = Res.Width;
        }

        #region Properties


        static int window_Width=1920;
        public int Window_Width
        {
            get { return window_Width; }
            set 
            { 
                window_Width = value;
                OnPropertyChanged("Window_Width");
            }
        }

        static int window_Height=1080;
        public int Window_Height
        {
            get { return window_Height; }
            set
            {
                window_Height = value;
                OnPropertyChanged("Window_Height");
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

        private string _combatLog;
        public string CombatLog
        {
            get { return _combatLog; }
            set
            {
                if (value != _combatLog)
                {
                    _combatLog = value;
                    OnPropertyChanged("CombatLog");
                }
            }
        }

        private ILog log;

        public ILog Log
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

        void checkIfRoomIsNew()
        {
            bool RoomIsNew = true;
            foreach (uint room in game.VisitedRooms)
            {
                if (room == game.CurrentLocation.Id)
                {
                    RoomIsNew = false;
                }
            }
            if (RoomIsNew)
            {
                game.VisitedRooms.Add(game.CurrentLocation.Id);
            }
        }

        void loadMap()
        {
            foreach (uint id in game.VisitedRooms)
            {
                switch (id + 1)
                {
                    case 1:
                        break;
                    case 2:
                        Room_2_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_2_Visibility");
                        break;
                    case 3:
                        Room_3_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_3_Visibility");
                        break;
                    case 4:
                        Room_4_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_4_Visibility");
                        break;
                    case 5:
                        Room_5_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_5_Visibility");
                        break;
                    case 6:
                        Room_6_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_6_Visibility");
                        break;
                    case 7:
                        Room_7_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_7_Visibility");
                        break;
                    case 8:
                        Room_8_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_8_Visibility");
                        break;
                    case 9:
                        Room_9_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_9_Visibility");
                        break;
                    case 10:
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
                        Room_12_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_12_Visibility");
                        break;
                    case 13:
                        Room_13_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_13_Visibility");
                        break;
                    case 14:
                        Room_14_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_14_Visibility");
                        break;
                    case 15:
                        Room_15_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_15_Visibility");
                        break;
                    case 16:
                        Room_16_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_16_Visibility");
                        break;
                    case 17:
                        Room_17_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_17_Visibility");
                        break;
                    case 18:
                        Room_18_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_18_Visibility");
                        break;
                    case 19:
                        Room_19_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_19_Visibility");
                        break;
                    case 20:
                        Room_20_Visibility = Visibility.Visible;
                        OnPropertyChanged("Room_20_Visibility");
                        break;
                }
            }
        }

        void MovePlayerOnMap(Views.Room Room = null)
        {

            switch (game.CurrentLocation.Id + 1)
            {
                case 1:
                    PlayerRow = 4;
                    PlayerColumn = 2;
                    break;
                case 2:
                    PlayerRow = 6;
                    PlayerColumn = 2;
                    Room_2_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_2_Visibility");
                    break;
                case 3:
                    PlayerRow = 6;
                    PlayerColumn = 4;
                    Room_3_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_3_Visibility");
                    break;
                case 4:
                    PlayerRow = 4;
                    playerColumn = 4;
                    Room_4_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_4_Visibility");
                    break;
                case 5:
                    PlayerRow = 8;
                    playerColumn = 4;
                    Room_5_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_5_Visibility");
                    break;
                case 6:
                    PlayerRow = 8;
                    playerColumn = 2;
                    Room_6_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_6_Visibility");
                    break;
                case 7:
                    PlayerRow = 10;
                    playerColumn = 2;
                    Room_7_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_7_Visibility");
                    break;
                case 8:
                    PlayerRow = 2;
                    playerColumn = 4;
                    Room_8_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_8_Visibility");
                    break;
                case 9:
                    PlayerRow = 2;
                    playerColumn = 6;
                    Room_9_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_9_Visibility");
                    break;
                case 10:
                    PlayerRow = 2;
                    playerColumn = 8;
                    Room_10_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_10_Visibility");
                    break;
                case 11:
                    PlayerRow = 4;
                    playerColumn = 8;
                    Room_11_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_11_Visibility");
                    break;
                case 12:
                    PlayerRow = 4;
                    playerColumn = 10;
                    Room_12_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_12_Visibility");
                    break;
                case 13:
                    PlayerRow = 4;
                    playerColumn = 6;
                    Room_13_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_13_Visibility");
                    break;
                case 14:
                    PlayerRow = 6;
                    playerColumn = 6;
                    Room_14_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_14_Visibility");
                    break;
                case 15:
                    PlayerRow = 6;
                    playerColumn = 8;
                    Room_15_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_15_Visibility");
                    break;
                case 16:
                    PlayerRow = 8;
                    playerColumn = 8;
                    Room_16_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_16_Visibility");
                    break;
                case 17:
                    PlayerRow = 8;
                    playerColumn = 10;
                    Room_17_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_17_Visibility");
                    break;
                case 18:
                    PlayerRow = 8;
                    playerColumn = 6;
                    Room_18_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_18_Visibility");
                    break;
                case 19:
                    PlayerRow = 10;
                    playerColumn = 6;
                    Room_19_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_19_Visibility");
                    break;
                case 20:
                    PlayerRow = 10;
                    playerColumn = 8;
                    Room_20_Visibility = Visibility.Visible;
                    OnPropertyChanged("Room_20_Visibility");
                    break;

            }

            OnPropertyChanged("PlayerRow");
            OnPropertyChanged("PlayerColumn");
        }
        #endregion

        #region Commands




        private DelegateCommand _fightCommand;
        public DelegateCommand FightCommand =>
        _fightCommand ?? (_fightCommand = new DelegateCommand(ExecuteFightCommand, CanExecuteFightCommand));
        void ExecuteFightCommand()
        {
            Player tPlayer = game.CurrentLocation.Player;
            Enemy tEnemy = game.CurrentLocation.Enemy;

            log = game.CombatController.EngageCombat(ref tPlayer, ref tEnemy);

            game.CurrentLocation.Player = tPlayer;
            game.CurrentLocation.Enemy = tEnemy;

            CombatLog = "You face a " + game.CurrentLocation.Enemy.Id + "\n"; //Make it a name...
            

            if (game.CombatController.CombatIsOver)
            {
                if(game.CurrentLocation.Enemy.HP == 0)
                {
                    CombatLog = log.GetRecord("Enemy Status");
                    Mediator.Notify("GameStart", "");
                }
                else if(game.CurrentLocation.Player.HP == 0)
                {
                    CombatLog = log.GetRecord("Player Status");
                    Mediator.Notify("GoToMainMenu", "");
                }
            }
            else
            {
                CombatLog += log.GetRecord("player attack") + " \n";
                if(log.GetRecord("player attack") != "Your attack missed, dealing 0 damage to the enemy.") 
                {
                    CombatLog += log.GetRecord("player damage") + " \n";
                }
                CombatLog += log.GetRecord("enemy attack") + " \n";
                if (log.GetRecord("enemy attack") != "The enemy's attack missed, dealing 0 damage to you.")
                {
                    CombatLog += log.GetRecord("enemy damage") + " \n";
                }
            }

            CombatLog += "You have " + game.CurrentLocation.Player.HP + " hitpoint left. \n";
            CombatLog += "The enemy has " + game.CurrentLocation.Enemy.HP + " hitpoints \n";
        }
        bool CanExecuteFightCommand()
        {
            return true;
        }

        private DelegateCommand _fleeCommand;
        public DelegateCommand FleeCommand =>
        _fleeCommand ?? (_fleeCommand = new DelegateCommand(ExecuteFleeCommand, CanExecuteFleeCommand));
        void ExecuteFleeCommand()
        {
            game.CombatController.Flee();
            Mediator.Notify("GameStart", "");
        }
        bool CanExecuteFleeCommand()
        {
            return true;
        }

        private ICommand _gameMenu;

        public ICommand GameMenu
        {
            get
            {
                return _gameMenu ?? (_gameMenu = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToInGameMenu", "");
                }));
            }
        }

        #endregion

    }
}
        