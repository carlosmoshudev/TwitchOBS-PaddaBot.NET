using System;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace PaddaBotNET.Models {
    class ChatBots {
        TwitchClient client;
        public ChatBots(Credentials credentials) {
            ConnectionCredentials botCredentials = new ConnectionCredentials
            (
                twitchUsername: credentials.account, 
                twitchOAuth: credentials.token
            );
            ClientOptions options = new ClientOptions {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
        }
    }
}
