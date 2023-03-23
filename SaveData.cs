using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles
{
    [Serializable]
    internal class SaveData
    {
        public int level { get; set; }
        public Board board { get; set; }
        public int numberOfUnmatchedTiles { get; set; }
        public int noRows { get; set; }
        public int noColumns { get; set; }
        public SaveData(int level, Board board, int numberOfUnmatchedTiles, int noRows, int noColumns)
        {
            this.level = level;
            this.board = board;
            this.numberOfUnmatchedTiles = numberOfUnmatchedTiles;
            this.noRows = noRows;
            this.noColumns = noColumns;
        }
    }
}
