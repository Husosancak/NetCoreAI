using NetCoreAI.Project3.RapidApi.ViewsModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

var client = new HttpClient();
List<ApiSeriesViewsModel> apiSeriesViewsModels = new List<ApiSeriesViewsModel>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "1c48b07bf3msha7e0e3176d9e14dp1b8520jsn37ee14cc5c9f" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    apiSeriesViewsModels = JsonConvert.DeserializeObject<List<ApiSeriesViewsModel>>(body);
    foreach (var series in apiSeriesViewsModels)
    {
        Console.WriteLine(series.rank +" - "+ series.title + " - Film Puanı " + series.rating + " - Yapım Yılı " + series.year);

    }


}

Console.ReadLine();