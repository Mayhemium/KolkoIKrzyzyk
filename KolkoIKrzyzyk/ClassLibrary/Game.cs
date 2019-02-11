using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ClassLibrary
{
    /// <summary>
    /// Logic for the tic tac toe game
    /// </summary>
    public class Game
    {
        bool isPlayerXturn;
        bool isPlayable;
        int movesCount;
        Grid mainGrid;
        Player firstPlayer = new PlayerX();
        Player secondPlayer = new PlayerO();

        /// <summary>
        /// Initializing game
        /// </summary>
        /// <param name="MainGrid">A main grid of tic tac toe.</param>
        public Game(Grid MainGrid)
        {
            movesCount = 0;
            this.isPlayerXturn = false;
            isPlayable = true;
            mainGrid = MainGrid;
            CreateGrid(3);
        }

        /// <summary>
        /// Executing players movement based on turns and state of the game
        /// </summary>
        /// <param name="sender">Object that started event.</param>
        /// <param name="e">Contains routed event data.</param>
        public void move(object sender, RoutedEventArgs e)
        {
            if (!isPlayable)
                return;
            Button b = (Button)sender;

            if(!b.Tag.Equals("button"))
                return;
            if (isPlayerXturn)
            {
                b.Content = "x";
                b.Tag = "x";
            }
            else
            {
                b.Content = "o";
                b.Tag = "o";
            }
            b.Background = Brushes.Beige;
            isPlayerXturn = !isPlayerXturn;
            movesCount++;
            Check();

        }

        /// <summary>
        /// Checking for the conditions of win / draw.
        /// </summary>
        public void Check()
        {

            int size = Convert.ToInt16(Math.Sqrt(mainGrid.Children.Count));
            Button[] buttons = mainGrid.Children.Cast<Button>().ToArray<Button>();
            char[,] arr = new char[size,size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (buttons[size*i + j].Tag)
                    {
                        case "button":
                            arr[i, j] = ' ';
                            break;
                        case "x":
                            arr[i, j] = 'x';
                            break;
                        case "o":
                            arr[i, j] = 'o';
                            break;
                    }
                }
            }
            int[,] result = MatrixLogics.checkForWin(arr);
            if (movesCount == mainGrid.Children.Count)
            {
                MessageBox.Show("Koniec", "Game over", MessageBoxButton.OK);
                isPlayable = false;
            }
            if (result is null)
                return;
            isPlayable = false;
            int won = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (result[i, j] != 0)
                    {
                        buttons[size * i + j].Background = Brushes.LightGreen;
                        won = result[i, j];
                    }
                }
            }
            if (won == 1)
            {
                playerWon(firstPlayer);
            }
            if (won == 2)
            {
                playerWon(secondPlayer);
            }
        }

        /// <summary>
        /// Sending message informing about win containing player identity
        /// </summary>
        /// <param name="p">Player that won the game.</param>
        private void playerWon(Player p)
        {
            MessageBox.Show(Application.Current.MainWindow, "Gracz " + p.getName() + " wygrał", "Game over",MessageBoxButton.OK);
        }

        public void CreateGrid(int size)
        {
            movesCount = 0;
            isPlayerXturn = false;
            isPlayable = true;
            MatrixLogics.Reset();

            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            RowDefinition rd;
            ColumnDefinition cd;

            for(int i = 0; i < size; i++)
            {
                rd = new RowDefinition();
                rd.Height = new GridLength(1,GridUnitType.Star);
                mainGrid.RowDefinitions.Add(rd);
                cd = new ColumnDefinition();
                cd.Width = new GridLength(1, GridUnitType.Star);
                mainGrid.ColumnDefinitions.Add(cd);
            }


            

            for(int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {

                    Button b = new Button();
                    b.Tag = "button";
                    b.FontFamily=new FontFamily("Comic Sans MS");
                    b.FontWeight = FontWeights.Bold;
                    b.FontSize = 200/size;
                    b.Foreground = Brushes.Orange;
                    b.Background = Brushes.White;
                    b.Click += move;
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    mainGrid.Children.Add(b);
                }

            }
        }
    }
}
