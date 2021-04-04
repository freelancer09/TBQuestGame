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
    /// Interaction logic for NpcTradeView.xaml
    /// </summary>
    public partial class NpcTradeView : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        public NpcTradeView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            DataContext = _gameSessionViewModel;
            InitializeComponent();
        }
        public void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (NpcItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.BuyItem();
            }            
        }
        public void ExamineNpcButton_Click(object sender, RoutedEventArgs e)
        {
            if (NpcItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnExamineTradeNpcGameItem();
            }
        }
        public void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.SellItem();
            }
        }
        public void ExaminePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnExamineTradePlayerGameItem();
            }
        }
        public void FinalizeButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.FinalizeTrade();
        }
        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
