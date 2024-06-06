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
        static Liga liga;
        static int sizeTeam = 2;
        static void Main(string[] args)
        {
            liga = new Liga();
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
                            liga.CrearEquipo();
                            break;
                        case 2:
                            Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador?");
                            string nombreEquipo = Console.ReadLine();

                            bool foundTeam = false;
                            while (!foundTeam)
                            {
                                Equipo equipo = liga.Equipos.Find(m => m.Nombre.Equals(nombreEquipo, StringComparison.Ordinal));
                                if (equipo != null)
                                {
                                    equipo.AltaJugador();
                                    foundTeam = true;
                                }
                                else
                                {
                                    Console.WriteLine("No existe ningún equipo con este nombre.");
                                    Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador:");
                                    nombreEquipo = Console.ReadLine();
                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Introduce el nombre del equipo que quieres listar sus jugadores ");
                            nombreEquipo = Console.ReadLine();

                            foundTeam = false;
                            while (!foundTeam)
                            {
                                Equipo equipo = liga.Equipos.Find(m => m.Nombre.Equals(nombreEquipo, StringComparison.Ordinal));
                                if (equipo != null)
                                {
                                    equipo.ListarEquipo();
                                    foundTeam = true;
                                }
                                else
                                {
                                    Console.WriteLine("No existe ningún equipo con este nombre!");
                                    Console.WriteLine("Introduce el nombre del equipo para el que quieres el nuevo jugador:");
                                    nombreEquipo = Console.ReadLine();
                                }
                            }
                            break;
                        case 4:
                            foreach (var item in liga.Equipos)
                            {
                                ChooseStartingLineUp(item);
                            }
                           Partido partido = new Partido(liga.Equipos[0], liga.Equipos[1], JugarPartido(liga.Equipos[0], liga.Equipos[1]));
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

       

        

        static void ChooseStartingLineUp(Equipo team)
        {
            int titulares = 0;
            team.PorteroTitular = null; // we erease the titular goalkeeper
            
            while (titulares < sizeTeam)
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

                    else if (titulares == sizeTeam - 1 && team.PorteroTitular == null)
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
        static (int, int) JugarPartido(Equipo equipoLocal, Equipo equipoVisitante)
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
                    Console.WriteLine($"Gol de {shooter.Nombre}");
                }
                else
                    Console.WriteLine($"Oportunidad fallada por {shooter.Nombre}");
            }

            for (int i = 0; i < ocasionesVisitante; ++i)
            {
                Jugador shooter = jugadoresVisitante[random.Next(jugadoresVisitante.Count() - 1)];

                if (ShootEndsInGoal(shooter, equipoLocal.PorteroTitular))
                {
                    ++golesVisitante;
                    ++shooter.Goles;
                    Console.WriteLine($"Gol de {shooter.Nombre}");
                }
                else
                    Console.WriteLine($"Oportunidad fallada por {shooter.Nombre}");
            }

            return (golesLocal, golesVisitante);
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
