using CPointSoftware.Equihira.Extensibility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_Extension1
{
    public partial class SamplePage : System.Web.UI.Page
    {
        internal class UserInfo
        {
            public Guid Guid { get; set; }
            public string Nom { get; set; }
            public string Login { get; set; }
            public string LoginAndName { get; set; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {


            // Collez ici la version XML de la clef 
            // privée de votre instance de simplement-e.
            string serverKey = "";


            // et ici le nom et la clef de sécurisation 
            // de votre application tels que défini dans 
            // les applications connecté de votre solution
            string localKey = "";
            string appid = "";


            ServerExtensibilityIdentity id;
            id = ServerExtensibilityHelper.ParseSignature(Context, serverKey, localKey);

            // nous allons faire un simple appel au
            // service d'identité pour obtenir l'email
            // associé au uxid passé en paramètre
            if (id != null)
            {
                string serviceBaseUrl = "http://ci-app.simplement-e.com";
                string serviceUrl = "/tools/system/security.ashx";

                StringBuilder blr = new StringBuilder();
                blr.Append(serviceUrl);
                blr.Append("?action=me");

                blr.Append("&$format=json&$appid=");
                blr.Append(appid);
                blr.Append("&$signature=");
                string s = ServerExtensibilityHelper.ComputeSignatureForServerCall(serverKey, localKey,
                    serviceUrl,
                    id.Uxid, id.RjsId);
                blr.Append(HttpUtility.UrlEncode(s));

                WebClient cli = new WebClient();
                cli.BaseAddress = serviceBaseUrl;

                string z = cli.DownloadString(blr.ToString());
                var user = JsonConvert.DeserializeObject<UserInfo>(z);
                lblNomUtilisateur.Text = user.Login;
            }
        }
    }
}