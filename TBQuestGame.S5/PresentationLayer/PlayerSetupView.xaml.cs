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
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();
            ErrorTextBlock.Visibility = Visibility.Hidden;
            NameTextBox.Focus();
        }
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (NameTextBox.Text == "") errorMessage += "Player Name is required.\n";
            else _player.Name = NameTextBox.Text;
            return errorMessage == "" ? true : false;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidInput(out string errorMessage))
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
                ErrorTextBlock.Text = errorMessage;
            }
        }
    }
}
