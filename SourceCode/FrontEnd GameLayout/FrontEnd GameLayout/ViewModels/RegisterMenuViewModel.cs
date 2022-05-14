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
using GameEngine.Models.DTO;

namespace FrontEnd_GameLayout.ViewModels
{

    public class RegisterMenuViewModel : BaseViewModel, IPageViewModel
    {
        BackEndController httpHandler = new BackEndController();
        IGameController game = GameController.Instance;
        ScreenInfo Res = ScreenInfo.Instance;

        public RegisterMenuViewModel()
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



        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginMenu", "");
                }));


            }
        }

        private DelegateCommand _register;

        public DelegateCommand Register => _register ?? (_register = new DelegateCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand));

        async void ExecuteRegisterCommand()
        {
            bool RegistrationSuccessful = true;
            _newUser = new UserDTO()
            {
                Username = _username,
                Password = _password
            };
            
            try
            {
                await httpHandler.PostRegisterAsync(_newUser);
            }
            catch (System.Net.Http.HttpRequestException Exception)
            {
                Password = null;
                RegistrationSuccessful = false;
                ErrorText =
                    "Registration was unsuccessful." +
                    "\nThe username is already in use, please pick another." +
                    "\nThen try again!";
            }
            if (RegistrationSuccessful)
            Mediator.Notify("GoToLoginMenu","");

        }

        bool CanExecuteRegisterCommand()
        {
            return true;
        }


    }
}
