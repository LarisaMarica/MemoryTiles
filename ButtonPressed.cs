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
    internal class ButtonPressed
    {
        public Tile tile { get; set; }
        public Button button { get; set; }
        public ButtonPressed(Tile tile, Button button)
        {
            this.tile = tile;
            this.button = button;
        }
    }
}
