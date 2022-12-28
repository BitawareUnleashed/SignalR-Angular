namespace SignalR.Server.Models;
public class DataManager
{
    public static List<ChartModel> GetData()
    {
        var r = new Random();
        return new List<ChartModel>()
            {
                new ChartModel { Data = r.Next(1, 100) , Label = "Sky", BackgroundColor = "#5491DA" },
                new ChartModel { Data = r.Next(1, 100) , Label = "Fire", BackgroundColor = "#E74C3C" },
                new ChartModel { Data = r.Next(1, 100) , Label = "Grass", BackgroundColor = "#82E0AA" },
                new ChartModel { Data = r.Next(1, 100) , Label = "Building", BackgroundColor = "#E5E7E9" }
            };
    }
}
