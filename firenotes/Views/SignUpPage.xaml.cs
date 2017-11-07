using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.Title = "Sign Up";

            if (Device.RuntimePlatform == Device.iOS)
            {
                btnSignUp.TextColor = Color.FromHex("#FF9800");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                btnSignUp.BackgroundColor = Color.FromHex("#FF9800");
                btnSignUp.TextColor = Color.White;
            }
        }

        protected async void SignUp(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

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

            if (password.Length < 6)
            {
                DisplayError("Sorry, the password cannot be less than 6 characters.");
                return;
            }

            if (password != confirmPassword)
            {
                DisplayError("Sorry, the passwords must match.");
                return;
            }

            this.spnrLoading.IsVisible = true;
            this.btnSignUp.IsEnabled = false;

            // Navigate to the home page
            Navigation.InsertPageBefore(new HomePage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private void DisplayError(string message)
        {
            DisplayAlert("Error", message, "OK");
        }
    }
}
