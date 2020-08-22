using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleTable
{
    public class GoogleSheetFilmService : GoogleSheetService
    {
        private const string _filmNameColumn = "A";
        private const int _listStartRow = 2;
        private const string _emtyCellCalculator = "K2";

        public GoogleSheetFilmService(): base(){
        }

        public async Task<IEnumerable<string>> GetFilms()
        {
            var range = $"{_filmNameColumn}{_listStartRow}:{_filmNameColumn}";

            return await GetValues(range);
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
