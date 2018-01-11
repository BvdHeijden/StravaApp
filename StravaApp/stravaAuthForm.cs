using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StravaApp
{
    public partial class stravaAuthForm : Form
    {
        public stravaAuthForm()
        {
            InitializeComponent();

            webBrowser1.Navigate(stravaConnect.generate_Auth_url());

        }

        public string get_Strava_Token()
        {
            return "";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.PathAndQuery.Contains("code="))
            {
                string code = webBrowser1.Url.Query.Substring(webBrowser1.Url.Query.IndexOf("code=") + 5);

                mainScreen.strava_Token = stravaConnect.token_Exchange(code);
                
                this.Close();
            }

        }

    }
}
