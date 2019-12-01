using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewCodigoCesar
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Realizar un programa que encripte un texto mediante el cifrado César. \n" +
               "El usuario introducirá el texto, y el número de desplazamiento.");
            string Programa = menuPrincipal();
        }
        static string menuPrincipal()
        {
            string Programa = "";
            Console.WriteLine("\n\n\n¿Qué desea hacer?\n\n\n");
            Console.WriteLine("Presione C para Cifrar");
            Console.WriteLine("Presione D para Descifrar");
            Console.WriteLine("Presione S para Salir\n\n\n");
            Programa = Console.ReadLine().ToUpper();

            if (Programa.Equals("C"))
            {
                Console.WriteLine("Inicio de Cifrado");
                Cifrado();
            }
            else if (Programa.Equals("D"))
            {
                Console.WriteLine("Inicio de Descifrado");
                DesCifrado();
                Console.WriteLine();
            }
            else if (Programa.Equals("S"))
            {
                Console.WriteLine("Cerrando aplicación...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Valor incorrecto!!! Responda C , D , S");
                Thread.Sleep(2000);
                Console.Clear();
                menuPrincipal();
            }
            return Programa;
        }
        public static string PideMensaje()
        {
            int longitud = -1;
            string mensaje;
            do
            {
                if (longitud != -1)
                {
                    Console.WriteLine("Valor incorrecto! Vuelva a intentarlo.");
                }
                //Pedir mensaje
                Console.WriteLine("Introduzca el mensaje");
                mensaje = Console.ReadLine();
                char[] Caracteres = mensaje.ToCharArray();
                longitud = Caracteres.Length;
                Console.WriteLine($"Longitud: {longitud} ");
            }
            while (longitud > 350 || longitud == 0);
            return mensaje;
        }
        public static int PideValorDesplazamiento()
        {
            /*
             * Método basado en: https://stackoverflow.com/questions/13106493/how-do-i-only-allow-number-input-into-my-c-sharp-console-application
             */
            string _val = "";
            Console.Write("\nEntre un valor de desplazamiento");
            Console.WriteLine();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }
                if (_val == "")
                {
                    Console.WriteLine("\nNO PUEDES DEJAR EN BLANCO EL DESPLAZAMIENTO!!!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("\n\n\n****************************************************");
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("Vamos de vuelta...");
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("****************************************************\n\n\n");

                    menuPrincipal();
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);

            // Console.WriteLine("El valor entregado es: " + _val);
            int retorno = Convert.ToInt32(_val);
            //Console.WriteLine("El valor de retorno será: " + retorno);
            return retorno;

        }
        static void Cifrado()
        {
            Console.WriteLine("Introduce el mensaje a cifrar (Máx 30 Caracteres)");
            string mensaje = PideMensaje();
            int desplazamiento = PideValorDesplazamiento();
            int modulo = desplazamiento;

            while (desplazamiento < 1)
            {
                desplazamiento = PideValorDesplazamiento();
            }
            if (desplazamiento > 13)
            {
                int division = desplazamiento / 13;
                modulo = desplazamiento % 13;
                // Console.WriteLine("Division = " + division);
                //Console.WriteLine("Modulo = " + modulo);
            }
            uint desplazamientoConvertido = 0;
            //Console.WriteLine("El mensaje es: " + mensaje);
            // Console.WriteLine("El valor de desplazamiento es: " + desplazamiento);

            char[] Caracteres = mensaje.ToCharArray();
            // Caracteres.Length
            // uint longitud = Convert.ToUInt32(Caracteres.Length);
            int longitud = Caracteres.Length;
            desplazamientoConvertido = Convert.ToUInt32(modulo);
            string Clasificacion = "";
            char[] mochila = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                char LetraIn = mensaje[i];
                uint valorX = mensaje[i] + desplazamientoConvertido;

                //Mayusculas
                if (LetraIn >= 'A' && LetraIn <= 'Z')
                {
                    Clasificacion = "Mayuscula";
                }
                //Minusculas
                else if (LetraIn >= 'a' && LetraIn <= 'z')
                {
                    Clasificacion = "Minuscula";
                }
                else
                {
                    Clasificacion = "Desconocida";
                    Console.WriteLine("LetraIn fuera de rango =" + LetraIn);
                }
                if (Clasificacion == "Mayuscula")
                {
                    if (valorX > 'Z')
                    {
                        valorX -= 'Z';
                        valorX += 'A' - 1;
                        // Console.WriteLine("ValorX= " + valorX);
                    }
                }

                if (Clasificacion == "Minuscula")
                {
                    if (valorX > 'z')
                    {
                        valorX -= 'z';
                        valorX += 'a';
                        valorX -= 1;
                        //Console.WriteLine("ValorX= " + valorX);// Cifrado
                    }
                }

                char ValorConvertido = Convert.ToChar(valorX);
                mochila[i] = ValorConvertido;

            }
            Console.Write("\nRESULTADO: ");
            Console.WriteLine(mochila);
            //Console.ReadLine();
            menuPrincipal();
        }
        static void DesCifrado()
        {
            Console.WriteLine("Introduce el mensaje a descifrar (Máx 30 Caracteres)");
            string mensaje = PideMensaje();
            int desplazamiento = PideValorDesplazamiento();
            int modulo = desplazamiento;

            while (desplazamiento < 1)
            {
                desplazamiento = PideValorDesplazamiento();
            }
            if (desplazamiento > 13)
            {
                int division = desplazamiento / 13;
                modulo = desplazamiento % 13;
                Console.WriteLine("Division = " + division);
                Console.WriteLine("Modulo = " + modulo);
            }

            uint desplazamientoConvertido = 0;
            // Console.WriteLine("El mensaje es: " + mensaje);
            Console.WriteLine("El valor de desplazamiento es: " + desplazamiento);
            char[] Caracteres = mensaje.ToCharArray();
            int longitud = Caracteres.Length;
            desplazamientoConvertido = Convert.ToUInt32(modulo);
            string Clasificacion = "";
            char[] mochila = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                char LetraIn = mensaje[i];
                uint valorX = mensaje[i] - desplazamientoConvertido;
                uint uno = Convert.ToUInt32(1);

                //Mayusculas
                if (LetraIn >= 'A' && LetraIn <= 'Z')
                {
                    Clasificacion = "Mayuscula";
                }
                //Minusculas
                else if (LetraIn >= 'a' && LetraIn <= 'z')
                {
                    Clasificacion = "Minuscula";
                }
                else
                {
                    Clasificacion = "Desconocida";
                    Console.WriteLine("LetraIn fuera de rango =" + LetraIn);
                }
                if (Clasificacion == "Mayuscula")
                {
                    if (valorX < 'A')
                    {
                        valorX = valorX - 'A';
                        valorX = valorX + 'Z' + 1;

                        //Console.WriteLine("ValorX= " + valorX);
                    }
                }
                if (Clasificacion == "Minuscula")
                {
                    if (valorX < 'a')
                    {
                        valorX -= 'a';
                        valorX += 'z';
                        valorX += uno;
                    }
                    if (valorX > 'z')
                    {
                        valorX += uno;
                        valorX -= 'a';
                        valorX += 'z';
                    }
                }
                char ValorConvertido = Convert.ToChar(valorX);//Valor X demasiado grande
                mochila[i] = ValorConvertido;

            }

            Console.Write("\nRESULTADO: ");
            Console.WriteLine(mochila);
            //Console.ReadLine();
            menuPrincipal();
        }

        //Video de Referancia
        //https://www.youtube.com/watch?v=De9ZLfGIM18
    }
}
