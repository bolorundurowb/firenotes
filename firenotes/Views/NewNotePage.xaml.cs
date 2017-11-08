using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NewNotePage : ContentPage
    {
        public NewNotePage()
        {
            InitializeComponent();
            this.Title = "New Note";

            if (Device.RuntimePlatform == Device.iOS)
            {
                btnSave.TextColor = Color.FromHex("#FF9800");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                btnSave.BackgroundColor = Color.FromHex("#FF9800");
                btnSave.TextColor = Color.White;
            }
        }

        protected async void Save(object sender, EventArgs e)
        {
            this.txtTitle.Text = null;
            this.txtDetails.Text = null;

            await Navigation.PopAsync();
        }
    }
}
