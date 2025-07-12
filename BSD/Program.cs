
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSD.Clases;

namespace BSD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la cedula del cliente: ");
            string cedula = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los nombres del cliente: ");
            string nombres = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los apellidos del cliente: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine();


            Cliente objCliente = new Cliente(cedula, nombres, apellidos);
            BaseDatos.BaseDeDatos.imprimirCliente();
            Console.ReadLine();

            Console.WriteLine("Ingrese la cedula del cliente: ");
            cedula = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los nombres del cliente: ");
            nombres = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los apellidos del cliente: ");
            apellidos = Console.ReadLine();
            Console.WriteLine();


            Cliente objClient2 = new Cliente(cedula, nombres, apellidos);
            BaseDatos.BaseDeDatos.imprimirCliente();
            Console.ReadLine();
        }
    }
}
