using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Ejercicio4
{
    internal class Program
    {
        static object l = new object();
        static int cont;
        static bool finished;
        static void Main(string[] args)
        {
            cont = 0;
            finished = false;
            Thread decrem_thread = new Thread(() =>
            {
                while (!finished)
                {
                    lock (l)
                    {
                        if (!finished)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            cont--;
                            Console.WriteLine($"{cont}");
                            if (cont == -500)
                            {

                                finished = true;
                                Monitor.Pulse(l);
                            }
                        }
                    }
                }
            });
            Thread increm_thread = new Thread(() =>
            {
                while (!finished)
                {
                    lock (l)
                    {
                        if (!finished)
                        {

                            Console.ForegroundColor = ConsoleColor.Blue;
                            cont++;
                            Console.WriteLine($"{cont}");
                            if (cont == 500)
                            {
                                finished = true;
                                Monitor.Pulse(l);

                            }
                        }
                    }
                }
            });
            increm_thread.Start();
            decrem_thread.Start();
            lock (l)
            {
                Monitor.Wait(l);
                if (cont == -500)
                {
                    Console.WriteLine("Ganador el hilo rojo!");
                }
                else
                {
                    Console.WriteLine("Ganador el hilo azul!");

                }
            }

            Console.ReadKey();

        }
    }
}
