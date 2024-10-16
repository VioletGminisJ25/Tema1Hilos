using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria
{
    //internal class Program
    //{
    //static void Main(string[] args)
    //{
    //    //Process[] processes = Process.GetProcesses();
    //const string FORMAT = "{0,20}{1,7}{2,6}";
    //Console.WriteLine(FORMAT, "Name", "PID", "Threads");
    //foreach (Process p in processes)
    //{
    //    Console.WriteLine(FORMAT, p.ProcessName, p.Id, p.Threads.Count);
    //    try
    //    {

    //        ProcessThreadCollection threads = p.Threads;
    //        foreach (ProcessThread t in threads)
    //        {
    //            Console.WriteLine("Thread ID: {0}\tInit {1}\tPriority {2}\tState {3}",
    //             t.Id, t.StartTime.ToShortTimeString(), t.PriorityLevel,
    //            t.ThreadState);
    //        }
    //    }
    //    catch (Exception ex) { }

    //}
    //}

    //        public static void view(int grade)
    //        {
    //            Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
    //            Console.WriteLine($"Student grade: {grade,3}.");
    //            Console.ResetColor();
    //        }
    //        public static bool pass(int num)
    //        {
    //            return num >= 5;
    //        }
    //        static void Main(string[] args)
    //        {
    //            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
    //            Array.ForEach(v, view);
    //            int res = Array.FindIndex(v, pass);
    //            Console.WriteLine($"The first passing student is number {res + 1} in the list.");
    //            Console.ReadKey();
    //        }

    //}
    public delegate int Operation(int a, int b);
    public class Program
    {
        //static int Addition(int a, int b)
        //{
        //    return a + b;
        //}
        //static int Substraction(int a, int b)
        //{
        //    return a - b;
        //}
        public static int foo(int a, int b)
        {
            Console.WriteLine("Hola");
            return 0;
        }
        static void Main(string[] args)
        {
            Operation op = (a,b) => a-b ; // Operation op = Substraction;
            string res;
            int n1, n2;
            Console.WriteLine("Do you want to add or substract?(A/S)");
            res = Console.ReadLine().Trim().ToUpper();
            if (res == "A")
            {
                op = (a, b) => a + b ; // Operation op = Addition;
            }
            Console.WriteLine("Input first operand");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input second operand");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Result: {0}", op(n1, n2));
            Console.ReadKey();
        }

    }
}
