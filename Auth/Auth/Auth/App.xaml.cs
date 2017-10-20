using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Auth
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        //Chamado a partir do LoginRenderer para indicar se teve sucesso ou nao
        public async static Task NavigateToProfile(string message)
        {
            //Chama a tela Profile.cs
            await App.Current.MainPage.Navigation.PushAsync(new Profile(message));
        }

        //remove a tela de login
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
