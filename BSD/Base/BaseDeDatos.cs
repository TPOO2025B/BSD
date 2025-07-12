using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using BSD.Clases;

namespace BSD.BaseDatos
{
    public static class BaseDeDatos
    {
        public static List<Cliente> BaseDatosCliente = new List<Cliente>();

        public static void imprimirCliente()
        {
            foreach (Cliente cliente in BaseDatosCliente)
            {
                cliente.imprimir();
            }
        }
    }
}
