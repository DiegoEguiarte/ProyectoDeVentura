using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
  
    class Pregunta
    {
        public string pregunta = "";
        public int correcta;
        public string opcion1 = "";
        public string opcion2 = "";
        public string opcion3 = "";
    }
    class Program
    {
        public Pregunta[] preguntas;
        int preguntaActual = -1;
        //Dado para elegir entre 1 y 6
        public static int Dado()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
        //Opciones que se plasman
        public bool NuevaPregunta()
        {
            preguntaActual++;
            char respuesta;
            Console.WriteLine(preguntas[preguntaActual].pregunta);
            Console.WriteLine("a)" + preguntas[preguntaActual].opcion1);
            Console.WriteLine("b)" + preguntas[preguntaActual].opcion2);
            Console.WriteLine("c)" + preguntas[preguntaActual].opcion3);
            Console.Write("Respuesta: ");

            respuesta = Console.ReadLine().ToCharArray()[0];

            //Validar respuesta
            if (respuesta == preguntas[preguntaActual].correcta)
            {
                Console.WriteLine("\nRespuesta Correcta!! ");
                return true;
            }

            else
            {
                Console.WriteLine("\nRespuesta Incorrecta!! ");
                return false;
            }
        }
        //Lectura de archivos
        public void LeerPreguntas(string archivo)
        {
            string[] lines = System.IO.File.ReadAllLines(archivo + ".txt");
            preguntas = new Pregunta[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                preguntas[i] = new Pregunta();
                string[] aux = lines[i].Split(',');
                preguntas[i].pregunta = aux[0];
                preguntas[i].correcta = aux[1].ToCharArray()[0];
                preguntas[i].opcion1 = aux[2];
                preguntas[i].opcion2 = aux[3];
                preguntas[i].opcion3 = aux[4];
            }
        }

        static void Main(string[] args)
        {
            int j1 = 0, j2 = 0, j3 = 0, ignorancia = 0;
            int turno = 1;

            Program deportes = new Program();
            Program ciencias = new Program();
            Program geografia = new Program();
            Program matematicas = new Program();
            Program historia = new Program();
            Program espaniol = new Program();

            deportes.LeerPreguntas("Deportes");
            ciencias.LeerPreguntas("Ciencias");
            geografia.LeerPreguntas("Geografia");
            matematicas.LeerPreguntas("Matematicas");
            historia.LeerPreguntas("Historia");
            espaniol.LeerPreguntas("Espaniol");


            while (j1 < 10 && j2 < 10 && j3 < 10 && ignorancia < 10)
            {
                int num = Dado();

                if (turno % 3 == 0)
                {
                    //Turno j3
                    Console.WriteLine("Turno del jugador 3 ...");
                }
                else if (turno % 3 == 2)
                {
                    //Turno j2
                    Console.WriteLine("Turno del jugador 2 ... ");
                }
                else
                {
                    //Turno j1
                    Console.WriteLine("Turno del jugador 1 ... ");
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

                Console.WriteLine("\nDado: " + num);
                bool respuestaCorrecta = false;

                //Seleccionar el tipo de preguntas
                switch (num)
                {
                    case 1:
                        respuestaCorrecta = deportes.NuevaPregunta();
                        break;
                    case 2:
                        respuestaCorrecta = ciencias.NuevaPregunta();
                        break;
                    case 3:
                        respuestaCorrecta = geografia.NuevaPregunta();
                        break;
                    case 4:
                        respuestaCorrecta = matematicas.NuevaPregunta();
                        break;
                    case 5:
                        respuestaCorrecta = historia.NuevaPregunta();
                        break;
                    case 6:
                        respuestaCorrecta = espaniol.NuevaPregunta();
                        break;
                }

                if (respuestaCorrecta)
                {
                    if (turno % 3 == 0)
                    {
                        //Turno j3
                        j3 += num;
                        Console.WriteLine("El jugador 3 avanza a la casilla: " + j3);
                    }

                    else if (turno % 3 == 2)
                    {
                        //Turno j2
                        j2 += num;
                        Console.WriteLine("El jugador 2 avanza a la casilla: " + j2);
                    }

                    else
                    {
                        //Turno j1
                        j1 += num;
                        Console.WriteLine("El jugador 1 avanza a la casilla: " + j1);
                    }
                }

                else
                {
                    ignorancia += num;
                    Console.WriteLine("La ignorancia avanza a la casilla: " + ignorancia);
                }

                //Marcador
                Console.WriteLine("\n\nMarcador:\n Jugador 1: " + j1 + "\n Jugador 2: " + j2 + "\n Jugador 3: " + j3 + "\n Ignorancia: " + ignorancia);

                Console.ReadKey();
                //Limpiar consola
                Console.Clear();

                turno++;
            }

            Console.WriteLine("Fin del juego!");
            //Desplegar el ganador
            if (j3 >= 10)
                Console.WriteLine("\nEl ganador es el jugador 3");
            else if (j2 >= 10)
                Console.WriteLine("\nEl ganador es el jugador 2");
            else if (j1 >= 10)
                Console.WriteLine("\nEl ganador es el jugador 1");
            else
                Console.WriteLine("\nHa ganado la Ignorancia");
        }
    }
}
