using OBS.WebSocket.NET;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace PaddaBotNET.Controllers {
    internal sealed class OBSConnector {
        private ObsWebSocket obs;
        private readonly NameValueCollection config = ConfigurationManager.AppSettings;
        public Task Init() {
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
