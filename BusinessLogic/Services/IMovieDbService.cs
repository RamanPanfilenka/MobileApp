using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IMovieDbService
    {
        public Task<IEnumerable<SavedFilm>> GetFilms();

        public Task AddFilm(string filmName);
    }
}
