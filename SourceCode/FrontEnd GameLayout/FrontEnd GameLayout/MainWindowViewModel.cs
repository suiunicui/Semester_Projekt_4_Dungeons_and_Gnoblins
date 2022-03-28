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

namespace FrontEnd_GameLayout
{
    public class MainWindowViewModel : BindableBase
    {

        GameController game = new GameController();

        public MainWindowViewModel()
        {
           
        }

        #region Properties

        public string Description = "Test text";
       
        #endregion
        
        #region Methods


        #endregion

        #region Commands

        private DelegateCommand _moveCommand;
        public DelegateCommand MoveCommand =>
        _moveCommand ?? (_moveCommand = new DelegateCommand(ExecuteMoveCommand, CanExecuteMoveCommand));
        void ExecuteMoveCommand()
        {
            Description = game.Move("north");
        }
        bool CanExecuteMoveCommand()
        { 
            return true;
        }

        
        #endregion

    }
}
        