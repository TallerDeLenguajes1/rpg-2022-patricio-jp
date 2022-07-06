using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoPersonaje {
    DarkWizard,
    SoulMaster,
    DarkKnight,
    BladeKnight,
    FairyElf,
    MuseElf,
    MagicGladiator,
    DarkLord
}

public class Datos {
    private static Random rnd = new Random();
    private string[] Nombres = {"_HoLanDeS_", "-Carnicer0", "Mochi", "EXiloN", "Snoop_Dogg", "RECLUSO_1", "-_TiTaN_-", "SrOdin", "Kreinner", "xMaxi", "zion1994", "Rydog", "Lander420", "Sarfield", "Vulcano1", "NewBlade"};
    private string[] Apodos = {"Holandés", "Carnicero", "Mochi", "Exilon", "Snoop Dogg", "Recluso", "Titán", "Odin", "Kreinner", "Maxi", "Zion", "Rydog", "Lander", "Sarfield", "Vulcano", "Blade"};
    private TipoPersonaje tipo;
    private string nombre;
    private string apodo;
    private DateTime fechaDeNacimiento;
    private float salud;

    public Datos() {
        var tiposP = Enum.GetValues(typeof(TipoPersonaje));
        TipoPersonaje tipoPj = (TipoPersonaje) tiposP.GetValue(rnd.Next(tiposP.Length));
        this.Tipo = tipoPj;
        int indiceAux = rnd.Next(0,16);
        this.Nombre = Nombres[indiceAux];
        this.Apodo = Apodos[indiceAux];
        this.Salud = 100;

        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        this.FechaDeNacimiento = start.AddDays(rnd.Next(range));
    }

    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public float Salud { get => salud; set => salud = value; }
    public int Edad {
        get {
            var age = DateTime.Now.Year - fechaDeNacimiento.Year;
            if (age > 0) {
                age -= Convert.ToInt32(DateTime.Now.Date < fechaDeNacimiento.Date.AddYears(age));
            } else {
                age = 0;
            }
            return age;
        }
    }
}