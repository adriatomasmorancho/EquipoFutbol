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
                Console.WriteLine("1. Crear equipo");
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

        }
        static void AltaJugador()
        {
            Console.WriteLine("Cuál es el nombre de tu nuevo jugador?");
            string nombre = Console.ReadLine();
            Console.WriteLine("En que posición juega tu nuevo jugador?");
            string posicion = Console.ReadLine();
            Console.WriteLine("Que dorsal lleva tu nuevo jugador?");
            int dorsal = int.Parse(Console.ReadLine());
            Console.WriteLine("Cual es la pierna buena de tu nuevo jugador?");
            string pierna = Console.ReadLine();
            Console.WriteLine("Cuanto cobrara por temporada tu nuevo jugador?");
            double sueldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Probabilidad de gol?");
            double probabilidadGol = double.Parse(Console.ReadLine());

            Jugador jugador = new Jugador(nombre, posicion, dorsal, pierna, sueldo,0,0,0, probabilidadGol);
            equipo.Jugadores.Add(jugador);
            equipo.NumeroJugadores += 1;
            equipo.Presupuesto -= sueldo;
        }

        static void ListarEquipo()
        {
            foreach (var item in equipo.Jugadores)
            {
                Console.WriteLine(item.ToString());
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
