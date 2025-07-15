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

            MostrarMenu();

        }

        public static void MostrarMenu()
        {
            while (true)
            {

                Console.WriteLine("==========SISTEMA CRUD DE CLIENTES==========");
                Console.WriteLine("1. Registrar un cliente");
                Console.WriteLine("2. Buscar un cliente");
                Console.WriteLine("3. Mostrar lista de clientes");
                Console.WriteLine("4. Actualizar información de un cliente");
                Console.WriteLine("5. Delete Cliente");
                Console.WriteLine("6. Salir del sistema");
                Console.WriteLine("=============================================");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        createCliente();
                        break;
                    case "2":
                        ReadCliente();
                        break;
                    case "3":
                        ReadAllCliente();
                        break;
                    case "4":
                        UpdateCliente();
                        break;
                    case "5":
                        DeleteCliente();
                        break;
                    case "6":
                        return; // Salir del menú
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        //DELETE CLIENTE
        private static void DeleteCliente()
        {
            Console.Clear();
            Console.WriteLine("***DELETE CLIENTE*****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a buscar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                Console.WriteLine($"¿Está seguro de que desea eliminar al cliente: {objClienteBuscado.getNombresCompletos()} ? (S/N)");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BaseDatos.BaseDeDatos.BaseDatosCliente.Remove(objClienteBuscado);
                    Console.WriteLine("Cliente eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }

        //UPDATE CLIENTE
        private static void UpdateCliente()
        {
            Console.Clear();
            Console.WriteLine("***UPDATE CLIENTE*****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a buscar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                objClienteBuscado.imprimir();
                Console.WriteLine("Ingrese los nombres del cliente a modificar: ");
                string nombres = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese los apellidos del cliente a modificar: ");
                string apellidos = Console.ReadLine();
                Console.WriteLine();
                objClienteBuscado.setNombres(nombres);
                objClienteBuscado.setApellidos(apellidos);
                BaseDatos.BaseDeDatos.BaseDatosCliente.RemoveAt(objClienteBuscado.getID() - 1); //ELIMINAR CLIENTE
                BaseDatos.BaseDeDatos.BaseDatosCliente.Insert(objClienteBuscado.getID() - 1, objClienteBuscado); // INSERTAR CLIENTE
                Console.WriteLine("¡Cliente actualizado con éxito!");

            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }

        private static void ReadAllCliente()
        {
            Console.Clear();
            Console.WriteLine("*****READ ALL CLIENTES****");
            Console.WriteLine();
            BaseDatos.BaseDeDatos.ImprimirClientes();
            Console.ReadLine();
        }


        //READ CLIENTE
        private static void ReadCliente()
        {
            Console.Clear();
            Console.WriteLine("***READ CLIENTE*****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a buscar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                objClienteBuscado.imprimir();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
        }


        //CREATE CLIENTE
        private static void createCliente()
        {
            Console.WriteLine("*************CREATE CLIENTE**************");
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
            Console.WriteLine($"Cliente grabado con éxito: ");
            Console.ReadLine();
        }
    }
}