using System;
using System.Collections.Generic;

namespace SistemaRegistroClientes
{
    // Clase base Cliente
    class Cliente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }

        // Método virtual para mostrar información
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Correo: {Correo}");
        }
    }

    // Clase derivada ClienteCorporativo
    class ClienteCorporativo : Cliente
    {
        public string NombreEmpresa { get; set; }

        // Sobrescritura del método para incluir el nombre de la empresa
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Correo: {Correo}, Empresa: {NombreEmpresa}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Sistema de Registro de Clientes");
                Console.WriteLine("1. Agregar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese la edad del cliente: ");
                        int edad = int.Parse(Console.ReadLine());

                        Console.Write("Ingrese el correo del cliente: ");
                        string correo = Console.ReadLine();

                        Console.Write("¿Es un cliente corporativo? (si/no): ");
                        string esCorporativo = Console.ReadLine().ToLower();

                        if (esCorporativo == "si")
                        {
                            Console.Write("Ingrese el nombre de la empresa: ");
                            string nombreEmpresa = Console.ReadLine();

                            ClienteCorporativo clienteCorporativo = new ClienteCorporativo()
                            {
                                Nombre = nombre,
                                Edad = edad,
                                Correo = correo,
                                NombreEmpresa = nombreEmpresa
                            };
                            clientes.Add(clienteCorporativo);
                        }
                        else
                        {
                            Cliente cliente = new Cliente()
                            {
                                Nombre = nombre,
                                Edad = edad,
                                Correo = correo
                            };
                            clientes.Add(cliente);
                        }

                        Console.WriteLine("Cliente agregado exitosamente.\n");
                        break;

                    case "2":
                        Console.WriteLine("\nLista de Clientes:");
                        foreach (Cliente cliente in clientes)
                        {
                            cliente.MostrarInformacion();
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }
            }
        }
    }
}
