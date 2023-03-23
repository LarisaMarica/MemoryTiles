using Newtonsoft.Json;
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
    public partial class Game : Window
    {
        private int Moves { get; set; } = 0;
        private ButtonPressed FirstTile { get; set; }
        private ButtonPressed SecondTile { get; set; }
        private int Level { get; set; } = 1;
        private User CurrentUser { get; set; }
        private int NumberOfUnmatchedTiles { get; set; } = Board.noRows * Board.noColumns;
        private int GameState { get; set; } = 0;
        public Game(User currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            image.Source = new BitmapImage(new Uri(CurrentUser.Avatar, UriKind.Absolute));
            username.Text = CurrentUser.Username;
            level.Text = "Level " + Level;
        }
        private bool IsMatch(ButtonPressed tile1, ButtonPressed tile2)
        {
            if (tile1.tile.Photo == tile2.tile.Photo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            Tile clickedTile = (Tile)button.DataContext;
            if (clickedTile.IsFlipped)
            {
                return;
            }
            clickedTile.IsFlipped = true;
            Tile temp = new Tile(clickedTile.Photo);
            temp.IsFlipped = true;
            button.DataContext = temp;
            button.InvalidateVisual();
            if (NumberOfUnmatchedTiles == 1)
            {
                NumberOfUnmatchedTiles--;
            }

            if (Moves < 2)
            {
                if (Moves == 0)
                {
                    FirstTile = new ButtonPressed(clickedTile, button);
                }
                else
                {
                    SecondTile = new ButtonPressed(clickedTile, button);
                    if(IsMatch(FirstTile, SecondTile))
                    {
                        NumberOfUnmatchedTiles -= 2;
                    }
                }
                Moves++;
            }
            else
            {
                if (IsMatch(FirstTile, SecondTile))
                {
                    FirstTile.tile.IsMatched = true;
                    SecondTile.tile.IsMatched = true;
                }
                else
                {
                    FirstTile.tile.IsFlipped = false;
                    SecondTile.tile.IsFlipped = false;
                    
                    Button button1 = FirstTile.button;
                    button1.DataContext = FirstTile.tile;
                    button1.InvalidateVisual();
                    
                    Button button2 = SecondTile.button;
                    button2.DataContext = SecondTile.tile;
                    button2.InvalidateVisual();
                }
                Moves = 1;
                FirstTile = new ButtonPressed(clickedTile, button);
            }
            if(NumberOfUnmatchedTiles == 0)
            {
                if(Level == 3)
                {
                    MessageBox.Show("Congratulations! You won!");
                    CurrentUser.GamesPlayed++;
                    CurrentUser.GamesWon++;
                    GameState = 1;
                    ModifyStatisticsFile();
                    Close();
                    return;
                }
                NumberOfUnmatchedTiles = Board.noRows * Board.noColumns;
                Level++;
                MessageBox.Show("Level " + Level);
                BoardDataContext = null;
                BoardDataContext = new Board();
                DataContext = BoardDataContext;
                level.Text = "Level " + Level;
                InvalidateVisual();
            }
        }
        private void ModifyStatisticsFile()
        {
            string[] line = System.IO.File.ReadAllLines(CurrentUser.Username+".txt");
            string[] numbers = line[0].Split(',');
            numbers[0] = CurrentUser.GamesPlayed.ToString();
            numbers[1] = CurrentUser.GamesWon.ToString();
            StreamWriter streamWriter = new StreamWriter(CurrentUser.Username + ".txt", false);
            streamWriter.Write(numbers[0] + ',' + numbers[1]);
            streamWriter.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (GameState == 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to exit? (This will affect your statistics.)", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                    CurrentUser.GamesPlayed++;
                    ModifyStatisticsFile();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveData saveData = new SaveData(Level, BoardDataContext, NumberOfUnmatchedTiles, Board.noRows, Board.noColumns);
                var jsonString = JsonConvert.SerializeObject(saveData);
                string filePath = CurrentUser.Username + ".json";

                using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                {
                    streamWriter.WriteLine(jsonString);
                    streamWriter.Flush();
                }

                MessageBox.Show("Game saved!");
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                MessageBox.Show("Failed to save game: " + ex.Message);
            }
        }
        private void OpenGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Board.noRows = 0;
                Board.noColumns = 0;
                string filePath = CurrentUser.Username + ".json";
                string jsonString = File.ReadAllText(filePath);
                SaveData saveData = JsonConvert.DeserializeObject<SaveData>(jsonString);
                Level = saveData.level;
                Board.noRows = saveData.noRows;
                Board.noColumns = saveData.noColumns;
                BoardDataContext = saveData.board;
                DataContext = BoardDataContext;
                NumberOfUnmatchedTiles = saveData.numberOfUnmatchedTiles;
                level.Text = "Level " + Level;
                InvalidateVisual();
                MessageBox.Show("Game loaded!");
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                MessageBox.Show("Failed to load game: " + ex.Message);
            }
        }
    }
}
