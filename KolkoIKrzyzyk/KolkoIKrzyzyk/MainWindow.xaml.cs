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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;

namespace KolkoIKrzyzyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game g;

        /// <summary>
        /// Initialization of Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            g = new Game(MainGrid);
            
        }

        /// <summary>
        /// Reaction to changing the grid size
        /// </summary>
        /// <param name="sender">Object that started event.</param>
        /// <param name="e">Contains routed event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int gridSize =Convert.ToInt16(comboBox.Text);
            g.CreateGrid(gridSize);
        }
    }
}
