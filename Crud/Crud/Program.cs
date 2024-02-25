using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Crdu
{
    private List<Persona> personas = new List<Persona>();
    private int ultimoId = 0;

    public int ObtenerNuevoId()
    {
        return ultimoId++;
    }

    public void AgregarPersona(Persona persona)
    {
        persona.Id = ObtenerNuevoId();
        personas.Add(persona);
        Console.WriteLine("Persona agregada correctamente.");
    }

    public void MostrarPersonas()
    {
        Console.WriteLine("Lista de Personas:");
        foreach (var persona in personas)
        {
            Console.WriteLine($"ID: {persona.Id}, Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }
    }

    public void ActualizarPersona(int id, Persona nuevaPersona)
    {
        Persona personaExistente = personas.Find(p => p.Id == id);
        personaExistente.Nombre = nuevaPersona.Nombre;
        personaExistente.Edad = nuevaPersona.Edad;
        Console.WriteLine("Persona actualizada correctamente.");
    }

    public void EliminarPersona(int id)
    {
        Persona personaExistente = personas.Find(p => p.Id == id);
        personas.Remove(personaExistente);
        Console.WriteLine("Persona eliminada correctamente.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Crdu cruds = new Crdu();

        while (true)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar Persona");
            Console.WriteLine("2. Mostrar Personas");
            Console.WriteLine("3. Actualizar Persona");
            Console.WriteLine("4. Eliminar Persona");
            Console.WriteLine("5. Salir");

            Console.Write("Ingrese la opción deseada: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre de la persona: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la edad de la persona: ");
                    int edad = int.Parse(Console.ReadLine());

                    Persona nPersona = new Persona { Id = cruds.ObtenerNuevoId(), Nombre = nombre, Edad = edad };
                    cruds.AgregarPersona(nPersona);
                    break;

                case "2":
                    cruds.MostrarPersonas();
                    break;

                case "3":
                    Console.Write("Ingrese el ID de la persona a actualizar: ");
                    int idActualizar = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo nombre de la persona: ");
                    string nNombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva edad de la persona: ");
                    int nEdad = int.Parse(Console.ReadLine());

                    Persona nDatos = new Persona { Nombre = nNombre, Edad = nEdad };
                    cruds.ActualizarPersona(idActualizar, nDatos);
                    break;

                case "4":
                    Console.Write("Ingrese el ID de la persona a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine());
                    cruds.EliminarPersona(idEliminar);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        }
    }
}
