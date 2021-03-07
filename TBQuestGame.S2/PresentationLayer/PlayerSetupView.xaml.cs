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

            SetupWindow();

            NameTextBox.Focus();
        }
        private void SetupWindow()
        {
            List<string> jobTitles = Enum.GetNames(typeof(Player.JobTitle)).ToList();
            JobComboBox.ItemsSource = jobTitles;

            ErrorTextBlock.Visibility = Visibility.Hidden;
        }
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (NameTextBox.Text == "") errorMessage += "Player Name is required.\n";
            else _player.Name = NameTextBox.Text;
            if (!int.TryParse(MathTextBox.Text, out int math)) errorMessage += "Math is required and must be an integer.\n";
            else _player.SkillMath = math;
            if (!int.TryParse(ScienceTextBox.Text, out int science)) errorMessage += "Science is required and must be an integer.\n";
            else _player.SkillScience = science;
            if (!int.TryParse(HistoryTextBox.Text, out int history)) errorMessage += "History is required and must be an integer.\n";
            else _player.SkillHistory = history;
            if (!int.TryParse(EnglishTextBox.Text, out int english)) errorMessage += "English is required and must be an integer.\n";
            else _player.SkillEnglish = english;
            if (!int.TryParse(PhysicalTextBox.Text, out int physical)) errorMessage += "Physical is required and must be an integer.\n";
            else _player.SkillPhysical = physical;
            return errorMessage == "" ? true : false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                Enum.TryParse(JobComboBox.SelectionBoxItem.ToString(), out Player.JobTitle jobTitle);

                _player.Job = jobTitle;

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
