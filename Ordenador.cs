using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DI_T3
{

    class Ordenador
    {
        private IPAddress ipadress;
        public IPAddress Ipadress
        {
            set; get;
        }

        private int ram;
        public int Ram
        {
            set{
                if (value < 0)
                {
                    throw new FormatException();
                }
                else
                {
                    this.ram = value;
                }
            }
            get{
                return this.ram;
            }
        }

        public Ordenador(IPAddress ipadress, int ram)
        {
            this.ipadress = ipadress;
            this.ram = ram;
        }
    }
}
