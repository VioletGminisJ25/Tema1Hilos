using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Program
    {
        public static bool finish;
        public static object l = new object();
        public static Random random = new Random();
        public static string caballoFinished;
        private static int posIniX = 20;
        private static int posIniY = 4;
        public static int apuesta;
        public static bool repeat;


        private static Caballo[] caballos;



        static void Main(string[] args)
        {
            do
            {
                repeat = false;
                Console.Clear();

                caballos = new Caballo[5] { new Caballo("Pegasus", posIniX, posIniY + 2, ConsoleColor.Red), new Caballo("Valentín", posIniX, posIniY + 4, ConsoleColor.White), new Caballo("Kentucky", posIniX, posIniY + 6, ConsoleColor.Green), new Caballo("Perseo", posIniX, posIniY + 8, ConsoleColor.Magenta), new Caballo("Michigan", posIniX, posIniY + 10, ConsoleColor.Yellow) };
                finish = false;

                Console.SetCursorPosition(0, 0);
                Console.Write("Haga su apuesta");
                Console.WriteLine();
                for (int i = 0; i < caballos.Length; i++)
                {
                    Console.Write($"{i + 1} -- {caballos[i].Name}  ");
                }
                Console.WriteLine();


                bool valid = false;
                while (!valid)
                {
                    String resp = Console.ReadLine();
                    if (Int32.TryParse(resp, out apuesta))
                    {

                        if (apuesta > 0 && apuesta <= caballos.Length)
                        {
                            valid = true;
                        }
                        else
                        {
                            valid = false;
                            Console.WriteLine("ERR: FUERA DE RANGO");
                        }
                    }
                    else
                    {
                        valid = false;
                        Console.WriteLine("ERR: No es un numero");
                    }

                }

                foreach (Caballo caballo in caballos)
                {
                    Console.SetCursorPosition(0, caballo.PosY);
                    Console.Write(caballo.Name);
                }
                foreach (Caballo caballo in caballos)
                {

                    caballo.thread.Start();

                }
                caballos[0].thread.Join();

                if (finish)
                {
                    Console.SetCursorPosition(0, posIniY + 12);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(caballoFinished + " ha ganado");
                    int indice = 0;
                    for (int i = 0; i < caballos.Length; i++)
                    {
                        if (caballos[i].Name == caballoFinished)
                        {
                            indice = i;
                        }
                    }
                    if (apuesta == indice + 1)
                    {
                        Console.WriteLine("Has ganado!!");

                    }
                    else
                    {
                        Console.WriteLine("Has perdido :(");
                    }

                    Console.WriteLine("Quieres repetir?(S/N)");
                    if (
                    Console.ReadLine().ToUpper()[0] == 'S')
                    {
                        repeat = true;
                    }

                }
            } while (repeat);

        }
    }
}
