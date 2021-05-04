namespace GameOfLife
{
    public class Logica
    {
        public Tablero Tablero {get;private set;}
        
        public Logica(Tablero tablero)
        {
            this.Tablero = tablero;
        }

        public void NextStep()
        {
            Tablero clonetablero = new Tablero(this.Tablero.Height,this.Tablero.Height);
            //Se recorren todas la celdas del tablero para calcular el nuevo estado de cada célula
            for (int x = 0; x < this.Tablero.Width; x++)
            {
                for (int y = 0; y < this.Tablero.Height; y++)
                {
                    int aliveNeighbors = 0;
                    //Para cada célula, se caluculan la cantidad de vecinos vivos que tiene
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            //Controlamos que las celdas a analizar esten dentro del tablero y no fuera de rango
                            if(i>=0 && i<this.Tablero.Width && j>=0 && j <this.Tablero.Height && this.Tablero.GetValue(i,j))
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    //Si la celula que estamos analizando está viva, esta fue contada dos veces
                    //y debemos restarla del total de vecinos vivos.
                    if(this.Tablero.GetValue(x,y))
                    {
                        aliveNeighbors--;
                    }

                    //Analizamos cada caso si la celula debe vivir o morir.
                    if (this.Tablero.GetValue(x,y) && aliveNeighbors < 2) 
                    {
                        //Célula muere por soledad 
                        clonetablero.SetValue(x,y,false); 
                    }
                    else if (this.Tablero.GetValue(x,y) && aliveNeighbors > 3) 
                    {
                        //Célula muere por sobrepoblación 
                        clonetablero.SetValue(x,y,false);
                    }
                    else if (!this.Tablero.GetValue(x,y) && aliveNeighbors == 3) 
                    {
                        //Nace una nueva célula por reproducción 
                        clonetablero.SetValue(x,y,true);
                    }
                    else
                    {
                        //La célula permanece en el mismo estado que tenía
                        clonetablero.SetValue(x,y,this.Tablero.GetValue(x,y));
                    }
                }
            }
            //Copiamos el nuevo tablero (nueva generación) al tablero actual
            this.Tablero = clonetablero;
        }
        
    }
}