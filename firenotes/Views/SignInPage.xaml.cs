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
            lblsignUp.GestureRecognizers.Add(new TapGestureRecognizer((view) => GoToSignUp()));
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
