using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace term_fogy_extra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager.AddProducer(new Producer(0));
            Manager.AddProducer(new Producer(1));
            Manager.AddProducer(new Producer(2));

            Manager.AddConsumer(new Consumer());
            Manager.AddConsumer(new Consumer());
            Manager.AddConsumer(new Consumer());
            Manager.AddConsumer(new Consumer());
            Manager.AddConsumer(new Consumer());

            Manager.Start();
        }
    }
}
