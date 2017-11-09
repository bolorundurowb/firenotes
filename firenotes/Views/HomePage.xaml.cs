using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class HomePage : ContentPage
    {
        ObservableCollection<string> Items = new ObservableCollection<string>();

        public HomePage()
        {
            Items.Add("Number One");
            Items.Add("Number One");
            Items.Add("Number One");
            Items.Add("Number One");
            Items.Add("Number One");
            Items.Add("Number One");
            Items.Add("Number One");

            InitializeComponent();

            this.Title = "Your Notes";
        }

        protected async void AddNote(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNotePage());
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new NoteDetailsPage());
        }
    }
}
