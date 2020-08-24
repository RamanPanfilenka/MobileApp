using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace GoogleTable
{
    public static class UserCredentialsProvider
    {
        private static UserCredential _userCredential;

        private static readonly object _lock = new object();

        internal static UserCredential GetUserCredential() {
            if (_userCredential == null) {
                lock (_lock) {
                    _userCredential = LoadCrendentials();
                }
            }

            return _userCredential;
        }

        private static UserCredential LoadCrendentials() {
            UserCredential userCredential;
            string[] scopes = { SheetsService.Scope.Spreadsheets };
            var dir = Directory.GetCurrentDirectory();
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result; ;
            }

            return userCredential;
        }
    }
}
