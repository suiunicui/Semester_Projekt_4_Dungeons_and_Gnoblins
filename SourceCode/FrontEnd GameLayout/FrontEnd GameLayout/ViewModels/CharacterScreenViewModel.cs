using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;
using FrontEnd_GameLayout.Helper_classes;
using GameEngine.Models.DTO;
using Prism.Commands;
using GameEngine.Implementations;
using GameEngine.Abstract_Class;
using GameEngine.Interfaces;

namespace FrontEnd_GameLayout.ViewModels
{
    public class CharacterScreenViewModel : BaseViewModel, IPageViewModel
    {
        ViewInfo Res = ViewInfo.Instance;
        IGameController game = GameController.Instance;

        public CharacterScreenViewModel()
        {
            if (game.CurrentPlayer.EquippedWeapon != null)
            {
                EquippedWeapon = game.CurrentPlayer.EquippedWeapon.ItemType;
            }
            else
            {
                EquippedWeapon = "";
            }
            if (game.CurrentPlayer.EquippedShield != null)
            {
                EquippedShield = game.CurrentPlayer.EquippedShield.ItemType;
            }
            else
            {
                EquippedShield = "";
            }
            PlayerAC = game.CurrentPlayer.AC.ToString();
            PlayerHP = game.CurrentPlayer.HP.ToString();

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


        #region Properties

        private String _equippedWeapon;

        public String EquippedWeapon
        {
            get { return _equippedWeapon; }
            set
            {
                if (value != _equippedWeapon)
                {
                    _equippedWeapon = "Weapon: " + value;
                    OnPropertyChanged("EquippedWeapon");
                }
            }
        }

        private String _equippedShield;

        public String EquippedShield
        {
            get { return _equippedShield; }
            set
            {
                if (value != _equippedShield)
                {
                    _equippedShield = "Shield: " + value;
                    OnPropertyChanged("EquippedShield");
                }
            }
        }


        private String _playerHP;

        public String PlayerHP
        {
            get { return _playerHP; }
            set
            {
                if (value != _playerHP)
                {
                    _playerHP = "HP: " + value;
                    OnPropertyChanged("PlayerHP");
                }
            }
        }

        private String _playerAC;

        public String PlayerAC
        {
            get { return _playerAC; }
            set
            {
                if (value != _playerAC)
                {
                    _playerAC = "AC: " + value;
                    OnPropertyChanged("PlayerAC");
                }
            }
        }


        #endregion

        #region Commands

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GameStart", "");
                }));
            }
        }

        private ICommand _inventoryCommand;

        public ICommand InventoryCommand
        {
            get
            {
                return _inventoryCommand ?? (_inventoryCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToInventory", "");
                }));
            }
        }

        #endregion
    }
}
