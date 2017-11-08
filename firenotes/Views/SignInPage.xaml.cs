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

        protected async void SignIn(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            //if (string.IsNullOrWhiteSpace(email))
            //{
            //    DisplayError("Sorry, the email field cannot be empty.");
            //    return;
            //}

            //if (string.IsNullOrEmpty(password))
            //{
            //    DisplayError("Sorry, the password field cannot be empty.");
            //    return;
            //}

            this.spnrLoading.IsVisible = true;
            this.btnSignIn.IsEnabled = false;

            // Navigate to the home page
            Navigation.InsertPageBefore(new HomePage(), this);
            await Navigation.PopAsync();
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
