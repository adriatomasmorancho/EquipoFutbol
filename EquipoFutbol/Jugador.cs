using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Jugador
    {
        string nombre;
        string posicion;
        int dorsal;
        string pierna;
        double sueldo;
        int goles;
        int asistencias;
        int partidosJugados;
        public Jugador(string nombre, string posicion, int dorsal, string pierna, double sueldo, int goles, int asistencias, int partidosJugados) 
        {
            this.nombre = nombre;
            this.posicion = posicion;
            this.dorsal = dorsal;
            this.pierna = pierna;
            this.sueldo = sueldo;
            this.goles = goles;
            this.asistencias = asistencias;
            this.partidosJugados = partidosJugados;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Posicion { get => posicion; set => posicion = value; }
        public int Dorsal { get => dorsal; set => dorsal = value; }
        public string Pierna { get => pierna; set => pierna = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public int Goles { get => goles; set => goles = value; }
        public int Asistencias { get => asistencias; set => asistencias = value; }
        public int PartidosJugados { get => partidosJugados; set => partidosJugados = value; }

        public override string ToString()
        {
            return "Nombre jugador: " + Nombre + " | posición: " + Posicion + " | dorsal: "+ Dorsal + " | pierna: " + Pierna + " | sueldo: " + Sueldo + " | goles: "+ Goles + " | asistencias: "+ Asistencias+ " | partidos jugados: " +PartidosJugados;
            
        }
    }
}
