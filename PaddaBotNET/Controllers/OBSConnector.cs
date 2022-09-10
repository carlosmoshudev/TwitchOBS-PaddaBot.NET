using System;
using System.Threading.Tasks;
using OBS.WebSocket.NET;
namespace PaddaBotNET.Controllers 
{
    internal class OBSConnector 
    {
        private string port = "";
        private ObsWebSocket obs;
        public Task Init() 
        {
            obs = new ObsWebSocket();
            try 
            {
                obs.Connect($"ws://127.0.0.1:{port}", "");
                return Task.CompletedTask;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return Task.FromException(ex);
            }
        }
        public void Disconnect() => obs?.Disconnect();
        public OBSConnector() { }
    }
}
