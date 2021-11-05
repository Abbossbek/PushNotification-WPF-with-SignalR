
using Microsoft.AspNetCore.SignalR.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TestPushNotification.Services;

namespace TestPushNotification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44303/push")
                .Build();
            SignalRChatService service = new(connection);
            service.MessageReceived += Service_MessageReceived;
            service.Connect().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    MessageBox.Show("Unable to connect to color chat hub");
                }
            });
        }

        private void Service_MessageReceived(PushServer.Lib.Models.ServerMessage obj)
        {
            MessageBox.Show(JsonSerializer.Serialize(obj));
        }
    }
}
