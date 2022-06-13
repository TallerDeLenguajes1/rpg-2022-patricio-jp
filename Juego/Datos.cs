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
    private TipoPersonaje tipo;
    private string nombre;
    private string apodo;
    private DateTime fechaDeNacimiento;
    private int salud;

    public Datos(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaNac) {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.Apodo = apodo;
        this.FechaDeNacimiento = fechaNac;
        this.Salud = 100;
    }

    public TipoPersonaje Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Salud { get => salud; set => salud = value; }
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