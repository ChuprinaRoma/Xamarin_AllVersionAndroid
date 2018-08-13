using Android.Content.Res;
using System;
using System.Threading.Tasks;
using Unity;
using VersionAndroid.Servise;
using VersionAndroid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace VersionAndroid
{
	public partial class App : Application
    {
        

        public App (string nameOC)
		{
			InitializeComponent();
            MainPage = new ListVersionDroid(nameOC);
        }

		protected override void OnStart ()
		{
        }

		protected override void OnSleep ()
		{
        }

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        

    }
}
