using System.Net;
using System.Text.Json;

public class ServicioAPI {
    private static Random rnd = new Random();
    private const string jsonType = "application/json";
    private const string API = "https://mhw-db.com/";

    public static List<Location> GetLocations() {
        List<Location> locations = null;
        var request = (HttpWebRequest) WebRequest.Create(API + "locations");
        request.Method = "GET";
        request.Accept = jsonType;

        try {
            using WebResponse response = request.GetResponse();
            using Stream streamResponse = response.GetResponseStream();
            using StreamReader sr = new StreamReader(streamResponse);
            string jsonResponse = sr.ReadToEnd();
            locations = JsonSerializer.Deserialize<List<Location>>(jsonResponse);

        } catch (WebException error) {
            Console.WriteLine(error.ToString());
        }

        return locations;
    }

    public static Location GetRandomLocation() {
        List<Location> locations = GetLocations();
        Location randomLocation = locations[rnd.Next(locations.Count)];

        return randomLocation;
    }
}