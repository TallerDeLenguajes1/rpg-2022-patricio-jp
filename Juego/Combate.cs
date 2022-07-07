public class Combate {
    private static Random rnd = new Random();
    private Personaje contrincante1;
    private Personaje contrincante2;

    public Personaje Contrincante1 { get => contrincante1; set => contrincante1 = value; }
    public Personaje Contrincante2 { get => contrincante2; set => contrincante2 = value; }

    private Personaje ganador;
    private Personaje perdedor;

    public Personaje Ganador { get => ganador; set => ganador = value; }
    public Personaje Perdedor { get => perdedor; set => perdedor = value; }

    private Location lugarCombate;
    public Location LugarCombate { get => lugarCombate; set => lugarCombate = value; }

    public Combate(Personaje pj1, Personaje pj2) {
        this.Contrincante1 = pj1;
        this.Contrincante2 = pj2;
        this.LugarCombate = ServicioAPI.GetRandomLocation();
    }

    public override string ToString() {
        return $"=== === === === === === === === ===\nLugar del combate: {LugarCombate.ToString()}\n({Contrincante1.Datos.Tipo.ToString()}) {Contrincante1.Datos.Nombre} VS ({Contrincante2.Datos.Tipo.ToString()}) {Contrincante2.Datos.Nombre}\n=== === === === === === === === ===";
    }

    public void IniciarCombate() {
        int cantAtaques = 3;
        while (cantAtaques > 0 && this.Contrincante1.Datos.Salud > 0 && this.Contrincante2.Datos.Salud > 0) {
            Contrincante1.Atacar(Contrincante2);
            Thread.Sleep(2000);
            if (Contrincante2.Datos.Salud <= 0) break; // Parar combate si el psje2 murió
            Contrincante2.Atacar(Contrincante1);
            Thread.Sleep(2000);
            if (Contrincante2.Datos.Salud <= 0) break; // Parar combate si el psje1 murió
            cantAtaques--;
        }

        if (Contrincante1.Datos.Salud > Contrincante2.Datos.Salud) {
            Console.WriteLine("\nGanador del combate: ({0}) {1}\n", Contrincante1.Datos.Tipo.ToString(), Contrincante1.Datos.Nombre);
            this.Ganador = Contrincante1;
            this.Perdedor = Contrincante2;

        } else if (Contrincante1.Datos.Salud < Contrincante2.Datos.Salud) {
            Console.WriteLine("\nGanador del combate: ({0}) {1}\n", Contrincante2.Datos.Tipo.ToString(), Contrincante2.Datos.Nombre);
            this.Ganador = Contrincante2;
            this.Perdedor = Contrincante1;

        } else { // En caso de empate, se elegirá el ganador al azar
            if (rnd.Next(1, 3) == 1) {
                Console.WriteLine("\nGanador del combate (por empate): ({0}) {1}\n", Contrincante1.Datos.Tipo.ToString(), Contrincante1.Datos.Nombre);
                this.Ganador = Contrincante1;
                this.Perdedor = Contrincante2;

            } else {
                Console.WriteLine("\nGanador del combate (por empate): ({0}) {1}\n", Contrincante2.Datos.Tipo.ToString(), Contrincante2.Datos.Nombre);
                this.Ganador = Contrincante2;
                this.Perdedor = Contrincante1;
            }
        }

        this.Ganador.Datos.Salud = 100; // Ganador del combate recuperará toda la salud
        this.Ganador.CantBatallas++;
    }

}