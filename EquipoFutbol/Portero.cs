using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Portero : Jugador
    {
        public double ProbabilidadParada;

        public Portero(string nombre, ePosicion posicion, int dorsal, ePierna pierna, double sueldo, int goles, int asistencias, int partidosJugados, double probabilidadGol, double probabilidadParada) : base(nombre, posicion, dorsal, pierna, sueldo, goles, asistencias, partidosJugados, probabilidadGol)
        {
            ProbabilidadParada = probabilidadParada;
        }
    }
}
