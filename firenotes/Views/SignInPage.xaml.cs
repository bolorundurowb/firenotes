using System;
using System.Collections.Generic;

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

        }

        protected void GoToSignUp()
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}
