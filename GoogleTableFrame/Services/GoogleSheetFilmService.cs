using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTable
{
    public class GoogleSheetFilmService : GoogleSheetService, IMovieDbService
    {
        private const string _filmNameColumn = "A";
        private const int _listStartRow = 2;
        private const string _emtyCellCalculator = "K2";

        public GoogleSheetFilmService(): base(){
        }

        public async Task<IEnumerable<SavedFilm>> GetFilms()
        {
            var range = $"{_filmNameColumn}{_listStartRow}:H";

            var values = await GetValues(range);
            var savedFilms = values.ToList().Select(x => MapHelper.Map<SavedFilm>(x));
            return savedFilms;
        }

        public async Task AddFilm(string filmName)
        {
            var emptyCellNumber = await GetEmtyCellNumber();
            if (emptyCellNumber == 0) {
                throw new Exception();
            }
            var insertRange = $"{_filmNameColumn}{emptyCellNumber}";
            await SetValue(filmName, insertRange);
        }

        private async Task<int> GetEmtyCellNumber()
        {
            var value = await GetValue(_emtyCellCalculator);
            if (Int32.TryParse(value, out var result))
            {
                return result;
            }
            return default;
        }
    }
}
