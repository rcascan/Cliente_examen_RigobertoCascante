using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace Cliente_examen_RigobertoCascante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear un objeto de la clase Cliente
            Cliente miCliente = new Cliente(5);

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menú de Detalle Cliente:");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Buscar cliente");
                Console.WriteLine("3. Mostrar clientes");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "3":
                        Console.Clear();
                        miCliente.MostrarClientes();
                        Console.WriteLine(" ");
                        Console.Write("Presione alguna tecla para continuar.... ");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Ingrese el nombre del cliente a buscar: ");
                        Console.WriteLine(" ");
                        string nombreBuscar = Console.ReadLine();
                        miCliente.BuscarCliente(nombreBuscar);
                        Console.WriteLine(" ");
                        Console.Write("Presione alguna tecla para continuar.... ");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Ingrese el nombre del cliente a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        miCliente.EliminarCliente(nombreEliminar);
                        Console.WriteLine(" ");
                        Console.Write("Presione alguna tecla para continuar.... ");
                        Console.ReadKey();
                        break;
                    case "1":
                        Console.Clear();
                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Ingrese la dirección del cliente: ");
                        string direccion = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Ingrese el teléfono del cliente: ");
                        string telefono = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Ingrese el correo electrónico del cliente: ");
                        string correo = Console.ReadLine();
                        miCliente.RegistrarNuevoCliente(nombre, direccion, telefono, correo);
                        Console.WriteLine(" ");
                        Console.Write("Presione alguna tecla para continuar.... ");
                        Console.ReadKey();

                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }
    }

    public class Cliente
    {
        private string[] nombres;
        private string[] direcciones;
        private string[] telefonos;
        private string[] correosElectronicos;
        private int cantidadClientes;

        public Cliente(int capacidadInicial)
        {
            nombres = new string[capacidadInicial];
            direcciones = new string[capacidadInicial];
            telefonos = new string[capacidadInicial];
            correosElectronicos = new string[capacidadInicial];
            cantidadClientes = 0;
        }

        private void AmpliarCapacidad()
        {
            int nuevaCapacidad = nombres.Length * 2;
            Array.Resize(ref nombres, nuevaCapacidad);
            Array.Resize(ref direcciones, nuevaCapacidad);
            Array.Resize(ref telefonos, nuevaCapacidad);
            Array.Resize(ref correosElectronicos, nuevaCapacidad);
        }

        public void RegistrarCliente(int indice, string nombre, string direccion, string telefono, string correoElectronico)
        {
            if (indice >= 0 && indice < nombres.Length)
            {
                nombres[indice] = nombre;
                direcciones[indice] = direccion;
                telefonos[indice] = telefono;
                correosElectronicos[indice] = correoElectronico;
                cantidadClientes++;
            }
        }

        public void MostrarClientes()
        {
            for (int i = 0; i < cantidadClientes; i++)
            {
                Console.WriteLine("Nombre: " + nombres[i]);
                Console.WriteLine("Dirección: " + direcciones[i]);
                Console.WriteLine("Teléfono: " + telefonos[i]);
                Console.WriteLine("Correo electrónico: " + correosElectronicos[i]);
                Console.WriteLine();
            }
        }

        public void BuscarCliente(string nombre)
        {
            for (int i = 0; i < cantidadClientes; i++)
            {
                if (nombres[i] != null && nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Dirección: " + direcciones[i]);
                    Console.WriteLine("Teléfono: " + telefonos[i]);
                    Console.WriteLine("Correo electrónico: " + correosElectronicos[i]);
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("No se encontró el cliente.");
        }

        public void EliminarCliente(string nombre)
        {
            for (int i = 0; i < cantidadClientes; i++)
            {
                if (nombres[i] != null && nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < cantidadClientes - 1; j++)
                    {
                        nombres[j] = nombres[j + 1];
                        direcciones[j] = direcciones[j + 1];
                        telefonos[j] = telefonos[j + 1];
                        correosElectronicos[j] = correosElectronicos[j + 1];
                    }
                    cantidadClientes--;
                    nombres[cantidadClientes] = null;
                    direcciones[cantidadClientes] = null;
                    telefonos[cantidadClientes] = null;
                    correosElectronicos[cantidadClientes] = null;
                    Console.WriteLine("Cliente eliminado.");
                    return;
                }
            }
            Console.WriteLine("No se encontró el cliente.");
        }

        public void RegistrarNuevoCliente(string nombre, string direccion, string telefono, string correoElectronico)
        {
            if (cantidadClientes >= nombres.Length)
            {
                AmpliarCapacidad();
            }

            RegistrarCliente(cantidadClientes, nombre, direccion, telefono, correoElectronico);
            Console.WriteLine("Cliente registrado.");
        }
    }
}




