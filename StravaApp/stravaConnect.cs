using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace StravaApp
{
    class stravaConnect
    {
        static string client_id = "14016";
        static string client_secret = "a1a6de6b21ea0792a4b1b2a1939aa2c95acc1c27";

        internal static string generate_Auth_url()
        {

            string response_tyoe = "code";
            string redirect_uri = "http://localhost";
            string scope = "view_private";
            string state = "intitial";
            string approval_prompt = "auto";

            string auth_URL = "https://www.strava.com/oauth/authorize?client_id=" + client_id + "&response_type=" + response_tyoe + "&redirect_uri=" + redirect_uri + "&scope=" + scope + "&state=" + state + "&approval_prompt=" + approval_prompt;

            return auth_URL;
        }

        internal static string token_Exchange(string code)
        {
            string strava_Token = "";
            System.Text.ASCIIEncoding aSCIIEncoding = new System.Text.ASCIIEncoding();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.strava.com/oauth/token");
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 5000;

            // build the url encoded form post data
            string postData = string.Format("client_id={0}&client_secret={1}&code={2}", client_id, client_secret, code);
            byte[] bytes = aSCIIEncoding.GetBytes(postData);

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)bytes.Length;
            System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
                if (responseStream != null)
                {
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
                    string text = streamReader.ReadToEnd();

                    int start = text.IndexOf("access_token") + 15;
                    int end = text.IndexOf("token_type")-3;

                    strava_Token=text.Substring(start, end - start);

                }
            }

            return strava_Token;
        }
    }
}
