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
using GameEngine.Abstract_Class;
using GameEngine.Interfaces;

namespace FrontEnd_GameLayout.ViewModels
{
    public class InventoryViewModel : BaseViewModel, IPageViewModel
    {
        ViewInfo Res = ViewInfo.Instance;
        IGameController game = GameController.Instance;

        public InventoryViewModel()
        {
            Items = game.CurrentPlayer.Inventory;
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

        private List<Item> _items = new List<Item>();

        public List<Item> Items {
            get { return _items; }
            set
            {
                if (value != _items)
                {
                    _items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        private Item _selectedItem;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
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

        private DelegateCommand _equipCommand;
        
        public DelegateCommand EquipCommand => _equipCommand ?? (_equipCommand = new DelegateCommand(ExecuteEquipCommand));

        async void ExecuteEquipCommand()
        {
            if(SelectedItem != null)
            {
                if (SelectedItem.Id == 1)
                {
                    game.CurrentPlayer.EquippedWeapon = (Weapon)SelectedItem;
                }
                if (SelectedItem.Id == 2)
                {
                    game.CurrentPlayer.EquippedShield = (Shield)SelectedItem;
                }
            }
        }


        #endregion
    }
}
