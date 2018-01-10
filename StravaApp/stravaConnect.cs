using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaApp
{
    class stravaConnect
    {
        internal static string generate_Auth_url()
        {

            string client_id = "14016";
            string response_tyoe = "code";
            string redirect_uri = "localhost";
            string scope = "view_private";
            string state = "intitial";
            string approval_prompt = "auto";

            string auth_URL = "https://www.strava.com/oauth/authorize?client_id=" + client_id + "&&response_type=" + response_tyoe + "&&redirect_uri=" + redirect_uri + "&&scope=" + scope + "&&state=" + state + "&&approval_prompt=" + approval_prompt;

            return auth_URL;
        }
    }
}
