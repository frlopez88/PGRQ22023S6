using Serializacion.Models;
using System.Runtime.Serialization.Formatters.Binary;



int opcion = 0;
List<Persona> personas = new List<Persona>();

try {
    /*Abir y leer el archivo */
    byte[] data = File.ReadAllBytes("personas.bin");
    MemoryStream memory = new MemoryStream(data);
    BinaryFormatter formater = new BinaryFormatter();
    personas = (List<Persona>)formater.Deserialize(memory);
    memory.Close();

}
catch(Exception ex)
{
    Console.WriteLine("Sin archivo por cargar de Personas");

}

do {

    Console.WriteLine("1. Crear Persona  \n 2. Salir ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
           
           Console.WriteLine("Escribir Nombre");
           string nm  = Console.ReadLine();

            Console.WriteLine("Escribir Fecha Nacimiento año");
            int anio = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribir Fecha Nacimiento mes");
            int mes = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribir Fecha Nacimiento dia");
            int dia = int.Parse(Console.ReadLine());

            DateTime f = new DateTime(anio, mes, dia);


            Console.WriteLine("Escribir Identidad");
            string id = Console.ReadLine();

            Persona p = new Persona() { 
                nombre = nm , 
                fechaNacimiento = f,
                identidad = id

            };

            personas.Add(p);



            break;
        default:
            break;
    }

} while (opcion != 2);


foreach (Persona p in personas) {

    Console.WriteLine(p.ToString());

}

/*Escribir y cerrar el archivo*/

BinaryFormatter formateador = new BinaryFormatter();
MemoryStream memoria = new MemoryStream();

formateador.Serialize(memoria, personas);

byte[] datoSerializados = memoria.ToArray();

memoria.Close();
File.WriteAllBytes("personas.bin", datoSerializados);