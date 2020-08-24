using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Activity : IActivity
    {
        private IMovieDbService _movieDbService;
        private IMovieDbSeachService _movieDbSeachService;

        public Activity(IMovieDbService movieDbService, IMovieDbSeachService movieDbSeachService) {
            _movieDbService = movieDbService;
            _movieDbSeachService = movieDbSeachService;
        }

        public async Task<Film> SeachFilm(string id)
        {
            var film = await _movieDbSeachService.GetFilm(id);

            return film;
        }

        public async Task<IEnumerable<Film>> SeachFilms(string filmName) {
            var films = await _movieDbSeachService.GetFilmList(filmName);

            return films;
        }

        public async Task AddFilm(string filmName) {
            await _movieDbService.AddFilm(filmName);
        }

        public async Task<IEnumerable<SavedFilm>> GetSavedFilms() {
            var filmsName = await _movieDbService.GetFilms();

            return filmsName;
        }
    }
}
