using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IActivity
    {
        Task<Film> SeachFilm(string id);

        Task<IEnumerable<Film>> SeachFilms(string filmName);

        Task AddFilm(string filmName);

        Task<IEnumerable<SavedFilm>> GetSavedFilms();
    }
}
