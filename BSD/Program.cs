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

                Console.WriteLine(" EMPRESA O'ASIS S.A.");
                Console.WriteLine(" SISTEMA CRUD DE CLIENTES");
                Console.WriteLine();
                Console.WriteLine(" 1. Registrar un cliente");
                Console.WriteLine(" 2. Buscar un cliente");
                Console.WriteLine(" 3. Mostrar lista de clientes");
                Console.WriteLine(" 4. Actualizar información de un cliente");
                Console.WriteLine(" 5. Eliminar un cliente existente");
                Console.WriteLine(" 6. Salir del sistema");
                Console.WriteLine();
                Console.Write(" Seleccione una opción: ");
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        RegistrarCliente();
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
                        return;
                    default:
                        Console.WriteLine("Selecciona una opción válida.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        //CREATE CLIENTE
        private static void RegistrarCliente()
        {
            Console.Clear();

            Console.WriteLine("Registrar un cliente");

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

            Console.WriteLine("Cliente Registrado Correctamente");

            Console.ReadLine();
            Console.Clear();
        }


        //READ CLIENTE
        private static void ReadCliente()
        {
            Console.Clear();
            Console.WriteLine(" Buscar Clientes Registrados");
            Console.Write("Ingrese la cédula del cliente a buscar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                objClienteBuscado.imprimir();

            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
            Console.ReadLine();
            Console.Clear();
        }


        //READ ALL CLIENTES
        private static void ReadAllCliente()
        {
            Console.Clear();
            Console.WriteLine("**** Mostrar Lista de Clientes ****");
            Console.WriteLine();
            BaseDatos.BaseDeDatos.ImprimirClientes();
            Console.ReadLine();
            Console.Clear();
        }



        //UPDATE CLIENTE
        private static void UpdateCliente()
        {
            Console.Clear();
            Console.WriteLine("**** Actualizar información de un cliente ****");
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
            Console.Clear();
        }

        //DELETE CLIENTE
        private static void DeleteCliente()
        {
            Console.Clear();
            Console.WriteLine("**** Eliminar un cliente existente ****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del cliente a eliminar: ");
            string cedula = Console.ReadLine();
            Cliente objClienteBuscado = BaseDatos.BaseDeDatos.BuscarClientePorCedula(cedula);

            if (objClienteBuscado != null)
            {
                Console.WriteLine($"¿Está seguro de que desea eliminar la información del cliente: {objClienteBuscado.getNombresCompletos()} ? (S/N)");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BaseDatos.BaseDeDatos.BaseDatosCliente.Remove(objClienteBuscado);
                    Console.WriteLine("Información eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Se ha cancelado la eliminación.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}