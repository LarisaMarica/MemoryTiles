using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MemoryTiles
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {

        private List<string> photos = new List<string> { "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme1.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme2.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme3.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme4.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme5.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme6.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme7.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme8.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme9.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme10.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme11.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme12.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme13.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme14.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme15.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme16.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme17.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme18.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme19.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme20.png",
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\people\\meme21.png" };
        private int currentIndex;

        public NewUser()
        {
            InitializeComponent();
            currentIndex = 0;
        }

        private void NextPhoto_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= photos.Count)
            {
                currentIndex = 0;
            }
            photoDisplay.Source = new BitmapImage(new Uri(photos[currentIndex], UriKind.Absolute));
        }

        private void PreviousPhoto_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = photos.Count - 1;
            }
            photoDisplay.Source = new BitmapImage(new Uri(photos[currentIndex], UriKind.Absolute));
        }
        private bool VerifyIfUsernameExists(string username)
        {
            string[] lines = File.ReadAllLines("UserAndAvatar.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                if (words[0] == username)
                {
                    return true;
                }
            }
            return false;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyIfUsernameExists(content.Text))
            {
                MessageBox.Show("Username already exists!");
            }
            else
            {
                if (content.Text == "")
                {
                    MessageBox.Show("Please enter a Username!");
                }
                else
                {
                    StreamWriter writer = new StreamWriter("UserAndAvatar.txt", true);
                    String user = content.Text;
                    user += ',';
                    user += photos[currentIndex];
                    writer.WriteLine(user);
                    writer.Close();
                    StreamWriter writer1 = File.CreateText(content.Text + ".txt");
                    writer1.WriteLine("0,0");
                    writer1.Close();
                    this.Close();
                }
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
