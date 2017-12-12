using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;
using firenotes.Models;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class HomePage : ContentPage
    {
        private static string nodeUrl = $"{Constants.FirebaseUrl}users/{App.AuthLink.User.LocalId}";
        ObservableCollection<Note> Items = new ObservableCollection<Note>();

        FirebaseClient firebaseClient = new FirebaseClient(
            nodeUrl,
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = async () => App.AuthLink.FirebaseToken
            });

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
            await Navigation.PushAsync(new NoteDetailsPage((Note)e.Item));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // clear existing data
            this.Items.Clear();

            // disable list till data is loaded
            this.lstNotes.IsEnabled = false;
            this.spnrLoading.IsVisible = true;

            var notes = firebaseClient
                .Child("notes")
                .OnceAsync<Note>().Result;

            foreach (var note in notes)
            {
                Items.Add(note.Object);
            }

            this.lstNotes.ItemsSource = Items;

            // enable list and hide loading
            this.lstNotes.IsEnabled = true;
            this.spnrLoading.IsVisible = false;
        }
    }
}
