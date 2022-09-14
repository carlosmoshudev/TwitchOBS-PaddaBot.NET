using PaddaBotNET.Controllers;
using PaddaBotNET.Models;
using PaddaBotNET.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace PaddaBotNET {
    internal class Program {
        private static TwitchBotConnector bot, streamer;
        private static OBSConnector obs = new OBSConnector();
        private static Dictionary<string, string> defaultMessages;
        private static Credentials botAuth, streamerAuth, pubSubAuth;
        private static void Main(string[] args) {
            FillCredentials();
            FillMessages();
            CreateBots();
            obs.Init();
            Console.ReadLine();
        }
        private static void CreateBots() {
            bot = new TwitchBotConnector(
                    bot: botAuth.account,
                    oauth: botAuth.token,
                    channel: ConfigurationManager.AppSettings.Get("StreamerChannel")
                );
            streamer = new TwitchBotConnector(
                    bot: streamerAuth.account,
                    oauth: streamerAuth.token,
                    channel: ConfigurationManager.AppSettings.Get("StreamerChannel")
                );
            Console.WriteLine("Bots levantados!");
        }
        private static void FillCredentials() {
            var auths = JsonDataLoader.ParseJson("credentials.json");
            botAuth = new Credentials(auths["BotAccount"], auths["BotToken"]);
            streamerAuth = new Credentials(auths["StreamerAccount"], auths["StreamerToken"]);
            pubSubAuth = new Credentials(auths["PubSubClientID"], auths["PubSubToken"]);
            Console.WriteLine($"Tokens cargados - {botAuth.account} y {streamerAuth.account}");
        }
        private static void FillMessages() {
            defaultMessages = JsonDataLoader.ParseJson("messages.json");
            Console.WriteLine("Diccionario de mensajes cargado");
        }
    }
}
