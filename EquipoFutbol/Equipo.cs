using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Equipo
    {
        string nombre;
        double presupuesto;
        int numeroJugadores;
        List<Jugador> jugadores;
        Portero porteroTitular;

        public Equipo(string nombre, double presupuesto, int numeroJugadores, List<Jugador> jugadores)
        {
            this.nombre = nombre;
            this.presupuesto = presupuesto;
            this.numeroJugadores = numeroJugadores;
            this.jugadores = new List<Jugador>();
            porteroTitular = null;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Presupuesto { get => presupuesto; set => presupuesto = value; }
        public int NumeroJugadores { get => numeroJugadores; set => numeroJugadores = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public Portero PorteroTitular { get => porteroTitular; set => porteroTitular = value; }





        // cambiamos un titular por un jugador que aún no esta jugando
        public string ChangePlayers(Jugador substituto, Jugador titular)
        {
            string s = "";
            if (substituto.JugandoPartido)
                s = $"El jugador {substituto.Nombre} ya esta en el terreno de juego";

            else if (titular == null)
            {
                substituto.JugandoPartido = true;
                if (substituto.Posicion == Jugador.ePosicion.Portero)
                    porteroTitular = (Portero)substituto;
            }

            else if (!titular.JugandoPartido)
                s = $"El jugador {titular.Nombre} ya esta en el terreno de juego";

            else if (substituto.Posicion != titular.Posicion)
                s = $"El jugador substituido y el titular deben ser del mismo tipo";

            else
            {
                titular.JugandoPartido = false;
                substituto.JugandoPartido = true;

                if (substituto.Posicion == Jugador.ePosicion.Portero)
                    porteroTitular = (Portero)substituto;
            }

            return s;
        }

        public void AltaJugador()
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
            {
                jugador = new Jugador(nombre, posicion, dorsal, pierna, sueldo, 0, 0, 0, probabilidadGol);
                this.Jugadores.Add(jugador);
            }
            else
            {
                Console.WriteLine("Probabilidad de parada?");
                double probabilidadParada = double.Parse(Console.ReadLine());
                portero = new Portero(nombre, posicion, dorsal, pierna, sueldo, 0, 0, 0, probabilidadGol, probabilidadParada);
                this.Jugadores.Add(portero);
            }



        }

    

        public void ListarEquipo()
        {

            if (Jugadores.Count == 0)
            {
                Console.WriteLine("No hay jugadores en el equipo.");
                return;
            }

            foreach (var jugador in Jugadores)
            {
                Console.WriteLine(jugador.ToString());
            }
            Console.WriteLine("Fin del listado de jugadores.");

        }
    }
}

