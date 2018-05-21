using Xamarin.Forms;
using DepartureTime.Classes;
using DepartureTime.ViewModels;
using DepartureTime.Interfaces;

namespace DepartureTime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			IDataProvider data = new DataProvider();

            MainPage = new DepartureTimePage(new DepartureTimeVM(data));
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
