using System;
using firenotes.Models;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage(Note note)
        {
            InitializeComponent();

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
            
        }

        private async void UnFavouriteNote(object sender, EventArgs e)
        {
            
        }
    }
}
