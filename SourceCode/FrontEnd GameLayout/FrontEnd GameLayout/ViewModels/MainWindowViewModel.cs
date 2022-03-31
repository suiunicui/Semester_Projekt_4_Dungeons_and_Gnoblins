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

namespace FrontEnd_GameLayout.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

       GameController game = new GameController();

        public MainWindowViewModel()
        {
            Description = "";
        }

        #region Properties

        private string description;

        public string Description 
        { 
            get { return description; } 
            set { SetProperty(ref description, value); }
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
            Description = game.Move(direction);
        }
        bool CanExecuteMoveCommand(string direction)
        { 
            return true;
        }

        
        #endregion

    }
}
        