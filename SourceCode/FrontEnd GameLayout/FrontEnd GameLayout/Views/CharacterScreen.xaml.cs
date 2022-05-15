using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontEnd_GameLayout.Views
{
    /// <summary>
    /// Interaction logic for CharacterScreen.xaml
    /// </summary>
    public partial class CharacterScreen : UserControl
    {
        public CharacterScreen()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(Main);
        }
    }
}
