using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
        public class Club
        {
            List<Equipo> equipos;

            public Club(List<Equipo> equipos)
            {
                this.equipos = new List<Equipo>();
            }

            public List<Equipo> Equipos { get => equipos; set => equipos = value; }
        }
 }

