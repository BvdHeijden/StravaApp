using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Strava;
using System.Net;
using Strava.Authentication;
using Strava.Clients;
using Strava.Athletes;

namespace StravaApp
{
    public partial class mainScreen : Form
    {
        public static string strava_Token="";
        public static StaticAuthentication auth;
        public static StravaClient client;

        public mainScreen()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            stravaAuthForm authform = new stravaAuthForm();
            authform.Show();
        }

        private async void finish_StravaConnection(string token)
        {
            if (strava_Token.Length != 0)
            {
                auth = new StaticAuthentication(token);
                client = new StravaClient(auth);
                Athlete athlete = await client.Athletes.GetAthleteAsync();

                statusText.Text = "Hello " + athlete.FirstName + "!";
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            finish_StravaConnection(strava_Token);
        }
    }
}
