using BusinessLogic.Models;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDb
{
    public class MovieDbService : IMovieDbSeachService
    {
        private string apiKey = "4b7c327767caaa643b340ff721f6df6a";
        private string baseUrl = "https://api.themoviedb.org/3/search/movie";

        public Task<Film> GetFilm(string id)
        {
            throw new System.NotImplementedException();
        }

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
