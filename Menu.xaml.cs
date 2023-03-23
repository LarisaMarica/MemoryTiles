using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

namespace MemoryTiles
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private User CurrentUser;
        public Menu(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Game game = new Game(CurrentUser);
            game.ShowDialog();
            this.ShowDialog();
        }
        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            Statistics statistics = new Statistics(CurrentUser);
            statistics.ShowDialog();
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
    }
}
