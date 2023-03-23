using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles
{
    internal class Tile
    {
        public string CurrentImage 
        { 
            get 
            {
                if (IsFlipped)
                {
                    return Photo;
                }
                else
                {
                    return "D:\\Computer Science\\Anul II\\SEM2\\MVP\\MemoryTiles\\MemoryTiles\\animals\\animal0.jpg";
                }
            }
        }
        public string Photo { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsMatched { get; set; }
        public Tile(string photo)
        {
            Photo = photo;
            IsFlipped = false;
            IsMatched = false;
        }
    }
}
