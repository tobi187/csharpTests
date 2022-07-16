﻿using System;
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
        bool isFirstPlayer { get; set; }
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
            connection.On<string, string>("GameFound", (roomNumber, player2) =>
            {
                statusBox.Text = "Game Found, Starting in 5 seconds";
                OnGameFound(roomNumber);
            });

            connection.On<RoomModel>("UpdateGameRooms", (rooms) =>
            {
                roomList.Items.Clear();
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
                createGroup.Visible = true;
                roomList.Visible = true;
                joinGame.Visible = true;
                await connection.InvokeAsync("GetRooms");
            }
            catch (Exception ex)
            {
                statusBox.Text = $"Connection failed\n{ex}";
                throw;
            }
        }

        private async void OnGameFound(string roomNuber)
        {
            for (int i = 5; i >= 0; i--)
            {
                statusBox.Text = "Game starting in " + i;
                await Task.Delay(1000);
            }

            var gameForm = new Form1(roomNuber, isFirstPlayer, connection);
            gameForm.Show();
        }

        private async void createGroup_Click(object sender, EventArgs e)
        {
            isFirstPlayer = true;
            await connection.InvokeAsync("CreateRoom");
            statusBox.Text = $"Waiting for second player ()";
        }

        private async void joinGame_Click(object sender, EventArgs e)
        {
            isFirstPlayer = false;
            var room = (string)roomList.SelectedItem;
            await connection.InvokeAsync("JoinRoom", room);
        }
    }
}
