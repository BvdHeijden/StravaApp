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

                statusText.Text = "Hello " + athlete.FirstName;
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            makeChartDetailed();
        }

        private async void makeChartDetailed()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            for(int year = 2015; year <= DateTime.Now.Year; year++)
            {
                Series newLine = new Series();
                newLine.ChartType = SeriesChartType.Line;
                newLine.BorderWidth = 3;
                newLine.Name = year.ToString();

                chart1.Series.Add(newLine);
                chart1.Series[year.ToString()].Points.AddXY(0, 0);
                float yeardist = 0;

                try{activities = await client.Activities.GetActivitiesAsync(new DateTime(year, 1, 1), new DateTime(year + 1, 1, 1));} catch(Exception e) { MessageBox.Show(e.Message); }

                activities.Reverse();

                foreach(var ride in activities)
                {
                    if (ride.Type == ActivityType.Ride)
                    {
                        yeardist += ride.Distance / 1000;
                        int date = Convert.ToDateTime(ride.StartDate).DayOfYear;
                        chart1.Series[year.ToString()].Points.AddXY(date, yeardist);
                        this.Refresh();
                    }
                }

                if (year == DateTime.Now.Year)
                {
                    chart1.Series[year.ToString()].Points.AddXY(DateTime.Now.DayOfYear, yeardist);
                }
                else
                {
                    chart1.Series[year.ToString()].Points.AddXY(366, yeardist);
                }
                
            }
        }

        private void goalControl_ValueChanged(object sender, EventArgs e)
        {
            mainSettings.Default.yearGoal = (int)goalControl.Value;
            mainSettings.Default.Save();

        }

    }
}
