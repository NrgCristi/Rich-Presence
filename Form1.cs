using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace Rich_Presence
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public DiscordRpcClient client;
		bool initialized = false;

		private void button1_Click(object sender, EventArgs e)
		{

			if (initialized == false)
			{
				MessageBox.Show("You need to initialize app first!");
			}
			else
			{
				client.SetPresence(new DiscordRPC.RichPresence()
				{
					Details = $"{textBox2.Text}",
					State = $"{textBox1.Text}",
					Timestamps = Timestamps.Now,
					Assets = new Assets()
					{
						LargeImageKey = $"{textBox4.Text}",
						LargeImageText = "Fortnite",
						SmallImageKey = $"{textBox5.Text}"
					}
				});
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			initialized = true;
			client = new DiscordRpcClient($"{textBox3.Text}");
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
			client.Initialize();

		}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
