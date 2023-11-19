using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Desafio3EnRaya
{
    internal class Program
    {
        static string[,] tablero = new string[3, 3];
        static string ganador = null;
        static int contador = 1;
        static int coordenadaY;
        static int coordenadaX;
        static bool ganador1 = true;
        static bool ganador2 = true;

        static void Main(string[] args)
        {
            do
            {
                pintaTablero();
                pideJugada();
                ganador=verificaGanador();

            } while (ganador == null);

            Console.WriteLine("El juego termino, el ganador es: "+ganador);
            Console.ReadLine();
        }

        static void pintaTablero()
        {
            Console.Clear();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == null || tablero[i, j] == " ")
                    {
                        tablero[i, j] = " ";
                    }
                    Console.Write("  |" + tablero[i, j] + "|  ");
                }
                Console.WriteLine();
                if (i != 2)
                    Console.WriteLine("---------------------");
            }
        }

        static void pideJugada()
        {
            bool tiroBueno = true;
            string tiro;
            if (contador % 2 != 0)
            {
                do
                {
                    if (tiroBueno==false)
                        Console.WriteLine("El tiro no es un tiro valido, por favor intente de nuevo");
                    Console.WriteLine("Turno del jugador 1 (X) ");
                    Console.WriteLine("Ingresa la coordenada Y de tu tiro, recuerda (del 1 al 3)");
                    tiro = Console.ReadLine();
                    tiroBueno = int.TryParse(tiro, out coordenadaY);
                    tiroBueno = (coordenadaY > 0 && coordenadaY < 4);
                    Console.WriteLine("Ingresa la coordenada X de tu tiro, recuerda (del 1 al 3)");
                    tiro = Console.ReadLine();
                    tiroBueno = int.TryParse(tiro, out coordenadaX);
                    tiroBueno = (coordenadaX >=0 && coordenadaX <= 3);
                    if (tablero[coordenadaY-1, coordenadaX-1] != " ")
                        tiroBueno = false;
                } while (tiroBueno!=true);
                tablero[coordenadaY - 1, coordenadaX - 1] = "X";
            }
            else
            {
                do
                {
                    if (!tiroBueno)
                        Console.WriteLine("El tiro no es un tiro valido, por favor intente de nuevo");
                    Console.WriteLine("Turno del jugador 2 (0) ");
                    Console.WriteLine("Ingresa la coordenada Y de tu tiro, recuerda (del 1 al 3)");
                    tiro = Console.ReadLine();
                    tiroBueno = int.TryParse(tiro, out coordenadaY);
                    tiroBueno = (coordenadaY >= 1 && coordenadaY <= 3);
                    Console.WriteLine("Ingresa la coordenada X de tu tiro, recuerda (del 1 al 3)");
                    tiro = Console.ReadLine();
                    tiroBueno = int.TryParse(tiro, out coordenadaX);
                    tiroBueno = (coordenadaX > 0 && coordenadaX < 4);
                    if (tablero[coordenadaY-1, coordenadaX - 1] != " ")
                        tiroBueno = false;
                } while (!tiroBueno);
                tablero[coordenadaY - 1, coordenadaX - 1] = "0";
            }
            contador++;
        }

        static string verificaGanador()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] != "0")
                    {
                        ganador2 = false;
                    }
                    if (tablero[j, i] != "0")
                    {
                        ganador2 = false;
                    }

                    if (tablero[i, j] != "X")
                    {
                        ganador1 = false;
                    }
                    if (tablero[j, i] == "X")
                    {
                        ganador1= false;
                    }
                }
            }

            if (ganador1)
            {
                return "Jugador 1";
            }
            else if (ganador2)
            {
                return "Jugador 2";
            }

            return null;

        }

    }
}
