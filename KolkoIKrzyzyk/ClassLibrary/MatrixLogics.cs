using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MatrixLogics
    {
        static bool found = false;
        public static int[,] checkForWin(char[,] arr)
        {

            int[,] temp = checkColumns(arr);
            if (found)
            {
                found = false;
                return temp;
            }

            temp = checkRows(arr);
            if (found)
            {
                found = false;
                return temp;
            }

            temp = checkLeftTopToRightBottom(arr);
            if (found)
            {
                found = false;
                return temp;
            }

            temp = checkRightTopToLeftBottom(arr);
            if (found)
            {
                found = false;
                return temp;
            }
            return null;
        }

        private static int[,] checkRows(char[,] arr)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];

            for(int i = 0; i< arr.GetLength(0); i++)
            {
                string s = "";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    s += arr[i, j];
                }
                if (s.Contains("xxx"))
                {
                    temp[i, s.IndexOf("xxx")] = 1;
                    temp[i, s.IndexOf("xxx")+1] = 1;
                    temp[i, s.IndexOf("xxx")+2] = 1;
                    found = true;

                }
                if (s.Contains("ooo"))
                {
                    temp[i, s.IndexOf("ooo")] = 2;
                    temp[i, s.IndexOf("ooo") + 1] = 2;
                    temp[i, s.IndexOf("ooo") + 2] = 2;
                    found = true;
                }
            }

            return temp;
        }

        private static int[,] checkColumns(char[,] arr)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];

            for (int j = 0; j < arr.GetLength(0); j++)
            {
                string s = "";
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    s += arr[i, j];
                }
                if (s.Contains("xxx"))
                {
                    temp[s.IndexOf("xxx"),j] = 1;
                    temp[s.IndexOf("xxx") + 1,j] = 1;
                    temp[s.IndexOf("xxx") + 2,j] = 1;
                    found = true;

                }
                if (s.Contains("ooo"))
                {
                    temp[s.IndexOf("ooo"),j] = 2;
                    temp[s.IndexOf("ooo") + 1,j] = 2;
                    temp[s.IndexOf("ooo") + 2,j] = 2;
                    found = true;
                }
            }

            return temp;
        }

        private static int[,] checkLeftTopToRightBottom(char[,] arr)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];

            for(int i = 0; i < arr.GetLength(0) - 2; i++)
            {
                temp = startOffsetLeftTop(arr,i,0);
                if (found)
                    break;
                temp = startOffsetLeftTop(arr, 0, i);
                if (found)
                    break;
            }

            return temp;
        }

        private static int[,] startOffsetLeftTop(char[,] arr, int x, int y)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];
            string s = stringLeftTopToRightBottom(arr, x, y);
            if (s.Contains("xxx"))
            {
                temp[s.IndexOf("xxx")+x, s.IndexOf("xxx")+y] = 1;
                temp[s.IndexOf("xxx") + 1 + x, s.IndexOf("xxx") + 1 + y] = 1;
                temp[s.IndexOf("xxx") + 2 + x, s.IndexOf("xxx") + 2 + y] = 1;
                found = true;
            }
            if (s.Contains("ooo"))
            {
                temp[s.IndexOf("ooo") + x, s.IndexOf("ooo") + y] = 2;
                temp[s.IndexOf("ooo") + 1 + x, s.IndexOf("ooo") + 1 + y] = 2;
                temp[s.IndexOf("ooo") + 2 + x, s.IndexOf("ooo") + 2 + y] = 2;
                found = true;
            }
            return temp;
        }

        private static string stringLeftTopToRightBottom(char[,] arr, int x, int y)
        {
            string s = "";

            for(int i = 0; (i+x < arr.GetLength(0))&& (i+y < arr.GetLength(1)); i++)
            {
                s += arr[i+x, i+y];
            }

            return s;
        }

        /// <summary>
        private static int[,] checkRightTopToLeftBottom(char[,] arr)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0) - 2; i++)
            {
                temp = startOffsetRightTop(arr, i, 0);
                if (found)
                    break;
                temp = startOffsetRightTop(arr, 0, i);
                if (found)
                    break;
            }

            return temp;
        }

        private static int[,] startOffsetRightTop(char[,] arr, int x, int y)
        {
            int[,] temp = new int[arr.GetLength(0), arr.GetLength(1)];
            string s = stringRightTopToLeftBottom(arr, x, y);
            if (s.Contains("xxx"))
            {
                temp[arr.GetLength(0) - s.IndexOf("xxx") - x - 3, s.IndexOf("xxx") + y + 2] = 1;
                temp[arr.GetLength(0) - s.IndexOf("xxx") - x - 2, s.IndexOf("xxx") + 1 + y] = 1;
                temp[arr.GetLength(0) - s.IndexOf("xxx") - x - 1, s.IndexOf("xxx")  + y] = 1;
                found = true;
            }
            if (s.Contains("ooo"))
            {
                temp[arr.GetLength(0) - s.IndexOf("ooo") - x - 3, s.IndexOf("ooo") + y + 2] = 2;
                temp[arr.GetLength(0) - s.IndexOf("ooo") - x - 2, s.IndexOf("ooo") + 1 + y] = 2;
                temp[arr.GetLength(0) - s.IndexOf("ooo") - x - 1, s.IndexOf("ooo")  + y] = 2;
                found = true;
            }
            return temp;
        }

        private static string stringRightTopToLeftBottom(char[,] arr, int x, int y)
        {
            string s = "";

            for (int i = 0; (arr.GetLength(0)-1 - i - x >= 0) && (i + y < arr.GetLength(1)); i++)
            {
                s += arr[arr.GetLength(0)-1 - i - x, i + y];
            }

            return s;
        }

        public static string stringTest(char[,] arr, int x, int y)
        {
            return stringRightTopToLeftBottom(arr, x, y);
        }
        ////////////

        public static void Reset()
        {
            found = false;
        }
    }
}
