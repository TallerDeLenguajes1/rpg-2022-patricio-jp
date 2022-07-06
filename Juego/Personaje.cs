public class Personaje {
    private const int MDP = 50000;
    private static Random rnd = new Random();
    private Datos datos;
    private Caracteristicas caracteristicas;
    private int cantBatallas;

    public Personaje() {
        this.datos = new Datos();
        this.caracteristicas = new Caracteristicas();
        this.cantBatallas = 0;
    }

    public Datos Datos { get => datos; set => datos = value; }
    public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    public int CantBatallas { get => cantBatallas; set => cantBatallas = value; }

    public void Atacar(Personaje objetivo) {
        Console.Write("\n({0}) {1} ataca a ({2}) {3}\n", this.Datos.Tipo.ToString(), this.Datos.Nombre, objetivo.Datos.Tipo.ToString(), objetivo.Datos.Nombre);
        float PoderDisparo = Caracteristicas.Fuerza * Caracteristicas.Destreza * Caracteristicas.Nivel;
        float EfectividadAtaque = rnd.Next(1, 101);
        float ValorAtaque = PoderDisparo * EfectividadAtaque;

        float PoderDefensa = objetivo.Caracteristicas.Velocidad * objetivo.Caracteristicas.Armadura;

        float DanioProvocado = (ValorAtaque - PoderDefensa) / MDP * 100;
        if (DanioProvocado < 0) DanioProvocado = 0;
        if (DanioProvocado > objetivo.Datos.Salud) DanioProvocado = objetivo.Datos.Salud;

        objetivo.Datos.Salud -= DanioProvocado;
        // Console.WriteLine("Poder de disparo: {0}", PoderDisparo);
        // Console.WriteLine("Efectividad de ataque: {0}", EfectividadAtaque);
        // Console.WriteLine("Valor de ataque: {0}", ValorAtaque);
        // Console.WriteLine("Poder de defensa del objetivo: {0}", PoderDefensa);
        Console.WriteLine("Daño causado: {0}", DanioProvocado);
        Console.WriteLine("Salud restante de {0}: {1}", objetivo.Datos.Nombre, objetivo.Datos.Salud);
    }

    public override string ToString() {
        return "\nTipo de personaje: " + this.Datos.Tipo.ToString() + "\nNombre: " + this.Datos.Nombre + "\nApodo: " + this.Datos.Apodo + "\nFecha de nacimiento: " + this.Datos.FechaDeNacimiento.ToShortDateString() + "\nEdad: " + this.Datos.Edad + "\nCantidad de batallas: " + this.CantBatallas + "\n--- Stats ---\nVelocidad: " + this.Caracteristicas.Velocidad + "\nDestreza: " + this.Caracteristicas.Destreza + "\nFuerza: " + this.Caracteristicas.Fuerza + "\nArmadura: " + this.Caracteristicas.Armadura + "\nNivel: " + this.Caracteristicas.Nivel + "\n";
    }
}