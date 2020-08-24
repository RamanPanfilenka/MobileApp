using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IMovieDbService
    {
        Task<IEnumerable<SavedFilm>> GetFilms();

        Task AddFilm(string filmName);
    }
}
