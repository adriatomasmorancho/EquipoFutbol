using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    internal class Program
    {
        static Equipo equipo;
        static Equipo equipo2;
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
        static void Menu()
        {
            bool salir = false;


            while (!salir)
            {
                Console.WriteLine("Menu Equipo");
                Console.WriteLine("1. Crear los dos equipos");
                Console.WriteLine("2. Altas del equipo");
                Console.WriteLine("3. Listar equipo");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Selecciona una opción:");

                int opcion;

                if (int.TryParse(Console.ReadLine(), out opcion))
                {

                    switch (opcion)
                    {
                        case 1:
                            CrearEquipo();
                            break;
                        case 2:
                            AltaJugador();
                            break;
                        case 3:
                            ListarEquipo();
                            break;
                        case 4:

                        case 0:
                            salir = true;
                            Console.WriteLine("El programa ha finalizado.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, introduce un número que sea válido.");
                }

            }
        }


        static void CrearEquipo()
        {
            Console.WriteLine("Cuál es el nombre de tu equipo?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cuál es el presupuesto de tu equipo?");
            double presupuesto = Double.Parse(Console.ReadLine());
            equipo = new Equipo(nombre, presupuesto, 0, null);
            Console.WriteLine("Cuál es el nombre del segundo equipo?");
            string nombre2 = Console.ReadLine();
            Console.WriteLine("Cuál es el presupuesto del segundo equipo?");
            double presupuesto2 = Double.Parse(Console.ReadLine());
            equipo2 = new Equipo(nombre2, presupuesto2, 0, null);

        }
        static void AltaJugador()
        {
            Console.WriteLine("Cuál es el nombre de tu nuevo jugador?");
            string nombre = Console.ReadLine();
            Jugador.ePosicion posicion;
            while (true)
            {
                Console.WriteLine("En qué posición juega tu nuevo jugador? (Delantero, Mediocentro, Defensa, Portero)");
                string posicionStr = Console.ReadLine();
                if (Enum.TryParse(posicionStr, true, out posicion))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Posición no válida. Por favor, introduce una posición válida.");
                }
            }
            Console.WriteLine("Que dorsal lleva tu nuevo jugador?");
            int dorsal = int.Parse(Console.ReadLine());
            Jugador.ePierna pierna;
            while (true)
            {
                Console.WriteLine("Cuál es la pierna buena de tu nuevo jugador? (Izquierda, Derecha, Ambidiestro)");
                string piernaStr = Console.ReadLine();
                if (Enum.TryParse(piernaStr, true, out pierna))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Pierna no válida. Por favor, introduce una pierna válida.");
                }
            }
            Console.WriteLine("Cuanto cobrara por temporada tu nuevo jugador?");
            double sueldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Probabilidad de gol?");
            double probabilidadGol = double.Parse(Console.ReadLine());
            Jugador jugador = new Jugador(nombre, posicion, dorsal, pierna, sueldo,0,0,0, probabilidadGol);
            Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
            string nombreEquipo = Console.ReadLine();

            bool foundTeam = false;
            while (!foundTeam)
            {
              if (equipo.Nombre == nombreEquipo)
              {
                  equipo.Jugadores.Add(jugador);
                  equipo.NumeroJugadores += 1;
                  equipo.Presupuesto -= sueldo;
                  foundTeam = true;
              }
              else if (equipo2.Nombre == nombreEquipo)
              {
                  equipo2.Jugadores.Add(jugador);
                  equipo2.NumeroJugadores += 1;
                  equipo2.Presupuesto -= sueldo;
                  foundTeam = true;
              }
              else
              {
                  Console.WriteLine("No existe ningun equipo con este nombre!");
                  Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
                  nombreEquipo = Console.ReadLine();
              }
            }
            
        }

        static void ListarEquipo()
        {
            Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
            string nombreEquipo = Console.ReadLine();

            bool foundTeam = false;
            while (!foundTeam)
            {

                if (equipo.Nombre == nombreEquipo)
                {
                    foreach (var item in equipo.Jugadores)
                    {
                        Console.WriteLine(item.ToString());

                    }
                    foundTeam = true;
                }
                else if (equipo2.Nombre == nombreEquipo)
                {
                    foreach (var item in equipo2.Jugadores)
                    {
                        Console.WriteLine(item.ToString());

                    }
                    foundTeam = true;
                }
                else
                {
                    Console.WriteLine("No existe ningun equipo con este nombre!");
                    Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
                    nombreEquipo = Console.ReadLine();
                }
            }
            
        }

        // returns the score of the match
        static Tuple<int, int> JugarPartido(Equipo equipoLocal, Equipo equipoVisitante)
        {
            int golesLocal = 0;
            int golesVisitante = 0;

            Random random = new Random();

            int ocasionesLocal = random.Next(10); // máximo 10 ocasiones
            int ocasionesVisitante = random.Next(10);

            for (int i = 0; i < ocasionesLocal; ++i)
            {
            }

            return Tuple.Create(golesLocal, golesVisitante);
        }


        // returns wether a shoot ends or not in goal
        static bool ShootEndsInGoal(Jugador shooter, Portero portero)
        {
            Random random = new Random();
            int porcentajeGol = (int)(shooter.ProbabilidadGol*100);
            int porcentajeSalvada = (int)(portero.ProbabilidadParada*100);
            return random.Next(porcentajeGol) > random.Next(porcentajeSalvada);
        }
    }
}
