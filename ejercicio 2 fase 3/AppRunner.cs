using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio_2_fase_3
{
    class AppRunner
    {
        private const string fijarObjetivo = "O", agregarSesion = "A",borrarSesion="B", estadisticas = "E", salir = "S";
        private string Opcion = "";



        public void MenuPrincipal(Runner unRunner)
        {
            do
            {
                Console.WriteLine("Menú Principal");
                Console.WriteLine(fijarObjetivo + "-Fijar Objetivo");
                Console.WriteLine(agregarSesion + "-Agregar Sesión");
                Console.WriteLine(borrarSesion + "-Quitar Sesión");
                Console.WriteLine(estadisticas + "-Ver Estadística");
                Console.WriteLine(salir + "-Salir");
                Opcion = ConvalDatos.PedirStrNoVac("Eliga una Opción");
                switch (Opcion)
                {
                    case fijarObjetivo:
                        FijarObjetivo(unRunner);
                        break;
                    case agregarSesion:
                        AgregarSesion(unRunner);
                        break ;
                    case borrarSesion:
                        BorrarSesion(unRunner);
                        break;
                    case estadisticas:
                        Console.WriteLine(unRunner.Estadistica());
                        break;
                    case salir:
                        break;
                    default:
                        break;
                }
            } while (Opcion != salir);

        }
        public void FijarObjetivo(Runner unRunner)
        {
            unRunner.ObjetivoKm = ConvalDatos.PedirDouble("Ingrese el objetivo en km", 1, 500);
            unRunner.ObjetivoKmXSes = ConvalDatos.PedirDouble("Ingrese el objetivo por sesión", 1, 50);
        }
        public void AgregarSesion(Runner unRunner)
        {
            double Kilometros = 0;
            string retorno = "",codigo = "";

           
            
                Kilometros = ConvalDatos.PedirDouble("Ingrese los km recorridos", 1, 50);
                do
                {
                    codigo = ConvalDatos.PedirStrNoVac("Ingrese el Código de sesión");
                    retorno = unRunner.GuardarSesion(codigo, Kilometros);
                    if (retorno == "No hay más lugar")
                    {
                        Console.WriteLine("No se pudo guardar la sesión: " + retorno);
                    }
                    if (retorno == "Código Repetido")
                    {
                        Console.WriteLine("No se pudo guardar la sesión: " + retorno);
                    }

                } while (retorno == "Código Repetido");

                if (retorno == "")
                {
                    Console.WriteLine("Se guardó la sesión: " + codigo);
                }
            
          
          
        }
        public void BorrarSesion(Runner unRunner)
        {
            string Codigo = "",retorno="";
            const int maximasesiones = 2;
          
            if (unRunner.sesionesDisponibles == maximasesiones)
            {
                Console.WriteLine("No hay sesiones ingresadas");
            }
            else
            {

                Codigo = ConvalDatos.PedirStrNoVac("Ingrese el código de la sesión que desea borrar");
                retorno = unRunner.QuitarSesion(Codigo);
              
                if (retorno == "Código no exitente")
                {
                    Console.WriteLine("No se pudo borrar la sesión: " + retorno);
                }

                if (retorno == "")
                {
                    Console.WriteLine("Se borró la sesión: " + Codigo);
                }
            }
           
        }
    }
}
