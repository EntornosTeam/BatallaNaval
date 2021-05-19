using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNaval
{
    public class Jugador
    {
        private int numeroDisparos;

        public Jugador()
        {
            this.numeroDisparos= 10;
        }

        public int NumeroDisparos
        {
            get { return numeroDisparos;  }
            set { numeroDisparos = value; }
        }
        public void RestarNumDisparos()
        {
            this.numeroDisparos--;
        }
    }
}