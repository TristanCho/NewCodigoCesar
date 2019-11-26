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
            Console.WriteLine("Presione D para Decifrar");
            Console.WriteLine("Presione S para Salir\n\n\n");
            Programa = Console.ReadLine().ToUpper();

            if (Programa.Equals("C"))
            {
                Console.WriteLine("Inicio de Cifrado");
                Cifrado();

            }
            else if (Programa.Equals("D"))
            {
                Console.WriteLine("Inicio de Decifrado");
                DeCifrado();
                Console.ReadLine();
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
            while (longitud > 30 || longitud == 0);
            return mensaje;
        }

        public static int PideValorDesplazamiento()
        {
            /*
             * Método basado en: https://stackoverflow.com/questions/13106493/how-do-i-only-allow-number-input-into-my-c-sharp-console-application
             */
            string _val = "";
            Console.Write("\nEntre un valor de desplazamiento menor a 50: ");

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
                if (_val=="")
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
            while (desplazamiento<1||desplazamiento>50)
            {
                desplazamiento = PideValorDesplazamiento();
            }

            uint desplazamientoConvertido = 0;
            //Console.WriteLine("El mensaje es: " + mensaje);
            // Console.WriteLine("El valor de desplazamiento es: " + desplazamiento);

            char[] Caracteres = mensaje.ToCharArray();
            // Caracteres.Length
            // uint longitud = Convert.ToUInt32(Caracteres.Length);
            int longitud = Caracteres.Length;
            desplazamientoConvertido = Convert.ToUInt32(desplazamiento);

            char[] mochila = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {

                uint valorX = desplazamientoConvertido + mensaje[i];
                /*
                if (valorX > 126)
                {
                    valorX -= 95;
                }
                if (valorX < 32)
                {
                    valorX += 95;
                }*/

                if (valorX > 'z')
                {
                    valorX -= 55;
                }
                if (valorX < 'A')
                {
                    valorX += 55;
                }

                char ValorConvertido = Convert.ToChar(valorX);
                mochila[i] = ValorConvertido;


            }
            Console.Write("\nRESULTADO: ");
            Console.WriteLine(mochila);
            //Console.ReadLine();
            menuPrincipal();
        }
        static void DeCifrado()
        {
            Console.WriteLine("Introduce el mensaje a decifrar (Máx 30 Caracteres)");
            string mensaje = PideMensaje();
            int desplazamiento = PideValorDesplazamiento();
            while (desplazamiento>50)
            {
                Console.WriteLine("Valor demasiado alto");
                desplazamiento = PideValorDesplazamiento();
            }
            //Console.Clear();
            uint desplazamientoConvertido = 0;
            Console.WriteLine("El mensaje es: " + mensaje);
            Console.WriteLine("El valor de desplazamiento es: " + desplazamiento);

            char[] Caracteres = mensaje.ToCharArray();
          
            int longitud = Caracteres.Length;
            desplazamientoConvertido = Convert.ToUInt32(desplazamiento);

            char[] mochila = new char[longitud];
            string resultadito = "";
            for (int i = 0; i < longitud; i++)
            {

                uint valorX = mensaje[i] - desplazamientoConvertido;
                Console.WriteLine("desplazamientoConvertidoDespues = " + desplazamientoConvertido);
                /*
              if (valorX > 126)
              {
                  valorX -= 95;
              }
              if (valorX < 32)
              {
                  valorX += 95;
              }*/

                if (valorX > 'z')
                {
                    valorX -= 55;
                }
                if (valorX < 'A')
                {
                    valorX += 55;
                }
                Console.WriteLine("desplazamientoConvertidoAntes = "+ desplazamientoConvertido);
                Console.WriteLine("Mensaje[i]= "+mensaje);
                Console.WriteLine("valorX= "+valorX);
                while (valorX> 4294967295)
                {
                Console.WriteLine("Imposible decodificar, codifique de nuevo");
                    Thread.Sleep(3000);

                    menuPrincipal();
                }
                while (valorX <0)
                {
                    Console.WriteLine("bAJO CEROOOOOOOOOOOOOOOOO");
                    Thread.Sleep(3000);

                    menuPrincipal();
                }

                char ValorConvertido = Convert.ToChar(valorX);
                //string variableCadena = Convert.ToString(valorX);
                mochila[i] = ValorConvertido;


                resultadito += valorX;
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
