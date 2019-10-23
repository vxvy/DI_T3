using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DI_T3
{
    class ColeccionOrdenadores
    {

        private Hashtable ordenadoresHash;
        public Hashtable OrdenadoresHash { set; get; }

        private IPAddress ipadress;
        public IPAddress Ipadress
        {
            set; get;
        }

        private int ram;
        public int Ram
        {
            set
            {
                if (value < 0)
                {
                    throw new FormatException();
                }
                else
                {
                    this.ram = value;
                }
            }
            get
            {
                return this.ram;
            }
        }

        public ColeccionOrdenadores()
        {
            this.OrdenadoresHash = new Hashtable();
        }

        public void addOrdenardor(IPAddress ipadress, int ram)
        {
            if (!OrdenadoresHash.ContainsKey(ipadress))
            {
                this.OrdenadoresHash.Add(ipadress,ram);
            }
            else
            {
                throw new OperationCanceledException();
            }
        }

        public void showOrdenadores()
        {

            if (this.OrdenadoresHash.Count != 0)
            {
                foreach (DictionaryEntry de in this.OrdenadoresHash)
                {
                    Console.WriteLine("IP: {0}, RAM: {1}GB",
                        de.Key.ToString(),de.Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay ningún ordenador guardado.");
            }
        }

        public void showOrdenadores(IPAddress ipaddress) //ord[ip]
        {
            Console.WriteLine(OrdenadoresHash[ipaddress]);
            //foreach (DictionaryEntry de in this.OrdenadoresHash)
            //{
            //    //Console.WriteLine("IP: {0}, Key: {1}", ipaddress, de.Key);
            //    if (ipaddress.ToString()==de.Key.ToString())
            //    {
            //        Console.WriteLine("IP: {0}, RAM: {1}GB",
            //        de.Key.ToString(), de.Value.ToString());
            //    }
            //}
        }
    }
}
