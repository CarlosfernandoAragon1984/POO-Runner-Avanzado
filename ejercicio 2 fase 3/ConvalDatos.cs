using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio_2_fase_3
{
    static class ConvalDatos
    {
        public static string PedirStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("No puede ser vacío");
                }
            } while (valor == "");

            return valor;
        }

        public static double PedirDouble(string mensaje, double min, double max)
        {
            double valor;
            bool valido = false;
            string mensError = "Debe ingresar un valor entre " + min + " y " + max;

            do
            {
                Console.WriteLine(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else
                {
                    if (valor < min || valor > max)
                    {
                        Console.WriteLine(mensError);
                    }
                    else
                    {
                        valido = true;
                    }
                }
            } while (!valido);

            return valor;
        }
    }
}
