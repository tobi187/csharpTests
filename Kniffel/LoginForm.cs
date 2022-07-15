using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kniffel.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kniffel
{
    public partial class LoginForm : Form
    {
        HubConnection connection;
        public LoginForm()
        {
            InitializeComponent();

            connection =
                new HubConnectionBuilder()
                .WithUrl("https://localhost:7162/findGame")
                .WithAutomaticReconnect()
                .Build();

        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection.On<string>("GameFound", (roomNumber) =>
            {
                statusBox.Text = "Game Found, Starting in 5 seconds";
                OnGameFound();
            });

            connection.On<RoomModel>("UpdateGameRooms", (rooms) =>
            {
                foreach (var r in rooms.groupList)
                {
                    roomList.Items.Add(r);
                }
            });

            try
            {
                statusBox.Text = "Try Connecting";
                connectButton.Enabled = false;
                await connection.StartAsync();
                statusBox.Text = "Connected";
                await connection.InvokeAsync("Join");
            }
            catch (Exception ex)
            {
                statusBox.Text = $"Connection failed\n{ex}";
                throw;
            }
        }

        private async void OnGameFound()
        {
            Thread.Sleep(5000);

            var gameForm = new Form1();
            gameForm.Show();

            await connection.DisposeAsync();
        }

        private async void createGroup_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("CreateRoom");
            statusBox.Text = $"Waiting for second player ()";
        }

        private async void joinGame_Click(object sender, EventArgs e)
        {
            var room = (string)roomList.SelectedItem;
            await connection.InvokeAsync("JoinRoom", room);
        }
    }
}
