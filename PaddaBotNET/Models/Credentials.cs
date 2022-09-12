namespace PaddaBotNET.Models 
{
    internal class Credentials 
    {
        private string _account, _token;
        public string account => _account; 
        public string token => _token;

        public Credentials(string account, string token) 
        {
            this._account   = account;
            this._token     = token;
        }
    }
}
