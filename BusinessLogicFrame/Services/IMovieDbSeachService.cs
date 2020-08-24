using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IMovieDbSeachService
    {
        Task<Film> GetFilm(string id);

        Task<IEnumerable<Film>> GetFilmList(string filmName);
    }
}
