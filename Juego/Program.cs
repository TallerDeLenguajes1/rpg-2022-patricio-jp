using System.Text.Json;

Console.Clear();
Console.WriteLine("======================================");
Console.WriteLine("====== Bienvenido a Combates Mu ======");
Console.WriteLine("======================================");
// Random rnd = new Random();

List<Personaje> personajes = new List<Personaje>();
int cantPersonajes = personajes.Count;
List<Combate> combates = new List<Combate>();
int cantCombates = 0;

bool seguir = true;
Thread.Sleep(2000);
do {
    Console.Clear();
    Console.WriteLine("====== Combates Mu - Menú principal ======");
    Console.WriteLine($"Personajes listos para combatir: {cantPersonajes}");
    Console.WriteLine("1. Mostrar personajes");
    Console.WriteLine("2. Generar personajes aleatorios");
    Console.WriteLine("3. Cargar personajes desde archivo .json");
    Console.WriteLine("4. Guardar jugadores actuales en archivo .json");
    Console.WriteLine("5. Iniciar combates");
    Console.WriteLine("6. Mostrar ranking de personajes");
    Console.WriteLine("0. Salir");

    switch (Console.ReadKey().Key) {
        case ConsoleKey.D1:
            Console.Clear();
            mostrarPersonajes(personajes);
            break;
        case ConsoleKey.D2:
            Console.Clear();
            cargarPersonajes(personajes);
            cantPersonajes = personajes.Count;
            break;
        case ConsoleKey.D3:
            Console.Clear();
            cargarPersonajesDesdeJson(personajes);
            cantPersonajes = personajes.Count;
            break;
        case ConsoleKey.D4:
            Console.Clear();
            guardarPersonajesJson(personajes);
            break;
        case ConsoleKey.D5:
            Console.Clear();
            IniciarCombates(personajes, ref cantPersonajes, ref combates, ref cantCombates);
            break;
        case ConsoleKey.D6:
            Console.Clear();
            MostrarRanking();
            break;
        case ConsoleKey.D0:
            seguir = false;
            break;
    }
} while (seguir);

Console.WriteLine("\nPresione cualquier tecla para continuar...");
Console.ReadKey();
// End

