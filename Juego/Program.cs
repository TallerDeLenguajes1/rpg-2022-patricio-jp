﻿using System.Globalization;

CultureInfo culturaAR = CultureInfo.CreateSpecificCulture("es-AR");
Console.Clear();
Console.WriteLine("======================================");
Console.WriteLine("====== Bienvenido a Combates Mu ======");
Console.WriteLine("======================================");

List<Personaje> personajes = cargarPersonajes();

mostrarPersonajes(personajes);

Console.Read();
// End

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
        Personaje nuevo = new Personaje("", "", DateTime.Now); // Se cambiará al ingresar los datos
        Console.WriteLine("--- Personaje {0} ({1}) ---", i, nuevo.Datos.Tipo.ToString());
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();
        nuevo.Datos.Nombre = nombre;

        Console.Write("Ingrese su apodo: ");
        string apodo = Console.ReadLine();
        nuevo.Datos.Apodo = apodo;

        Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD) : ");
        string sFechaNac = Console.ReadLine();
        DateTime fechaNac;
    
        while (!DateTime.TryParse(sFechaNac, out fechaNac)) {
            Console.Write("Error! Ingrese una fecha válida (YYYY-MM-DD): ");
        }
        nuevo.Datos.FechaDeNacimiento = fechaNac;

        personajes.Add(nuevo);
    }

    return personajes;
}

static void mostrarPersonajes(List<Personaje> personajes) {
    for (int i = 0; i < personajes.Count; i++) {
        Personaje psje = personajes[i];
        Console.WriteLine(psje.ToString());
    }
}
