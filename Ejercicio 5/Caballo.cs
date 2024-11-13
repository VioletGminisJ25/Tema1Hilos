using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    internal class Caballo
    {
        public static int sleep = 200;
        private string name;
        public string Name
        {
            set { name = value; }
            get
            {

                return name;
            }
        }
        private int posY;
        private int posX;
        public int PosY
        {
            get
            {
                return posY;
            }
            set
            {

                posY = value;
            }
        }
        public Thread thread;
        ConsoleColor color;



        public Caballo(string name, int posX, int posY, ConsoleColor color)
        {
            this.name = name;
            this.posY = posY;
            this.posX = posX;
            thread = new Thread(Correr);
            this.color = color;

        }

        public Caballo() : this("", 0, 0, ConsoleColor.Blue) { }

        public void Correr()
        {



            while (!Program.finish)
            {
                lock (Program.l)
                {
                    if (!Program.finish)
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.ForegroundColor = color;
                        Console.WriteLine("*");
                        if (posX >= 100)
                        {
                            Program.caballoFinished = this.Name;
                            Program.finish = true;
                            Monitor.Pulse(Program.l);
                        }
                        posX += Program.random.Next(3);
                    }
                }
                Thread.Sleep(Program.random.Next(50));
            }
        }
    }
}
