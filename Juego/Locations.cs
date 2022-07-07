public class Camp {
    public int id { get; set; }
    public int zone { get; set; }
    public string name { get; set; }
}

public class Location {
    public int id { get; set; }
    public int zoneCount { get; set; }
    public string name { get; set; }
    public List<Camp> camps { get; set; }

    public override string ToString() {
        return $"{name}";
    }
}
