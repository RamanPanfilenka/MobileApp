using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IMovieDbSeachService
    {
        public Task<Film> GetFilm(string id);

        public Task<IEnumerable<Film>> GetFilmList(string filmName);
    }
}
