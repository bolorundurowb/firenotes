using System;
//using System.Threading.Tasks;
//using Firebase.Auth;
//using Firebase.Database;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
            this.Title = "Sign In";
            lblsignUp.GestureRecognizers.Add(new TapGestureRecognizer((view) => GoToSignUp()));

            if (Device.RuntimePlatform == Device.iOS)
            {
                btnSignIn.TextColor = Color.FromHex("#FF9800");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                btnSignIn.BackgroundColor = Color.FromHex("#FF9800");
                btnSignIn.TextColor = Color.White;
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                DisplayError("Sorry, the email field cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                DisplayError("Sorry, the password field cannot be empty.");
                return;
            }

            this.spnrLoading.IsVisible = true;
            this.btnSignIn.IsEnabled = false;

            //App.AuthLink = App.AuthProvider.SignInWithEmailAndPasswordAsync(email, password);
            //var firebase = new FirebaseClient(App.FirebaseUrl, new FirebaseOptions()
            //{
            //    AuthTokenAsyncFactory = () => new Task<string>(() => App.AuthLink.Result.FirebaseToken)
            //});

            //var dinos = firebase.Child("users").OnceAsync<object>();

            //this.spnrLoading.IsVisible = false;
            //this.btnSignIn.IsEnabled = true;

        }

        protected void GoToSignUp()
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void DisplayError(string message)
        {
            DisplayAlert("Error", message, "OK");
        }
    }
}
