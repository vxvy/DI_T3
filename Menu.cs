using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DI_T3
{
    class Menu
    {
        private string smenu;
        public string SMenu { set; get; }

        public Menu()
        {
            this.SMenu =
                "____________________________________" +
                "\r\nElige una opción" +
                "\r\n____________________________________" +
                "\r\n1. Añande un ordenador a la colección" +
                "\r\n2. Muestra la colección de ordenadores" +
                "\r\n3. Muestra un elemento de la colección usando su IP" +
                "\r\nPulsa 0 para terminar el programa." +
                "\r\n____________________________________";
        }

        public void launchMenu()
        {

            string opcion = "0";
            ColeccionOrdenadores coleccion = new ColeccionOrdenadores();

            do
            {
                Console.WriteLine(this.SMenu);
                opcion=Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Ha seleccionado introducir datos." +
                                "\r\nIntroduzca una ip válida.");
                            coleccion.Ipadress = IPAddress.Parse(Console.ReadLine());
                            Console.WriteLine("Introduzca una cantidad válida de ram en GB.");
                            coleccion.Ram = Int32.Parse(Console.ReadLine());

                            coleccion.addOrdenardor(coleccion.Ipadress, coleccion.Ram);
                            Console.WriteLine("Elemento añadido con éxito.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("El formato del dato introducido es incorrecto");
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Has intentado insertar un elemento repetido.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ha seleccionado visualizar datos.");
                        coleccion.showOrdenadores();
                        Console.WriteLine();
                        break;
                    case "3":
                        try
                        {
                            if (coleccion.OrdenadoresHash.Count != 0)
                            {
                                Console.WriteLine("Ha seleccionado visualizar una entrada concreta." +
                                    "\r\nIntroduce la IP del ordenador que quieres visualizar.");
                                coleccion.Ipadress = IPAddress.Parse(Console.ReadLine());
                                coleccion.showOrdenadores(coleccion.Ipadress);
                            }
                            else
                            {
                                Console.WriteLine("Ha seleccionado visualizar una entrada, pero no hay entradas.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("El formato del dato introducido es incorrecto");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no implementada");
                        break;
                }

            } while (opcion!="0");

        }

        public bool Salida(string opcion){
            if (opcion != "0") {
                Console.WriteLine("¿Quieres terminar el programa? Pulsa X para salir.");
                return Console.ReadLine().ToUpper().Trim() == "X";
            }
            else
            {
                return false;
            }

        }

    }
}
