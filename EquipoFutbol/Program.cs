using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
                Console.WriteLine("4. Jugar partido");
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
                            ChooseStartingLineUp(equipo);
                            ChooseStartingLineUp(equipo2);
                            Partido partido = new Partido(equipo, equipo2, JugarPartido(equipo, equipo2));
                            Console.WriteLine(partido.ToString());
                            break;
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

            Jugador jugador = null;
            Portero portero = null;
            
            if (posicion != Jugador.ePosicion.Portero)
                jugador = new Jugador(nombre, posicion, dorsal, pierna, sueldo, 0, 0, 0, probabilidadGol);
            
            else
            {
                Console.WriteLine("Probabilidad de parada?");
                double probabilidadParada = double.Parse(Console.ReadLine());
                portero = new Portero(nombre, posicion, dorsal, pierna, sueldo, 0, 0, 0, probabilidadGol, probabilidadParada);
            }

            Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
            string nombreEquipo = Console.ReadLine();

            bool foundTeam = false;
            while (!foundTeam)
            {
              if (equipo.Nombre == nombreEquipo)
              {
                  equipo.Jugadores.Add(jugador ?? portero);
                  equipo.NumeroJugadores += 1;
                  equipo.Presupuesto -= sueldo;
                  foundTeam = true;
              }
              else if (equipo2.Nombre == nombreEquipo)
              {
                  equipo2.Jugadores.Add(jugador ?? portero);
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

        static void ChooseStartingLineUp(Equipo team)
        {
            int titulares = 0;
            team.PorteroTitular = null; // we erease the titular goalkeeper
            
            while (titulares < 5)
            {
                Console.WriteLine("Escoje un dorsal para que salga de titular: ");

                if (int.TryParse(Console.ReadLine(), out int dorsal))
                {
                    int indice = team.Jugadores.FindIndex(p => p.Dorsal == dorsal);
                    if (indice < 0)
                        Console.WriteLine($"El dorsal {dorsal} no pertenece al equipo {team.Nombre}");

                    else if (team.Jugadores[indice].Posicion == Jugador.ePosicion.Portero)
                    {
                        if (team.PorteroTitular != null)
                            Console.WriteLine("El portero titular ya esta asignado y solo puede haber un portero titular");

                        else
                        {
                            string control = team.ChangePlayers(team.Jugadores[indice], null);
                            if (control != "")
                                Console.WriteLine(control);
                            else
                                ++titulares;

                        }
                    }

                    else if (titulares == 4 && team.PorteroTitular == null)
                        Console.WriteLine("Necesitas un portero! Introduce el dorsal de un portero");

                    else
                    {
                        string control = team.ChangePlayers(team.Jugadores[indice], null);
                        if (control != "")
                            Console.WriteLine(control);
                        else
                            ++titulares;
                    }
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

            List<Jugador> jugadoresLocal = new List<Jugador>();
            foreach (Jugador player in equipoLocal.Jugadores)
            {
                if (player.JugandoPartido)
                    jugadoresLocal.Add(player);
            }

            List<Jugador> jugadoresVisitante = new List<Jugador>();
            foreach (Jugador player in equipoVisitante.Jugadores)
            {
                if (player.JugandoPartido)
                    jugadoresVisitante.Add(player);
            }

            for (int i = 0; i < ocasionesLocal; ++i)
            {
                Jugador shooter = jugadoresLocal[random.Next(jugadoresLocal.Count() - 1)];

                if (ShootEndsInGoal(shooter, equipoVisitante.PorteroTitular))
                {
                    ++golesLocal;
                    ++shooter.Goles;
                }
            }

            for (int i = 0; i < ocasionesVisitante; ++i)
            {
                Jugador shooter = jugadoresVisitante[random.Next(jugadoresVisitante.Count() - 1)];

                if (ShootEndsInGoal(shooter, equipoLocal.PorteroTitular))
                {
                    ++golesVisitante;
                    ++shooter.Goles;
                }
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
