using System;
using Firebase.Database;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NewNotePage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient(Constants.FirebaseUrl + "notes",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = async () => App.AuthLink.FirebaseToken
            });
        
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

                stkContent.BackgroundColor = Color.FromHex("#FAFAFA");
                frmEditor.BackgroundColor = Color.FromHex("#FAFAFA");
                txtDetails.BackgroundColor = Color.FromHex("#FAFAFA");
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
