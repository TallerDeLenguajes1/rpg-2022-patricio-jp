Console.Clear();
Console.WriteLine("======================================");
Console.WriteLine("====== Bienvenido a Combates Mu ======");
Console.WriteLine("======================================");
// Random rnd = new Random();

List<Personaje> personajes = cargarPersonajes();
int cantPersonajes = personajes.Count;
int cantCombates = 0;
mostrarPersonajes(personajes);

List<Combate> combates = new List<Combate>();
while (cantPersonajes != 1) {
    for (int i = 0, j = 0; i < cantPersonajes - 1; i += 2) {
        combates.Add(new Combate(personajes[i], personajes[i+1]));
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
Console.WriteLine("\n=====================");
Console.WriteLine("====== Ganador ======");
Console.WriteLine("=====================");
Console.WriteLine(personajes[0].ToString());

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
        personajes.Add(new Personaje());
    }

    return personajes;
}

static void mostrarPersonajes(List<Personaje> personajes) {
    Console.WriteLine("\n========================");
    Console.WriteLine("====== Personajes ======");
    Console.WriteLine("========================");
    for (int i = 0; i < personajes.Count; i++) {
        Console.WriteLine(personajes[i].ToString());
    }
}
