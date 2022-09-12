using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;
using OBS.WebSocket.NET;

namespace PaddaBotNET.Controllers 
{
    internal class OBSConnector 
    {
        private ObsWebSocket obs;
        private readonly NameValueCollection config = ConfigurationManager.AppSettings;
        public Task Init() 
        {
            obs = new ObsWebSocket();
            try 
            {
                obs.Connect
                (
                    url: $"{config.Get("WebSocketIP")}:{config.Get("WebSocketPort")}",
                    password:""
                );
                return Task.CompletedTask;
            } 
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
                return Task.FromException(exception);
            }
        }
        public void Disconnect() => obs?.Disconnect();
        public OBSConnector() { }
    }
}
