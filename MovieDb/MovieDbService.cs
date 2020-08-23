using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDb
{
    public class MovieDbService
    {
        private string apiKey = "4b7c327767caaa643b340ff721f6df6a";
        private string baseUrl = "https://api.themoviedb.org/3/search/movie";

        public async Task<IEnumerable<Film>> GetFilmList(string filmName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{baseUrl}?api_key={apiKey}&query={filmName}");
            var content = response.Content;
            var contentString = await content.ReadAsStringAsync();

            return JsonConverter.DeserializeList<Film>(contentString);
        }
    }
}
