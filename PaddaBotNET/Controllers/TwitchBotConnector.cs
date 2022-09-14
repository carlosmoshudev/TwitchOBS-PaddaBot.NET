namespace PaddaBotNET.Controllers {
    internal sealed class TwitchBotConnector {
        public string bot, oauth, channel;
        public TwitchBotConnector(string bot, string oauth, string channel) {
            this.bot = bot;
            this.oauth = oauth;
            this.channel = channel;
        }
    }
}
