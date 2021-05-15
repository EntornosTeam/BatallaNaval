using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaNaval
{
    class Barco
    {
        private int size;
        private int id = 0;
        public static int maxID = -1;
        //private string orientacion;

        public Barco(int s)
        {
            this.size = s;
            this.id = ++maxID;
        }
    }
}
