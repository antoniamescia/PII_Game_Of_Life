using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string boardPath = Path.Combine("..","..","assets","tablero.txt");
            bool[,] tablero = LeerArchivo.LectorArchivo(boardPath); 

            Tablero b = new Tablero(tablero.GetLength(0), tablero.GetLength(1), tablero);

            Logica m = new Logica(b);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(ImprimirTablero.Imprimir(m.Tablero));
                m.NextStep();
                Thread.Sleep(300);
            }
        }
    }
}
