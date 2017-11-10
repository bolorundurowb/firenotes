using Firebase.Auth;
using firenotes.Interfaces;
using firenotes.Views;
using Xamarin.Forms;

namespace firenotes
{
    public partial class App : Application
    {
        private static AuthDatabase _database;
        public static FirebaseAuthProvider AuthProvider;
        public static FirebaseAuthLink AuthLink;
        static AuthDatabase AuthDatabase
        {
            get
            {
                if (_database == null)
                {
                    _database = new AuthDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath(Constants.DbFileName));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            // customize the navbar
            var nav = new NavigationPage(new SignInPage());
            nav.BarBackgroundColor = Color.FromHex("#FF9800");

            if (Device.RuntimePlatform == Device.iOS)
            {
                nav.BarTextColor = Color.Black;
            }

            // set the signin page as the main page
            MainPage = nav;

            // set up auth
            AuthProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.ApiKey));
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
