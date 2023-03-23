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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
        }
        private void Standard_Checked(object sender, RoutedEventArgs e)
        {
            RowsComboBox.IsEnabled = false;
            ColumnsComboBox.IsEnabled = false;
        }
        private void Custom_Checked(object sender, RoutedEventArgs e)
        {
            RowsComboBox.IsEnabled = true;
            ColumnsComboBox.IsEnabled = true;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (Standard.IsChecked == true)
            {
                Board.noRows = 5;
                Board.noColumns = 5;
            }
            else
            {
                Board.noRows = int.Parse(RowsComboBox.Text);
                Board.noColumns = int.Parse(ColumnsComboBox.Text);
            }
            Close();
        }
    }
}
