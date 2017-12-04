using System;
using System.Collections.ObjectModel;
using firenotes.Models;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class HomePage : ContentPage
    {
        ObservableCollection<Note> Items = new ObservableCollection<Note>();

        public HomePage()
        {
            InitializeComponent();

            this.Title = "Your Notes";

            if (Device.RuntimePlatform == Device.Android)
            {
                absContent.BackgroundColor = Color.FromHex("#FAFAFA");
            }
        }

        protected async void AddNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNotePage());
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new NoteDetailsPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.lstNotes.ItemsSource = Items;
        }
    }
}
