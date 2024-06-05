using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Testing
    {

        public Testing() { }

        public Equipo CreateTeam(string name) 
        { 
            List<Jugador> jugadores = new List<Jugador>();
            
            jugadores.Add(CreatePlayer("A", Jugador.ePosicion.Delantero, 1));
            jugadores.Add(CreatePortero("B", Jugador.ePosicion.Portero, 2));
            

            return new Equipo(name, 0, 2, jugadores);
        }

        public Jugador CreatePlayer(string nombre, Jugador.ePosicion posicion, int dorsal)
        {

            return new Jugador(nombre, posicion, dorsal, Jugador.ePierna.Ambidiestro, 0, 0, 0, 0, 10);
        }

        public Portero CreatePortero(string nombre, Jugador.ePosicion posicion, int dorsal)
        {
            return new Portero(nombre, posicion, dorsal, Jugador.ePierna.Ambidiestro, 0, 0, 0, 0, 10, 10);
        }
    }
}
