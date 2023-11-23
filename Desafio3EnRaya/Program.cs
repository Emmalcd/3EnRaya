using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Schema;

namespace Desafio3EnRaya
{
    internal class Program
    {
        static string jugador1 = string.Empty;
        static string jugador2 = string.Empty;
        static char[,] tablero = {
            {'1','2','3' },
            {'4','5','6' },
            {'7','8','9' }
        };
        static bool tiroValido = true;
        static int casillaElegida;
        static int casillaRecorrida = 0;
        static int jugada = 0;

        static void Main(string[] args)
        {
            darBienvenida();
            Console.Clear();
            jugador1 = pedirNombreJugador(1);
            jugador2 = pedirNombreJugador(2);
            do
            {
                pintarTablero();
                pideJugada(1, 'X');
                pintarTablero();
                if (verificaGanador())
                    break;
                pideJugada(2, '0');
                pintarTablero();
                verificaGanador();
                if (jugada == 9)
                    break;

            } while (!verificaGanador());

            juegoTerminado();

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
            Console.WriteLine("Escribe el nombre del jugador " + num + ":");
            return Console.ReadLine();
        }

        static void pintarTablero()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"  |{tablero[i, j]}|  ");
                }
                Console.WriteLine();
                if (i != 2)
                    Console.WriteLine("---------------------");
            }
        }

        static void pideJugada(int jugador, char caracter)
        {
            casillaRecorrida = 0;
            Console.WriteLine($"\n\nTurno del jugador {jugador} ({caracter}): ");
            Console.WriteLine("Ingresa el número de casilla donde deseas tirar (1-9)");
            do
            {
                if (!tiroValido)
                {
                    Console.WriteLine("El tiro no puede ejecutarse en la casilla seleccionada por favor elije otra");
                }
                tiroValido = validaTiro(Console.ReadLine());

            } while (!tiroValido);
            casillaRecorrida = 0;
            if (jugador == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        casillaRecorrida++;
                        if (casillaElegida == casillaRecorrida)
                        {
                            tablero[i, j] = 'X';
                            jugada++;
                            break;
                        }
                    }
                    if (casillaElegida == casillaRecorrida)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        casillaRecorrida++;
                        if (casillaElegida == casillaRecorrida)
                        {
                            tablero[i, j] = '0';
                            jugada++;
                            break;
                        }
                    }
                    if (casillaElegida == casillaRecorrida)
                    {
                        break;
                    }
                }
            }
        }

        static bool validaTiro(string jugada)
        {
            if (!int.TryParse(jugada, out casillaElegida))
            {
                return false;
            }
            else
            {
                if ((casillaElegida >= 1) && (casillaElegida <= 9))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            casillaRecorrida++;
                            if (casillaElegida == casillaRecorrida)
                            {
                                return (casillaElegida == 'X' || casillaElegida == '0') ? false : true;
                            }

                        }
                        if (casillaElegida == casillaRecorrida)
                        {
                            break;
                        }

                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
        }

        static bool verificaGanadorHorizontal()
        {
            for (int i=0;i<3;i++)
            {
                if (tablero[i,0]== tablero[i, 1])
                {
                    if (tablero[i, 1] == tablero[i, 2])
                        return true;
                }
            }
            return false;
        }
        static bool verificaGanadorVertical()
        {
            for (int j = 0; j < 3; j++)
            {
                if (tablero[0, j] == tablero[1,j])
                {
                    if (tablero[1, j] == tablero[2, j])
                        return true;
                }
            }
            return false;

        }
        static bool verificaGanadorDiagonal1()
        {
            if (tablero[0, 0] == tablero[2, 2])
            {
                if (tablero[2, 2] == tablero[1, 1])
                {
                    return true;
                }
            }
            return false;
        }
        static bool verificaGanadorDiagonal2()
        {
            if (tablero[0, 2] == tablero[1, 1])
            {
                if (tablero[1, 1] == tablero[2, 0])
                {
                    return true;
                }
            }
            return false;

        }
        static bool verificaGanador()
        {
            if (verificaGanadorHorizontal() || verificaGanadorVertical())
            {
               return true;
            }
            else if(verificaGanadorDiagonal1()||verificaGanadorDiagonal2())
            {
                return true;
            }
            return false;
        }

        static void juegoTerminado()
        {
            if (jugada == 9)
            {
            Console.WriteLine("El juego ha terminado en empate.");
            }
            else
            {
                if (jugada % 2 == 0)
                {
                    Console.WriteLine($"El jugador {jugador2} ha resultado ganador");
                }
                else
                {
                    Console.WriteLine($"El jugador {jugador1} ha resultado ganador");
                }

            }
        }

        static void pregunta(int resp)
        {
            if (resp == 1)
            {
                darBienvenida();
                Console.Clear();
                jugador1 = pedirNombreJugador(1);
                jugador2 = pedirNombreJugador(2);
                do
                {
                    pintarTablero();
                    pideJugada(1, 'X');
                    pintarTablero();
                    if (verificaGanador())
                        break;
                    pideJugada(2, '0');
                    pintarTablero();
                    verificaGanador();
                    if (jugada == 9)
                        break;

                } while (!verificaGanador());

                juegoTerminado();
            }
            else
            {
                Console.WriteLine("Este es el final del juego, gracias por jugar");
                return;
            }
        }

    }
}


