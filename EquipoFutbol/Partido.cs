using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Partido
    {
        Equipo equipo;
        Equipo equipo2;
        (int, int) marcador;
        public Partido(Equipo equipo, Equipo equipo2, (int, int) marcador) 
        { 
            this.equipo = equipo;
            this.equipo2 = equipo2;
            this.marcador = marcador;
        }

        public Equipo Equipo { get => equipo; set => equipo = value; }
        public Equipo Equipo2 { get => equipo2; set => equipo2 = value; }
        public (int, int) Marcador { get => marcador; set => marcador = value; }

        public override string ToString()
        {
            return "Equipo Local: "+ equipo.Nombre + " | Equipo Visitente : "+ equipo2.Nombre + " | Resultado : " + marcador.Item1 + " - " + marcador.Item2;
        }
    }
}
