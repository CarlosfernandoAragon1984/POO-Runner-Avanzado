using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio_2_fase_3
{
    class Sesiones
    {
        private const double minKm= 1, maxKm = 50;
        public string codigo { get; private set ; }
        public double kilometros { get;private set ; }

        public Sesiones(string codSesion, double kmses)
        {
            codigo = "";
            kilometros = 0;
            if(kmses>=minKm && kmses <= maxKm)
            {
                codigo = codSesion;
                kilometros = kmses;
            }
        }
    }
}
