using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Board:BaseBoard
    {  
        public Board(int rows, int columns, int B):base()
        {
            this.BoardData = new int[rows, columns];
            int[] randomBomb = new int[rows * columns];
            for (int i = 0; i < rows * columns; i++)
                randomBomb[i] = i;
            int endOfRandom = rows * columns - 1;

            for (int i = 0; i < B; i++)
            {
                Random rnd = new Random();
                int SquareWithBomb = rnd.Next(0, endOfRandom);
                int row = randomBomb[SquareWithBomb] / columns;
                int column = randomBomb[SquareWithBomb] % columns;
                BoardData[row, column] = 9;
                if (row != 0)
                {
                    //(i-1,j-1)
                    if (column != 0)
                        if (BoardData[row - 1, column - 1] != 9)
                        {
                            BoardData[row - 1, column - 1] += 1;
                        }

                    //(i-1,j)
                    if (BoardData[row - 1, column] != 9)
                    {
                        BoardData[row - 1, column] += 1;
                    }

                    //(i-1, j+1)
                    if (column != columns - 1)
                        if (BoardData[row - 1, column + 1] != 9)
                        {
                            BoardData[row - 1, column + 1] += 1;
                        }

                }
                //(i,j-1)
                if (column != 0)
                    if (BoardData[row, column - 1] != 9)
                    {
                        BoardData[row, column - 1] += 1;
                    }

                //(i,j+1)
                if (column != columns - 1)
                    if (BoardData[row, column + 1] != 9)
                    {
                        BoardData[row, column + 1] += 1;
                    }

                if (row != rows - 1)
                {
                    //(i+1,j-1)
                    if (column != 0)
                        if (BoardData[row + 1, column - 1] != 9)
                        {
                            BoardData[row + 1, column - 1] += 1;
                        }

                    //(i+1,j)
                    if (BoardData[row + 1, column] != 9)
                    {
                        BoardData[row + 1, column] += 1;
                    }

                    //(i+1, j+1)
                    if (column != columns - 1)
                        if (BoardData[row + 1, column + 1] != 9)
                        {
                            BoardData[row + 1, column + 1] += 1;
                        }

                }
                randomBomb[SquareWithBomb] = randomBomb[endOfRandom];
                endOfRandom--;
            }
          
        }

    }


}

