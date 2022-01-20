using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BaseBoard
    {
        protected int[,] boardData;
        public int GetData(int r, int c)
        {
            return this.BoardData[r, c];
        }
        public int RowLengh { get => this.BoardData.GetLength(0); }
        public int ColLengh { get => this.BoardData.GetLength(1); }
        public int[,] BoardData { get => boardData; set => boardData = value; }

        public void Draw()
        {
            for (int i = 0; i < RowLengh; i++)
            {
                for (int j = 0; j < ColLengh; j++)
                {
                    Console.Write(GetData(i, j));
                    Console.Write(" | ");
                }
                Console.WriteLine();
                for (int j = 0; j < ColLengh; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
    }
}
