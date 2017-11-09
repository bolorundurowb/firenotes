using System;

using Xamarin.Forms;

namespace firenotes.Views
{
    public class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

