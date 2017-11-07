using System.Threading.Tasks;
//using Firebase.Auth;
using firenotes.Views;
using Xamarin.Forms;

namespace firenotes
{
    public partial class App : Application
    {
        private const string apiKey = "";
        public static string FirebaseUrl => "https://androfirenotes.firebaseio.com/";

        //public static FirebaseAuthProvider AuthProvider;
        //public static Task<FirebaseAuthLink> AuthLink;

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
            //AuthProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
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
