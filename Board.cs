using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MemoryTiles
{
    internal class Board
    {
        public List<List<Tile>> Tiles { get; set; }
        public List<string> Photos = new List<string> {
            "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal1.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal2.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal3.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal4.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal5.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal6.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal7.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal8.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal9.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal10.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal11.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal12.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal13.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal14.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal15.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal16.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal17.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal18.jpg",
        "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal19.jpg" };
        public static int noRows { get; set; } = 5;
        public static int noColumns { get; set; } = 5;

        public void Shuffle(List<Tile> listOfTiles)
        {
            // Define a random number generator
            Random rnd = new Random();
            
            // Shuffle the list of lists
            for (int i = listOfTiles.Count - 1; i > 0; i--)
            {
                // Generate a random index within the range of the list
                int j = rnd.Next(i + 1);

                // Swap the current element with the randomly selected element
                Tile temp = listOfTiles[i];
                listOfTiles[i] = listOfTiles[j];
                listOfTiles[j] = temp;
            }
        }
       
        public void CreateListOfTiles(ref List<Tile> listOfTiles, int size)
        {
            listOfTiles = new List<Tile>();
            HashSet<int> usedPhotos = new HashSet<int>();
            while (listOfTiles.Count < size)
            {
                Random random = new Random();
                int indexOfPhoto = random.Next(Photos.Count);
                if(!usedPhotos.Contains(indexOfPhoto))
                {
                    usedPhotos.Add(indexOfPhoto);
                    listOfTiles.Add(new Tile(Photos[indexOfPhoto]));
                    listOfTiles.Add(new Tile(Photos[indexOfPhoto]));
                }
            }
            Shuffle(listOfTiles);
        }
        public void CreateBoard()
        {
            if (Tiles == null)
            {
                Tiles = new List<List<Tile>>();
            }
            else
            {
                Tiles.Clear();
                Tiles = new List<List<Tile>>();
            }
            List<Tile> listOfTiles = new List<Tile>();
            CreateListOfTiles(ref listOfTiles, noRows * noColumns);
            for (int i = 0; i < noRows; i++)
            {
                List<Tile> row = new List<Tile>();
                for (int j = 0; j < noColumns; j++)
                {
                    row.Add(listOfTiles[i * noColumns + j]);
                }
                Tiles.Add(row);
            }
        }
        public Board()
        {
            CreateBoard();
        }
    }
}
