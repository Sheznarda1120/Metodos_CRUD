using ClienteRegistro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Agregar un cliente
        AgregarCliente();

        // Consultar clientes
        ConsultarClientes();

        // Modificar un cliente
        ModificarCliente();

        Console.ReadLine();
    }

    public static void AgregarCliente()
    {
        Console.WriteLine("Agregar cliente");
        using (var context = new ClienteContext())
        {
            Cliente cliente = new Cliente()
            {
                Nombre = "Carolina",
                Apellido = "Morales",
                Dirección = "Promesa de Dios",
                Telefono = "0975346732",
                FechaNacimiento = new DateTime(2000, 02, 11),
                Estado = "Activo"
            };

            context.Clientes.Add(cliente);
            context.SaveChanges();

            Console.WriteLine("Cliente agregado con éxito. ID: " + cliente.Id);
        }
    }

    public static void ConsultarClientes()
    {
        Console.WriteLine("Consultar clientes");
        using (var context = new ClienteContext())
        {
            List<Cliente> clientes = context.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("ID: " + cliente.Id);
                Console.WriteLine("Nombre: " + cliente.Nombre);
                Console.WriteLine("Apellido: " + cliente.Apellido);
                Console.WriteLine("Dirección: " + cliente.Dirección);
                Console.WriteLine("Teléfono: " + cliente.Telefono);
                Console.WriteLine("Fecha de Nacimiento: " + cliente.FechaNacimiento);
                Console.WriteLine("Estado: " + cliente.Estado);
                Console.WriteLine();
            }
        }
    }

    public static void ModificarCliente()
    {
        Console.WriteLine("Modificar el cliente");
        using (var context = new ClienteContext())
        {
            Console.WriteLine("Ingresar el ID del cliente que desea modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                Console.WriteLine("Ingresar el nuevo Nombre del cliente: ");
                cliente.Nombre = Console.ReadLine();

                Console.WriteLine("Ingresar el nuevo Apellido del cliente: ");
                cliente.Apellido = Console.ReadLine();

                Console.WriteLine("Ingresar la nueva Dirección del cliente: ");
                cliente.Dirección = Console.ReadLine();

                Console.WriteLine("Ingresar el nuevo Teléfono del cliente: ");
                cliente.Telefono = Console.ReadLine();

                Console.WriteLine("Ingresar la nueva Fecha de Nacimiento del cliente (yyyy-MM-dd): ");
                cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine("Cliente modificado con éxito");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
    }
}