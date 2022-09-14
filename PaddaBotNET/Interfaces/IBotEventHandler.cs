namespace PaddaBotNET.Interfaces {
    interface IBotEventHandler {
        void MessageReceivedHandler();
        void NewSubscriberHandler();
        void GotRaidedHandler();
        void UserJoinedHandler();
        void ConnectedHandler();
        void ChannelPointsRedeemedHandler();
        void PubSubConnected();
    }
}
