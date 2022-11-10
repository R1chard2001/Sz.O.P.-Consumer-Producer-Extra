using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace term_fogy_extra
{
    internal static class Manager
    {
        internal class Writer
        {
            public void Write(int line, string str, ConsoleColor color = ConsoleColor.Gray)
            {
                lock (this)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(0, line);
                    Console.Write(str + "     ");
                }
            }
        }
        public static Writer writer = new Writer();
        public static bool Working = true;
        public static List<Producer> ProducerList = new List<Producer>();
        public static List<Consumer> ConsumerList = new List<Consumer>();
        public static List<Product> ProductList = new List<Product>();
        public static void AddProducer(Producer p)
        {
            ProducerList.Add(p);
        }
        public static void AddConsumer(Consumer c)
        {
            lock (ConsumerList)
            {
                ConsumerList.Add(c);
                writer.Write(4, string.Format("{0} darab fogyasztó vár a termékekre.", ConsumerList.Count));
                writer.Write(7, "                                      "); // csak az Exception-el kiváltott sor törléséért
            }
            new Thread(c.Work).Start();
        }
        public static void RemoveConsumer(Consumer c)
        {
            lock (ConsumerList)
            {
                ConsumerList.Remove(c);
                writer.Write(4, string.Format("{0} darab fogyasztó vár a termékekre.", ConsumerList.Count));
                if (ConsumerList.Count == 0)
                {
                    throw new ZeroConsumerException();
                }
            }
        }
        public static void AddProduct(Product p)
        {
            lock (ProductList)
            {
                ProductList.Add(p);
                writer.Write(3, string.Format("{0} darab termék van a várólistán.", ProductList.Count));
            }
        }
        public static bool RemoveProduct()
        {
            bool success = false;
            while (ProductList.Count == 0 && Working)
            { }

            lock (ProductList)
            {
                if (ProductList.Count > 0)
                {
                    ProductList.RemoveAt(0);
                    writer.Write(3, string.Format("{0} darab termék van a várólistán.", ProductList.Count));
                    success = true;
                }
            }
            return success;
        }
        public static void Start()
        {
            Console.CursorVisible = false;
            writer.Write(5, " - F -> új fogyasztó\n - Escape -> kilépés");
            writer.Write(3, string.Format("{0} darab termék van a várólistán.", ProductList.Count));
            foreach (Producer p in ProducerList)
            {
                new Thread(p.Work).Start();
            }
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).Key;
                if (ck == ConsoleKey.F)
                {
                    AddConsumer(new Consumer());
                }
            } while (ck != ConsoleKey.Escape);
            Working = false;
        }
    }
}
