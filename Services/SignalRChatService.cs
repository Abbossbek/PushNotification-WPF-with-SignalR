using Microsoft.AspNetCore.SignalR.Client;

using PushServer.Lib.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPushNotification.Services
{
    public class SignalRChatService
    {
        private readonly HubConnection _connection;

        public event Action<ServerMessage> MessageReceived;

        public SignalRChatService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<ServerMessage>("615eec2da5a1290001c9686b", (message) => MessageReceived?.Invoke(message));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }
    }
}
