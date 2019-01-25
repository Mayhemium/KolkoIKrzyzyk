using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClassLibrary
{
    public class Game
    {
        bool isPlayerXturn;
        Grid mainGrid;

        public Game(Grid MainGrid)
        {
            this.isPlayerXturn = false;
            mainGrid = MainGrid;
            //CreateGrid(3);
        }

        public void CreateGrid(int size)
        {
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


            

            Button b;
            for(int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    b = new Button();
                    mainGrid.Children.Add(b);
                }

            }
        }
    }
}
