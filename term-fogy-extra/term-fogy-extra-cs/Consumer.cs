using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace term_fogy_extra
{
    internal class Consumer
    {
        public void Work()
        {
            while (!Manager.RemoveProduct() && Manager.Working)
            {
            }
            try
            {
                Manager.RemoveConsumer(this);
            }
            catch (ZeroConsumerException)
            {
                Manager.writer.Write(7, "Elfogytak a fogyasztók, ESC -> kilépés");
            }
            
        }
    }
}
