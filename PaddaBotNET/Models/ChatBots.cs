using PaddaBotNET.Controllers;
using PaddaBotNET.Interfaces;
using System;
using System.Collections.Specialized;
using System.Configuration;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub;

namespace PaddaBotNET.Models {
    sealed class ChatBots {
        private readonly TwitchClient client;
        private readonly TwitchPubSub pubSub;
        private readonly IBotEventHandler eventHandler;
        private readonly OBSConnector obs;
        private readonly NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public ChatBots(Credentials credentials, OBSConnector obs, IBotEventHandler eventHandler) {
            this.obs = obs;
            this.eventHandler = eventHandler;
            ConnectionCredentials botCredentials = new ConnectionCredentials
            (
                twitchUsername: credentials.account,
                twitchOAuth: credentials.token
            );
            ClientOptions options = new ClientOptions {
                MessagesAllowedInPeriod = int.Parse(appSettings.Get("MessagesAllowed")),
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient webSocketClient = new WebSocketClient(options);
            client = new TwitchClient(webSocketClient);
            pubSub = new TwitchPubSub();
            pubSub.Connect();
            client.Connect();
        }
    }
}
