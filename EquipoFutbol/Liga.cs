using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoFutbol
{
    public class Liga
    {
            List<Equipo> equipos;

            public Liga()
            {
                equipos = new List<Equipo>();
            }

            public List<Equipo> Equipos { get => equipos; set => equipos = value; }


        public void CrearEquipo()
        {
            Console.WriteLine("Cuál es el nombre de tu equipo?");
            string nombre = Console.ReadLine();
            Console.WriteLine("Cuál es el presupuesto de tu equipo?");
            double presupuesto = Double.Parse(Console.ReadLine());
            Equipo equipo = new Equipo(nombre, presupuesto, 0, null);
            Console.WriteLine("Cuál es el nombre del segundo equipo?");
            string nombre2 = Console.ReadLine();
            Console.WriteLine("Cuál es el presupuesto del segundo equipo?");
            double presupuesto2 = Double.Parse(Console.ReadLine());
            Equipo equipo2 = new Equipo(nombre2, presupuesto2, 0, null);
            this.equipos.Add(equipo);
            this.equipos.Add(equipo2);
        }

    }

}

