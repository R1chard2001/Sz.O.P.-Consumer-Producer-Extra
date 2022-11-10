using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace term_fogy_extra
{
    internal class Producer
    {
        static Random rnd = new Random();
        int line;

        public Producer(int line)
        {
            this.line = line;
        }
        public void Work()
        {
            while (Manager.Working)
            {
                int time;
                lock (rnd)
                {
                    time = rnd.Next(1, 11);
                }
                for (int i = time; i >= 0 && Manager.Working; i--)
                {
                    ConsoleColor color = ConsoleColor.Green;
                    if ((float)i / time < 0.25f)
                    {
                        color = ConsoleColor.DarkRed;
                    }
                    else if ((float) i / time < 0.5f)
                    {
                        color = ConsoleColor.Red;
                    }
                    else if ((float)i / time < 0.75f)
                    {
                        color = ConsoleColor.Yellow;
                    }
                    Manager.writer.Write(line, 
                        string.Format("A(z) {0} termelő elkészül {1} másodpercen belül.",line + 1,i),
                        color);
                    System.Threading.Thread.Sleep(1000);
                }
                Manager.AddProduct(new Product());
            }
        }
    }
}
