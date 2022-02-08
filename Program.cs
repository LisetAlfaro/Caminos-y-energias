using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caminos_y_energias
{
    class Program
    {
        static int [] df = { -1, 0, 1, 0 };
        static int [] dc = { 0, 1, 0, -1 };
        static bool Hay_Camino(int[,] matriz, int f1, int c1, int f2, int c2, int consumo_maximo)
        {
            return TIAW(matriz, f1, c1, f2, c2, consumo_maximo,0);
        }
        static bool TIAW(int[,] matriz, int f1 , int c1, int f2, int c2, int consumo, int count)
        {
            if (f1 == f2 && c1 == c2) return true;
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int nf = f1 + df[i];
                    int nc = c1 + dc[i];
                    if (PosicionValida(matriz, nf, nc))
                    {
                        if (matriz[f1, c1] >= matriz[nf, nc] && count + 1 < consumo) 
                            if(TIAW(matriz, nf, nc, f2, c1, consumo, count + 1)) return true;
                        else if (matriz[nf, nc] - matriz[f1, c1] + 1 < consumo)
                            if(TIAW(matriz, nf, nc, f2, c2, consumo, count + 1 + matriz[nf, nc] - matriz[f1, c1])) return true;
                    }

                }
            }
            return false;
        }

        private static bool PosicionValida(int[,] matriz, int nf, int nc)
        {
            return (nf != -1 && nf != matriz.GetLength(0) && nc != -1 && nc != matriz.GetLength(1)) ;
        }
        static void Main(string[] args)
        { 
            int[,] matriz = new int[3, 3];
            matriz= new int[,]
                {{1,2,7}, {1,2,5}, {3,5,2} };

            bool ppa = Hay_Camino(matriz, 0, 0, 0, 0, 1);
           if ( ppa)
               Console.WriteLine("HAY CAMINO");
            else
               Console.WriteLine("NO HAY CAMINO");
           Console.ReadKey();
        }
    }
}
