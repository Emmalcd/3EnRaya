using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Desafio3EnRaya
{
    internal class Program
    {
        static string jugador1=string.Empty;
        static string jugador2=string.Empty;
        static string[,] tablero = {
            {"1","2","3" },
            {"4","5","6" },
            {"7","8","9" }
        };
        static void Main(string[] args)
        {
            darBienvenida();
            Console.Clear();
            jugador1 = pedirNombreJugador(1);
            jugador2 = pedirNombreJugador(2);
            Console.Clear();
            pintarTablero();

            
            Console.ReadLine();
        }
        static void darBienvenida()
        {
            Console.WriteLine("Bienvenido al juego de 3 en raya...");
            Console.WriteLine("\n");
            Console.WriteLine("Oprime cualquier tecla para continuar...");
            Console.ReadLine();
            return;
        }
        static string pedirNombreJugador(int num)
        {
            Console.WriteLine("Escribe el nombre del jugador "+ num+":");
            return Console.ReadLine();
        }

        static void pintarTablero()
        {
            Console.Clear();
            for(int i =0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write($"  |{tablero[i, j]}|  ");
                }
                Console.WriteLine();
                if(i!=2)
                Console.WriteLine("---------------------");
            }
        }


    }

}

