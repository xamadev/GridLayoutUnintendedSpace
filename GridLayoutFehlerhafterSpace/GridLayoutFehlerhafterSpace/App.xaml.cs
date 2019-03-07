using System;
using C4S.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GridLayoutFehlerhafterSpace.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GridLayoutFehlerhafterSpace
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();

            var p = MainPage as MasterDetailPage;

            p.Detail = new KontaktePage(new KontakteGroupViewModel());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
