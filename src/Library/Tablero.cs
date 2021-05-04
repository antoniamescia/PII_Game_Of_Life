using System;

namespace GameOfLife
{
    public class Tablero
    {
        bool[,] tablero;
    
        public int Width {get;private set;}
        public int Height {get;private set;}
        public Tablero(int width, int height, bool[,] tablero=null)
        {
            this.Width = width;
            this.Height = height;
            this.tablero = new bool[width,height];
            if (tablero!=null)
            {
                for (int x = 0; x < Math.Min(width, tablero.GetLength(0)); x++)
                {
                    for (int y = 0; y < Math.Min(width, tablero.GetLength(1)); y++)
                    {
                        this.tablero[x,y] = tablero[x,y];
                    }
                }
            }
        }
       
        public void SetValue(int x, int y, bool alive)
        {
            this.tablero[x,y] = alive;
        }
        
        public bool GetValue(int x, int y)
        {
            return this.tablero[x,y];
        }
    }
}
