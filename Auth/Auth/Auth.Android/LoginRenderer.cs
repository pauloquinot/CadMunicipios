using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Auth;
using Xamarin.Auth;
using Newtonsoft.Json;

[assembly: ExportRenderer(typeof(Login), typeof(Auth.Droid.LoginRenderer))]
namespace Auth.Droid
{
    public class LoginRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        public LoginRenderer()
        {
            var activity = this.Context as Activity;

            AccountStore store = AccountStore.Create();
            Account account = store.FindAccountsForService("Facebook").FirstOrDefault();

            var auth = new OAuth2Authenticator(
                        clientId: "755955534586868",
                        scope: "",
                        authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                        redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                User user = null;
                if (eventArgs.IsAuthenticated)
                {
                    var token = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"].ToString());
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);
                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = request.GetResponseAsync();
                    if (response != null)
                    {
                        // Deserialize the data and store it in the account store
                        // The users email address will be used to identify data in SimpleDB
                        string userJson = await response.Result.GetResponseTextAsync();
                        Console.WriteLine(userJson);
                        user = JsonConvert.DeserializeObject<User>(userJson);
                    }

                    AccountStore.Create(activity).Save(eventArgs.Account, "Facebook");
                    // Use eventArgs.Account to do wonderful things
                    await App.NavigateToProfile("Usuário conectado:" + user.Name + " Token Expira em:" + String.Format("{0:MM/dd/yyyy HH:mm:ss}", expiryDate));
                }
                else
                {
                    await App.NavigateToProfile("Usuário não conectado");
                }


            };

            activity.StartActivity(auth.GetUI(activity));



        }
    }
}