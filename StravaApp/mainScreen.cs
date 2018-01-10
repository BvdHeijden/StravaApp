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

namespace StravaApp
{
    public partial class mainScreen : Form
    {
        public static string strava_Token;

        public mainScreen()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = stravaConnect.generate_Auth_url();
            webBrowser1.Navigate(stravaConnect.generate_Auth_url());

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.PathAndQuery.Contains("code="))
            {
                string code = webBrowser1.Url.Query.Substring(webBrowser1.Url.Query.IndexOf("code=") + 5);

                strava_Token = stravaConnect.token_Exchange(code);

                statusText.Text = strava_Token;
            }
        }
    }
}
