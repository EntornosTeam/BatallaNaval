using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNaval
{
    public class Jugador
    {
        private int numeroDisparos;
        const int MAX_DISPAROS = 21;

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

        public void RecuperarDisparos()
        {
            if (MAX_DISPAROS < numeroDisparos + 2)
            {
                numeroDisparos = MAX_DISPAROS;
            } 
            else
            {
                this.numeroDisparos += 2;
            }
        }
    }
}