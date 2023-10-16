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

namespace Buscaminas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int seed;
        private const short GRID_SIZE = 10;
        private const short MINE_TOTAL = GRID_SIZE * 2;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            seed = (int)DateTime.UtcNow.Ticks;
            CreateButtons();
            AddMines();
        }

        private void CreateButtons()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    var btn = new Button();
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    gameGrid.Children.Add(btn);
                }
            }
        }

        private void AddMines()
        {
            var rand = new Random(seed);
            for (int i = 0; i < GRID_SIZE; i++)
            {
                var row = rand.Next(0, MINE_TOTAL);
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    var col = rand.Next(0, MINE_TOTAL);
                    var btn = gameGrid.Children
                          .Cast<Button>()
                          .Where(b => Grid.GetRow(b) == row && Grid.GetColumn(b) == col).ElementAt(0);
                    btn.Content = 1;
                }
            }
        }
    }
}
