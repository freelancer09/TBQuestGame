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

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
        }
        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }
        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }
        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }
        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
