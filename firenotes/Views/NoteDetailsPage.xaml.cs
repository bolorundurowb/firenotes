using System;
using Firebase.Database;
using Firebase.Database.Query;
using firenotes.Models;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        private Note _note;
        private static string nodeUrl = $"{Constants.FirebaseUrl}users/{App.AuthLink.User.LocalId}";
        FirebaseClient firebaseClient = new FirebaseClient(
            nodeUrl,
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = async () => App.AuthLink.FirebaseToken
            });

        public NoteDetailsPage(Note note)
        {
            InitializeComponent();

            // set the note being viewed
            this._note = note;

            // set the page title
            this.Title = "Note Details";

            // set the stack layout background color to create a seamleass look
            if (Device.RuntimePlatform == Device.Android)
            {
                stkContent.BackgroundColor = Color.FromHex("#FAFAFA");
            }

            // set the display data
            this.lblTitle.Text = note.Title;
            this.lblContent.Text = note.Details;
            this.lblCreated.Text = note.Created.ToString("dd/MM/yyy HH:mm:ss");

            // enable and disable buttons as required
            if (note.IsFavorite)
            {
                tlbFavourite.IsVisible = false;
                tlbUnfavorite.IsVisible = true;
            }
            else
            {
                tlbFavourite.IsVisible = true;
                tlbUnfavorite.IsVisible = false;
            }
        }

        private async void FavouriteNote(object sender, EventArgs e)
        {
            // set the favourited state
            _note.IsFavorite = true;
            _note.Updated = DateTime.Now;

            await firebaseClient
                .Child("notes")
                .Child(_note.Id)
                .PutAsync(_note);

            // hide the favorite button and show the unfavorite toolbar item
            tlbFavourite.IsVisible = false;
            tlbUnfavorite.IsVisible = true;
        }

        private async void UnFavouriteNote(object sender, EventArgs e)
        {
            // set the favourited state
            _note.IsFavorite = false;
            _note.Updated = DateTime.Now;

            await firebaseClient
                .Child("notes")
                .Child(_note.Id)
                .PutAsync(_note);

            // hide the favorite button and show the unfavorite toolbar item
            tlbFavourite.IsVisible = true;
            tlbUnfavorite.IsVisible = false;
        }
    }
}
