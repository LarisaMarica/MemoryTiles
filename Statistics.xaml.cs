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

namespace MemoryTiles
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private User CurrentUser;
        public Statistics(User user)
        {
            CurrentUser = user;
            InitializeComponent();
            username.Text = CurrentUser.Username;
            ReadStatistics();
            
        }

        private void ReadStatistics()
        {
            string[] lines = System.IO.File.ReadAllLines(CurrentUser.Username + ".txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                CurrentUser.GamesPlayed = Convert.ToInt32(words[0]);
                gamesPlayed.Text = words[0];
                CurrentUser.GamesWon = Convert.ToInt32(words[1]);
                gamesWon.Text = words[1];
            }
        }
    }
}
