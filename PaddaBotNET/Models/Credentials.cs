namespace PaddaBotNET.Models {
    internal sealed class Credentials {
        private string _account, _token;
        public string account => _account;
        public string token => _token;

        public Credentials(string account, string token) {
            _account = account;
            _token = token;
        }
    }
}
