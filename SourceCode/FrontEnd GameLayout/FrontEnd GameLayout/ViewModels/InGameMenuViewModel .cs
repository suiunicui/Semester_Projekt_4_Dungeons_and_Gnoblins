﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using Prism.Commands;
using GameEngine.Interfaces;
using GameEngine.Implementations;

namespace FrontEnd_GameLayout.ViewModels
{
    public class InGameMenuViewModel :BaseViewModel, IPageViewModel
    {

        IGameController game = GameController.Instance;
        Resolution Res = Resolution.Instance;

        public InGameMenuViewModel()
        {
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
        private ICommand _gameStart;

        public ICommand GameStart
        {
            get
            {
                return _gameStart ?? (_gameStart = new RelayCommand(x =>
                {
                    Mediator.Notify("GameStart","");
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

        private ICommand _mainMenu;

        public ICommand MainMenu
        {
            get
            {
                return _mainMenu ?? (_mainMenu = new RelayCommand(x =>
                {
                    game.VisitedRooms.Clear();
                    Mediator.Notify("GoToMainMenu", "");
                }));
            }
        }

        private ICommand _saveMenu;

        public ICommand SaveMenu
        {
            get
            {
                return _saveMenu ?? (_saveMenu = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToSaveMenu", "");
                }));
            }
        }
    }
}

