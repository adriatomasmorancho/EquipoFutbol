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

            else if (substituto.Posicion == titular.Posicion)
                s = $"El jugador substituido y el substituto deben ser del mismo tipo";

            else
            {
                titular.JugandoPartido = false;
                substituto.JugandoPartido = true;

                if (substituto.Posicion == Jugador.ePosicion.Portero)
                    porteroTitular = (Portero)substituto;
            }

            return s;
        }


        public void ListarEquipo(Equipo equipo, Equipo equipo2)
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
    }
}
