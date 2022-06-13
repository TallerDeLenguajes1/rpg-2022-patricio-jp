public class Caracteristicas {
    private static Random rnd = new Random();
    private int velocidad; // Entre 1 y 10
    private int destreza; // Entre 1 y 5
    private int fuerza; // Entre 1 y 10
    private int armadura; // Entre 1 y 10
    private int nivel; // Entre 1 y 10

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Nivel { get => nivel; set => nivel = value; }

    public Caracteristicas() {
        this.Velocidad = rnd.Next(1, 10);
        this.Destreza = rnd.Next(1, 5);
        this.Fuerza = rnd.Next(1, 10);
        this.Armadura = rnd.Next(1, 10);
        this.Nivel = rnd.Next(1, 10);
    }
}