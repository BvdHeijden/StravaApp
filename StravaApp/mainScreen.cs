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
            goalControl.Value = mainSettings.Default.yearGoal;

            if (strava_Token.Length > 0)
            {
                pictureBox1.Visible = false;
                finish_StravaConnection(strava_Token);
                //getStravaMiles();
                makeChartDetailed();
            }

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
            //finish_StravaConnection(strava_Token);
            //getStravaMiles();
            makeChartDetailed();
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
            //makeChartDetailed();
        }

        private void makeChart(float[,] stravaMiles)
        {
            for(int y = 2015; y <= 2018; y++)
            {
                chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, 1, 1), 0);
                for (int m = 1; m <= 11; m++)
                {
                    chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, m + 1, 1), stravaMiles[m - 1, y - 2015]);

                    if (stravaMiles[11, y - 2015] == stravaMiles[m - 1, y - 2015]) { break; }
                    
                }
                chart1.Series[y.ToString()].Points.AddXY(new DateTime(2000, 12, 31), stravaMiles[11, y - 2015]);

            }
        }

        private void makeChartDetailed()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            for(int year = 2015; year <= DateTime.Now.Year; year++)
            {
                try
                {
                    activities = client.Activities.GetActivities(new DateTime(year, 1, 1), new DateTime(year, 12, 31));
                }
                catch(Exception e) { }

                float totaldist = 0;

                foreach(var activity in activities)
                {
                    if (activity.Type == ActivityType.Ride)
                    {
                        totaldist += activity.Distance / 1000;
                        chart1.Series[year.ToString()].Points.AddXY(activity.DateTimeStartLocal, totaldist);
                    }
                }
            }
        }

        private void goalControl_ValueChanged(object sender, EventArgs e)
        {
            mainSettings.Default.yearGoal = (int)goalControl.Value;
            mainSettings.Default.Save();

            //updateChartGoal();
        }

        private void updateChartGoal()
        {

            chart1.Series["2018 Goal"].Points.Clear();

            chart1.Series["2018 Goal"].Points.AddXY(new DateTime(2000, 1, 1), 0);

            for (int a = 0; a <= 10; a++)
            {
                chart1.Series["2018 Goal"].Points.AddXY(new DateTime(2000, a + 2, 1),(float)goalControl.Value * (a + 1) / 12);
            }

            chart1.Series["2018 Goal"].Points.AddXY(new DateTime(2000, 12, 31), (float)goalControl.Value);
        }
    }
}
