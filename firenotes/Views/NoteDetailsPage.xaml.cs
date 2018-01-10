using System;
using System.Collections.Generic;
using firenotes.Models;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage(Note note)
        {
            InitializeComponent();

            this.Title = "Note Details";

            if (Device.RuntimePlatform == Device.Android)
            {
                stkContent.BackgroundColor = Color.FromHex("#FAFAFA");
            }

            this.lblTitle.Text = note.Title;
            this.lblContent.Text = note.Details;
            this.lblCreated.Text = note.Created.ToString("dd/MM/yyy HH:mm:ss");

            if (note.IsFavorite)
            {
                tlbFavorite.Icon = "ic_unfavorite.png";
            }
        }

        private async void FavoriteNote(object sender, EventArgs e)
        {
            
        }

        private async void UnFavoriteNote(object sender, EventArgs e)
        {
            
        }
    }
}
