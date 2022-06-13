public class Personaje {
    private const int MDP = 50000;
    private static Random rnd = new Random();
    private Datos datos;
    private Caracteristicas caracteristicas;

    public Personaje(string nombre, string apodo, DateTime fechaNac) {
        var tiposP = Enum.GetValues(typeof(TipoPersonaje));
        TipoPersonaje tipoPj = (TipoPersonaje) tiposP.GetValue(rnd.Next(tiposP.Length));
        this.datos = new Datos(tipoPj, nombre, apodo, fechaNac);
        this.caracteristicas = new Caracteristicas();
    }

    public Datos Datos { get => datos; set => datos = value; }
    public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

    public void Atacar(Personaje objetivo) {
        float PoderDisparo = caracteristicas.Fuerza * caracteristicas.Destreza * caracteristicas.Nivel;
        float EfectividadAtaque = rnd.Next(1, 100) / 100;
        float ValorAtaque = PoderDisparo * EfectividadAtaque;

        float PoderDefensa = objetivo.caracteristicas.Velocidad * objetivo.caracteristicas.Armadura;

        int DanioProvocado = (int)(ValorAtaque - PoderDefensa) / MDP * 100;

        objetivo.datos.Salud -= DanioProvocado;
    }

    public override string ToString() {
        return "\nTipo de personaje: " + this.datos.Tipo.ToString() + "\nNombre: " + this.datos.Nombre + "\nApodo: " + this.datos.Apodo + "\nFecha de nacimiento: " + this.datos.FechaDeNacimiento.Date.ToString() + "\nEdad: " + this.datos.Edad + "\n--- Stats ---\nVelocidad: " + this.caracteristicas.Velocidad + "\nDestreza: " + this.caracteristicas.Destreza + "\nFuerza: " + this.caracteristicas.Fuerza + "\nArmadura: " + this.caracteristicas.Armadura + "\nNivel: " + this.caracteristicas.Nivel;
    }
}