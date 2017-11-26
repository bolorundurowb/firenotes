using System;
using System.Linq;
using Firebase.Auth;
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

                stkContent.BackgroundColor = Color.FromHex("#FAFAFA");
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

            try
            {
                App.AuthLink = await App.AuthProvider.CreateUserWithEmailAndPasswordAsync(email, password, $"{firstName} {surname}", true);

                this.spnrLoading.IsVisible = false;
                this.btnSignUp.IsEnabled = true;

                // Navigate to the home page
                Navigation.InsertPageBefore(new HomePage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();

                // persist the user in storage
                await App.AuthDatabase.SaveUserAsync(new Models.User
                {
                    Firstname = App.AuthLink.User.FirstName,
                    Surname = App.AuthLink.User.LastName,
                    Email = email,
                    Password = password
                });
            }
            catch (FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    DisplayError("Sorry, the email address provided already exists. Please login.");
                }
                else if (ex.Reason == AuthErrorReason.WeakPassword)
                {
                    DisplayError("Sorry, the password provided is too weak.");
                }
                else if (ex.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    DisplayError("Sorry, the email address provided is invalid");
                }
                else
                {
                    DisplayError("Sorry, an error occurred. Please try again.");
                }

                this.spnrLoading.IsVisible = false;
                this.btnSignUp.IsEnabled = true;

            }
        }

        private void DisplayError(string message)
        {
            DisplayAlert("Error", message, "OK");
        }
    }
}
