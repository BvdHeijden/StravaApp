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
using Strava.Activities;
using System.Windows.Forms.DataVisualization.Charting;


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

            strava_Token = mainSettings.Default.strava_Token;

            if (strava_Token.Length > 0)
            {
                pictureBox1.Visible = false;
                finish_StravaConnection(strava_Token);
            }

            InitializeGoalData();
        }

        private void InitializeGoalData()
        {
            goalData.Columns.Add("maand", "maand");
            goalData.Columns.Add("kms", "kilometers");
            goalData.Rows.Add(12);
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
            getStravaMiles();
        }

        private void getStravaMiles()
        {
            float[,] stravaMiles = new float[12, 5];

            List<ActivitySummary> activities = new List<ActivitySummary>();

            try
            {
                activities = client.Activities.GetActivities(new DateTime(2011, 1, 1), DateTime.Now);

            }
            catch (Exception e)
            {
            }

            foreach(var ride in activities)
            {
                if (ride.Type == ActivityType.Ride)
                {
                    int month = Int32.Parse(Convert.ToDateTime(ride.StartDate).ToString("MM"));
                    int year = Int32.Parse(Convert.ToDateTime(ride.StartDate).ToString("yyyy"));

                    stravaMiles[month-1, year - 2015] += ride.Distance/1000;
                }
            }

            for(int y = 0; y <= 4; y++)
            {
                for(int m = 1; m <= 11; m++)
                {
                    stravaMiles[m, y] += stravaMiles[m - 1, y];
                }
            }

            makeChart(stravaMiles);
        }

        private void makeChart(float[,] stravaMiles)
        {
            for(int y = 2015; y <= 2018; y++)
            {
                chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, 1, 1), 0);
                for (int m = 1; m <= 11; m++)
                {
                    chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, m + 1, 1), stravaMiles[m - 1, y - 2015]);
                }
                chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, 12, 31), stravaMiles[11, y - 2015]);

            }
        }
    }
}
