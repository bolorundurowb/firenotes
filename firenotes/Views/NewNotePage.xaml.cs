using System;
using System.Collections.Generic;
using firenotes.Models;
using Firebase.Database;
using Firebase.Database.Offline;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NewNotePage : ContentPage
    {
        private static string nodeUrl = Constants.FirebaseUrl + "users/" + App.AuthLink.User.FederatedId;

        FirebaseClient firebaseClient = new FirebaseClient(
            nodeUrl,
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = async () => App.AuthLink.FirebaseToken
            });

        public NewNotePage()
        {
            InitializeComponent();
            Title = "New Note";

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
            var notesDb = firebaseClient.Child("notes").AsRealtimeDatabase<Note>();
            
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                DisplayError("Sorry, the title field is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDetails.Text))
            {
                bool response = await DisplayAlert("Warning",
                    "You have not filled in anything in the note details field. Do you want to proceed with saving this note?",
                    "Yes", "No");

                if (!response)
                {
                    return;
                }

                spnrLoading.IsVisible = true;

                notesDb
                .Post(new Note
                {
                    Title = txtTitle.Text,
                    Details = txtDetails.Text,
                    IsFavorite = false,
                    Tags = new List<string>()
                });

                txtTitle.Text = null;
                txtDetails.Text = null;
                spnrLoading.IsVisible = false;
            }

        }

        private void DisplayError(string message)
        {
            DisplayAlert("Error", message, "OK");
        }
    }
}
