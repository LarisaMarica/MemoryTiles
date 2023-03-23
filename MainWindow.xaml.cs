using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryTiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users;
        public User currentUser;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>();
            ReadFromFile();
        }
        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReadFromFile()
        {
            if (new System.IO.FileInfo("UserAndAvatar.txt").Length != 0)
            {
                string[] lines = System.IO.File.ReadAllLines("UserAndAvatar.txt");
                lines = lines.Where(line => !string.IsNullOrEmpty(line)).ToArray();
                if (lines.Length != 0)
                {
                    foreach (string line in lines)
                    {
                        string[] words = line.Split(',');
                        User user = new User(words[0], words[1]);
                        users.Add(user);
                    }
                    names.ItemsSource = users;
                }
                
            }
        }
        
        private void SelectUser_Click(object sender, RoutedEventArgs e)
        {
            if(names.SelectedIndex != -1)
            {
                currentUser = users[names.SelectedIndex];

                if (currentUser != null)
                {
                    image.Source = new BitmapImage(new Uri(currentUser.Avatar, UriKind.Absolute));
                    deleteButton.IsEnabled = true;
                    playButton.IsEnabled = true;
                }
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUser newUserWindow = new NewUser();
            this.Hide();
            newUserWindow.ShowDialog();
            string[] lines = System.IO.File.ReadAllLines("UserAndAvatar.txt");
            if(lines.Length != users.Count)
            {
                string[] parts = lines[lines.Length - 1].Split(',');
                User user = new User(parts[0], parts[1]);
                users.Add(user);
                names.ItemsSource = null;
                names.ItemsSource = users;
            }
            this.Show();
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(currentUser);
            menu.ShowDialog();
            this.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Delete(currentUser.Username + ".txt");
                File.Delete(currentUser.Username + ".json");
            }
            catch (IOException exc)
            {
                MessageBox.Show(exc.Message);
            }
            string[] lines = System.IO.File.ReadAllLines("UserAndAvatar.txt");
            string[] newLines = new string[lines.Length - 1];
            int index = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] != currentUser.Username)
                {
                    newLines[index] = line;
                    index++;
                }
            }
            System.IO.File.WriteAllLines("UserAndAvatar.txt", newLines);
            users.Remove(currentUser);
            names.ItemsSource = null;
            names.ItemsSource = users;
            names.SelectedIndex = -1;
            image.Source = null;
            deleteButton.IsEnabled = false;
            playButton.IsEnabled = false;
            
        }
    }

    public class User
    {
        public User(string username, string avatar)
        {
            Username = username;
            Avatar = avatar;
        }
        public string Username { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public string Avatar { get; set; }

    }
}
