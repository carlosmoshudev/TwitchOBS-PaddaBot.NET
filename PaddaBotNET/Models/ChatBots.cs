﻿#region System
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
#endregion
#region TwitchLib
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
#endregion
using PaddaBotNET.Controllers;
namespace PaddaBotNET.Models 
{
    class ChatBots 
    {

        private readonly TwitchClient client;
        private readonly TwitchPubSub pubSub;
        private readonly BotEvents botEvents;
        private readonly OBSConnector obs;
        private readonly NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public ChatBots(Credentials credentials, string channel, OBSConnector obs, BotEvents botEvents) 
        {
            this.obs        = obs;
            this.botEvents  = botEvents;
            ConnectionCredentials botCredentials = new ConnectionCredentials
            (
                twitchUsername: credentials.account, 
                twitchOAuth:    credentials.token
            );
            ClientOptions options = new ClientOptions 
            {
                MessagesAllowedInPeriod = int.Parse(appSettings.Get("MessagesAllowed")),
                ThrottlingPeriod        = TimeSpan.FromSeconds(30)
            };
            WebSocketClient webSocketClient = new WebSocketClient(options);
            client = new TwitchClient(webSocketClient);
            pubSub = new TwitchPubSub();
            pubSub.Connect();
            client.Connect();
        }
    }
}
