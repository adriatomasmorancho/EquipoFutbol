using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Jugador
    {
        public enum ePierna { Izquierda, Derecha, Ambidiestro };
        public enum ePosicion { Delantero, Mediocentro, Defensa, Portero };

        string nombre;
        ePosicion posicion;
        int dorsal;
        ePierna pierna;
        double sueldo;
        int goles;
        int asistencias;
        int partidosJugados;
        double probabilidadGol;
        public Jugador(string nombre, ePosicion posicion, int dorsal, ePierna pierna, double sueldo, int goles, int asistencias, int partidosJugados, double probabilidadGol) 
        {
            this.nombre = nombre;
            this.posicion = posicion;
            this.dorsal = dorsal;
            this.pierna = pierna;
            this.sueldo = sueldo;
            this.goles = goles;
            this.asistencias = asistencias;
            this.partidosJugados = partidosJugados;

            this.probabilidadGol = probabilidadGol;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Dorsal { get => dorsal; set => dorsal = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public int Goles { get => goles; set => goles = value; }
        public int Asistencias { get => asistencias; set => asistencias = value; }
        public int PartidosJugados { get => partidosJugados; set => partidosJugados = value; }
        public ePosicion Posicion { get => posicion; set => posicion = value; }
        public ePierna Pierna { get => pierna; set => pierna = value; }

        public double ProbabilidadGol { get => probabilidadGol; set => probabilidadGol = value; }

        public override string ToString()
        {
            return "Nombre jugador: " + Nombre + " | posición: " + Posicion + " | dorsal: "+ Dorsal + " | pierna: " + Pierna + " | sueldo: " + Sueldo + " | goles: "+ Goles + " | asistencias: "+ Asistencias+ " | partidos jugados: " +PartidosJugados;
            
        }
    }
}