static void cargarPersonajes(List<Personaje> listaPersonajes) {
    Console.Write("\nIngrese la cantidad de personajes que habrá: ");
    string entrada = Console.ReadLine();
    int cantPsjes = 0;
    while (!Int32.TryParse(entrada, out cantPsjes) && cantPsjes < 2) {
        Console.Write("\nError! Debe ingresar un número válido: ");
        entrada = Console.ReadLine();
    }
    for (int i = 1; i <= cantPsjes; i++) {
        listaPersonajes.Add(new Personaje());
    }
    using (StreamWriter sw = new StreamWriter("jugadores.json")) {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        sw.WriteLine(JsonSerializer.Serialize(listaPersonajes, jsonOptions));
        sw.Close();
    }
    Console.WriteLine("Generando personajes...");
    Thread.Sleep(1500);
    Console.WriteLine("Personajes generados con éxito.");
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void mostrarPersonajes(List<Personaje> personajes) {
    if (personajes.Count > 0) {
        Console.WriteLine("========================");
        Console.WriteLine("====== Personajes ======");
        Console.WriteLine("========================");
        for (int i = 0; i < personajes.Count; i++) {
            Console.WriteLine(personajes[i].ToString());
        }
    } else {
        Console.WriteLine("No hay personajes cargados.");
    }
    Console.Write("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void IniciarCombates(List<Personaje> personajes, ref int cantPersonajes, ref List<Combate> combates, ref int cantCombates) {
    while (cantPersonajes > 1) {
        for (int i = 0, j = 0; i < cantPersonajes - 1; i += 2) {
            combates.Add(new Combate(personajes[i], personajes[i + 1]));
            cantCombates++;
            j++;
        }

        for (int i = 0; i < cantCombates; i++) {
            if (cantPersonajes == 2) {
                Console.WriteLine("\n[FINAL]: " + combates[i].ToString());
            } else {
                Console.WriteLine("\n" + combates[i].ToString());
            }
            combates[i].IniciarCombate();
            personajes.Remove(combates[i].Perdedor);
        }

        cantPersonajes = personajes.Count;
        combates = new List<Combate>();
        cantCombates = 0;
    }

    if (!File.Exists("ganadores.csv")) File.Create("ganadores.csv").Close();

    List<string> ganadores = File.ReadAllLines("ganadores.csv").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

    string datosPsjeExistente = ganadores.Find(g => g.Split(";")[0].Equals(personajes[0].Datos.Tipo.ToString()) && g.Split(";")[1].Equals(personajes[0].Datos.Nombre));
    int cantBat;
    if (datosPsjeExistente != null) {
        string cantBatallasPrevias = datosPsjeExistente.Split(";")[2];
        cantBat = Int32.Parse(cantBatallasPrevias);
    } else {
        cantBat = 0;
    }

    ganadores.RemoveAll(x => x.Split(";")[0].Equals(personajes[0].Datos.Tipo.ToString()) && x.Split(";")[1].Equals(personajes[0].Datos.Nombre));

    string persoanajeAGuardar = personajes[0].Datos.Tipo.ToString() + ";" + personajes[0].Datos.Nombre + ";" + (personajes[0].CantBatallas + cantBat);

    ganadores.Add(persoanajeAGuardar);
    File.WriteAllLines("ganadores.csv", ganadores);

    personajes[0].CantBatallas += cantBat;
    Console.WriteLine("\n=====================");
    Console.WriteLine("====== Ganador ======");
    Console.WriteLine("=====================");
    Console.WriteLine(personajes[0].ToString());
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void MostrarRanking() {
    if (File.Exists("ganadores.csv")) {
        List<string> ganadores = File.ReadAllLines("ganadores.csv").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
        var sortedGanadores = ganadores.Select(s => new { Str = s, Split = s.Split(";")})
                                       .OrderByDescending(x => int.Parse(x.Split[2]))
                                       .ThenBy(x => x.Split[0] + x.Split[1])
                                       .Select(x => x.Str)
                                       .ToList();
        Console.WriteLine("=====================");
        Console.WriteLine("====== Ranking ======");
        Console.WriteLine("=====================");
        foreach (string psje in sortedGanadores) {
            string tipoPsje = psje.Split(";")[0],
            nombrePsje = psje.Split(";")[1],
            cantBat = psje.Split(";")[2];
            Console.WriteLine($"({tipoPsje}) {nombrePsje} -> {cantBat} batallas ganadas");
        }
    } else {
        Console.WriteLine("No existen registros guardados.");
    }

    Console.Write("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void cargarPersonajesDesdeJson(List<Personaje> personajes) {
    Console.WriteLine("Cargando personajes desde \"jugadores.json\"...");
    using (StreamReader sr = new StreamReader("jugadores.json")) {
        List<Personaje> psjesCargados = JsonSerializer.Deserialize<List<Personaje>>(sr.ReadToEnd());
        foreach (Personaje psje in psjesCargados) {
            personajes.Add(psje);
        }
        Thread.Sleep(1000);
        if (psjesCargados.Count > 0) {
            Console.WriteLine($"Cargados {psjesCargados.Count} personajes.");
        } else {
            Console.WriteLine("No hay personajes para cargar.");
        }
        sr.Close();
    }
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

static void guardarPersonajesJson(List<Personaje> personajes) {
    Console.WriteLine("Guardando personajes en \"jugadores.json\"...");
    using (StreamWriter sw = new StreamWriter("jugadores.json")) {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        sw.WriteLine(JsonSerializer.Serialize(personajes, jsonOptions));
        sw.Close();
    }
    Thread.Sleep(1000);
    Console.WriteLine("Guardado exitoso.");
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}