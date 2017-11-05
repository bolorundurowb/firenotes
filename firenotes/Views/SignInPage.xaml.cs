using System;
using System.Collections.Generic;
using Firebase.Auth;
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

            try
            {
                App.authLink = App.authProvider.SignInWithEmailAndPasswordAsync(email, password);

                this.spnrLoading.IsVisible = false;
                this.btnSignIn.IsEnabled = true;
            }
            catch (FirebaseAuthException e)
            {

            }
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
