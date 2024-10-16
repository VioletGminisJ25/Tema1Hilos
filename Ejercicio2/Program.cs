using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public delegate void MyDelegate();
    internal class Program
    {
        static string[] options;
        static void Main(string[] args)//oveerflows, informar op no valida

        {
            bool resp = MenuGenerator(options = new string[] { "Op1", "Op2", "Op3", "Op4","Op5", "Op6", "Op7", "Op8" },new MyDelegate[] { () => { Console.WriteLine("A"); }, () => { Console.WriteLine("B"); }, () => { Console.WriteLine("C"); }, () => { Console.WriteLine("D"); }, () => { Console.WriteLine("E" +""); }, () => { Console.WriteLine("F"); }, () => { Console.WriteLine("G"); }, () => { Console.WriteLine("H"); } });// comprobaciones de tamaño y nulls
            //bool resp = MenuGenerator(options = null,new MyDelegate[] { () => { Console.WriteLine("A"); }, () => { Console.WriteLine("B"); }, null , () => { Console.WriteLine("D"); } });
            Console.WriteLine(resp);
        }


        public static bool MenuGenerator(string[] opciones, MyDelegate[] deleg)
        {
            bool finished = false;
            bool valid = true;
            if (options != null && deleg != null && !deleg.Contains(null) && !options.Contains(null) && options.Length == deleg.Length)
            {
                do
                {
                    Console.WriteLine("MENU\n----");
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} -- {opciones[i]}");
                    }
                    Console.WriteLine($"{opciones.Length + 1} -- Salir");
                    //notValid = false;
                    int resp = 0;
                    try
                    {
                        if(Int32.TryParse(Console.ReadLine(),out resp))
                        {
                            if (resp > 0 && resp <= options.Length)
                            {
                                deleg[resp - 1]();
                            }
                            if (resp <= 0 || resp > options.Length+1)
                            {
                                Console.WriteLine("ERR: Opción no valida");
                            }
                            if (resp == opciones.Length + 1)
                            {
                                finished = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERR: Error de formato");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERR: El formato no es correcto");
                        //return false;
                    }
                    

                    //return true;
                } while (!finished);
            }
            else
            {
                valid = false;
            }
            return valid;
        }

    }
}
