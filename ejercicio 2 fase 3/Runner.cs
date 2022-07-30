using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio_2_fase_3
{
    class Runner
    {
        private const double kmSesMax = 50, kmSesMin = 1, KmObjMax = 500, KmObjeMin = 1;
        private double kmObjetivo = 0, objetivoKmSes = 0;
        private double kmSes = 0;
        private const int maxSesiones = 2;
       
        Sesiones[] miSesiones = new Sesiones[maxSesiones];

        public Runner()
        {
            int ses = 0;
            kmTotalR = 0;

            this.sesionesDisponibles = maxSesiones;
            do
            {
                miSesiones[ses] = new Sesiones("",0);
                ses++;

            } while (ses <= miSesiones.GetUpperBound(0));
        }


        public int sesionesDisponibles { get; private set; }


        public double ObjetivoKmXSes
        {
            set
            {
                if (value >= kmSesMin && value <= kmSesMax)
                {
                    objetivoKmSes = value;
                }

            }
            get
            {
                return objetivoKmSes;
            }
        }
        public double kmTotalR { get; private set; }



        public double ObjetivoKm
        {

            set
            {
                if (value <= KmObjMax && value >= kmSesMin)
                {
                    kmObjetivo = value;
                }
            }
            get
            {
                return kmObjetivo;
            }

        }
        public string GuardarSesion(string codigo,double SesKM)

        {
            int ses = 0;
            ses = BuscarSesion("");
            if (ses == -1)
            {
                return "No hay más lugar" ;
            }
            if (BuscarSesion(codigo) !=-1)
            {
                return "Código Repetido";
            }
            miSesiones[ses] = new Sesiones(codigo, SesKM);
            if (miSesiones[ses].codigo == "")
            {
                return "Revisar sus valores ingresados";
            }
            sesionesDisponibles -= 1;
            kmTotalR = kmTotalR + SesKM;

            return "";

        }
        
        public int BuscarSesion(string cod)
        {
            int ses = 0;
            while (miSesiones[ses].codigo != cod && ses < miSesiones.GetUpperBound(0))
            {
                ses++;
            }
            if (miSesiones[ses].codigo != cod)
            {
                return -1;
            }
            else
            {
                return ses;
            }
        }
        public string QuitarSesion(string Code)
        {
            int ses = 0;
            ses = BuscarSesion(Code);
            if ( ses==-1)
            {
                return "Código no exitente";
            }
            kmTotalR = kmTotalR - miSesiones[ses].kilometros;
            miSesiones[ses] = new Sesiones("",0);
           sesionesDisponibles++;
            return "";

        }
       
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public string Estadistica()
        {
            string detalle = "";
            int ses = 0;
            do
            {
                detalle = detalle + "\n\t\t" + miSesiones[ses].codigo+ "    \t" + miSesiones[ses].kilometros;

                if (miSesiones[ses].kilometros >= ObjetivoKmXSes)
                {
                    detalle = detalle + "\tS";
                }
                if (miSesiones[ses].kilometros < ObjetivoKmXSes)
                {
                    detalle = detalle + "\tN";
                }
                ses++;

            } while (ses < maxSesiones - sesionesDisponibles);
            if (detalle == "")
            {
                detalle = "\n\tNo hay sesiones ingresadas";
            }
            else
            {
                detalle = "\n\tDetalle de las Sesiones:\n\t\tCódigo    \tKms\tObj Kms" + detalle;
            }

            string cabecera = "";
            cabecera = "Estadistica\n\t Objetivos en kms:" + ObjetivoKm + "\tRealizados " + kmTotalR
                + "\nel objetivo de kms por sesión: " + ObjetivoKmXSes; ;
            if (kmTotalR != 0 && kmTotalR > ObjetivoKm)
            {
                cabecera = cabecera + "\tObjetivo Cumplido";
            }
            return cabecera + detalle;
        }
    }
}
