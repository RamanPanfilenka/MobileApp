using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleTable
{
    public class GoogleSheetService
    {
        protected SheetsService _sheetsService;
        protected const string _spreadsheetId = "1J_Gtu7wLZWJAMtXWvHg4DbBRoq14lUBT5XaugkQsuB0";
        protected const string _sheetName = "Films";
     
        public GoogleSheetService() {
            _sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = UserCredentialsProvider.GetUserCredential(),
                ApplicationName = "Some",
            });
        }

        public async Task SetValue(string value, string range) {
            var valueRangeBody = new ValueRange()
            {
                Values = GetValueRange(new List<object>(new[] { value })),
                MajorDimension = "COLUMNS"
            };
            var inserRange = GetSheetRange(range);
            var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRangeBody, _spreadsheetId, inserRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            await updateRequest.ExecuteAsync();
        }

        private IList<IList<object>> GetValueRange(IList<object> range)
        {
            return range.Select(x => (IList<object>)new List<object>(new[] { x })).ToList();
        }

        public async Task<string> GetValue(string range) {
            var response = await SendGetRequest(range);
            
            return response.Values.FirstOrDefault()?.FirstOrDefault()?.ToString() ?? string.Empty;
        }

        public async Task<IEnumerable<string>> GetValues(string range)
        {
            var response = await SendGetRequest(range);

            return response.Values.Where(x => x.Count != 0).Select(x => x.FirstOrDefault()?.ToString());
        }

        private async Task<ValueRange> SendGetRequest(string range) {
            var sheetRange = GetSheetRange(range);
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, sheetRange);
            return await request.ExecuteAsync();
        }

        private string GetSheetRange(string range) {
            return string.Format("{0}!{1}", _sheetName, range);
        }
       
    }
}
