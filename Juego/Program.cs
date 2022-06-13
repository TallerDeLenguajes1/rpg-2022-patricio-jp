using System.Globalization;

CultureInfo culturaAR = CultureInfo.CreateSpecificCulture("es-AR");
Console.Clear();
Console.WriteLine("======================================");
Console.WriteLine("====== Bienvenido a Combates Mu ======");
Console.WriteLine("======================================");

List<Personaje> personajes = cargarPersonajes();

mostrarPersonajes(personajes);

Console.Read();

static List<Personaje> cargarPersonajes() {
    Console.Write("Ingrese la cantidad de personajes que habrá: ");
    string entrada = Console.ReadLine();
    int cantPersonajes = 0;
    while (!Int32.TryParse(entrada, out cantPersonajes) && cantPersonajes < 2) {
        Console.Write("\nError! Debe ingresar un número válido: ");
        entrada = Console.ReadLine();
    }

    List<Personaje> personajes = new List<Personaje>();

    for (int i = 1; i <= cantPersonajes; i++) {
        Console.WriteLine("--- Personaje {0} ---", i);
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese su apodo: ");
        string apodo = Console.ReadLine();

        Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD) : ");
        string sFechaNac = Console.ReadLine();
        DateTime fechaNac;
    
        while (!DateTime.TryParse(sFechaNac, out fechaNac)) {
            Console.Write("Error! Ingrese una fecha válida (YYYY-MM-DD): ");
        }

        personajes.Add(new Personaje(nombre, apodo, fechaNac));
    }

    return personajes;
}

static void mostrarPersonajes(List<Personaje> personajes) {
    for (int i = 0; i < personajes.Count; i++) {
        Personaje psje = personajes[i];
        Console.WriteLine(psje.ToString());
    }
}