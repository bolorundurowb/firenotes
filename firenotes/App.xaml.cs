using firenotes.Views;
using Xamarin.Forms;

namespace firenotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var nav = new NavigationPage(new SignInPage());
            nav.BarBackgroundColor = Color.FromHex("#FF9800");

            if (Device.RuntimePlatform == Device.iOS)
            {
                nav.BarTextColor = Color.Black;
            }

            MainPage = nav;
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
