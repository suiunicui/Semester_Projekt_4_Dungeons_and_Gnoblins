using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using Prism.Commands;
using GameEngine.Implementations;
using GameEngine.Interfaces;
using GameEngine.Models.DTO;

namespace FrontEnd_GameLayout.ViewModels
{
    public class LoginMenuViewModel : BaseViewModel, IPageViewModel
    {
        BackEndController backEndController = BackEndController.Instance;
        IGameController game = GameController.Instance;
        ScreenInfo Res = ScreenInfo.Instance;

        public LoginMenuViewModel()
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

        private UserDTO _newUser;


        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private string _errorText;

        public string ErrorText
        {
            get { return _errorText; }
            set
            {
                if (value != _errorText)
                {
                    _errorText = value;
                    OnPropertyChanged("ErrorText");
                }
            }
        }

        private ICommand _registerScreenCommand;

        public ICommand RegisterScreenCommand
        {
            get
            {
                return _registerScreenCommand ?? (_registerScreenCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToRegisterMenu", "");
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

        private DelegateCommand _login;

        public DelegateCommand Login => _login ?? (_login = new DelegateCommand(ExecuteLoginCommand, CanExecuteLoginCommand));

        async void ExecuteLoginCommand()
        {
            bool LoginSuccessful = true;
            _newUser = new UserDTO()
            {
                Username = _username,
                Password = _password
            };
            try
            {
                await backEndController.PostLoginAsync(_newUser);
            }
            catch (System.Net.Http.HttpRequestException Exception)
            {
                Password = null;
                LoginSuccessful = false;
                ErrorText =
                    "Login was unsuccessful, " +
                    "please ensure you have a valid account " +
                    "\nand that your credentials are in order!" +
                    " Then try again!";
            }
            if (LoginSuccessful)
            Mediator.Notify("GoToMainMenu", "");
        }

        bool CanExecuteLoginCommand()
        {
            return true;
        }
    }
}
