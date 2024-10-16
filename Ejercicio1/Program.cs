using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            if (Array.Exists(v, (grade) => grade >= 5))
            {
                Console.WriteLine("Hay alumnos aprobados");
            }
            else
            {
                Console.WriteLine("No hay alumnos aprobados");

            }
            Array.ForEach(v, (grade) => {
                Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {grade,3}.");
                Console.ResetColor();
            });
            int res = Array.FindLastIndex(v, (num) => num >= 5);
            int first = Array.FindIndex(v, (num) => num >= 5);
            Console.WriteLine($"The first passing student is number {first + 1} in the list.");
            Console.WriteLine($"The last passing student is number {res + 1} in the list.");

            Array.ForEach(v, (n) => Console.WriteLine(String.Format("{0:0.00}" ,(1.00/ n))));
            Console.ReadKey();
        }
    }
}
