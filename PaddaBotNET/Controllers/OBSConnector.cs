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
            Console.WriteLine("Conectando a OBS..");
            obs = new ObsWebSocket();
            obs.Connect
            (
                url: $"{config.Get("WebSocketIP")}:{config.Get("WebSocketPort")}",
                password: config.Get("WebSocketPassword")
            );
            Console.WriteLine("OBS conectado.");
            return Task.CompletedTask;

        }
        public void Disconnect() => obs?.Disconnect();
        public OBSConnector() { }
    }
}
