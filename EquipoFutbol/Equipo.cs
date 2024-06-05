using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Equipo(string nombre, double presupuesto, int numeroJugadores, List<Jugador> jugadores) 
        {
            this.nombre = nombre;
            this.presupuesto = presupuesto;
            this.numeroJugadores = numeroJugadores;
            this.jugadores = new List<Jugador>();

        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Presupuesto { get => presupuesto; set => presupuesto = value; }
        public int NumeroJugadores { get => numeroJugadores; set => numeroJugadores = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
    }
}
