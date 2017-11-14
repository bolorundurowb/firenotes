using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace firenotes.Views
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsPage()
        {
            InitializeComponent();

            this.Title = "Note Details";

            this.lblTitle.Text = "Hello World";
            this.lblContent.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. In id egestas lacus. In accumsan leo eget velit rutrum sagittis. Integer nec pharetra ligula. Pellentesque mauris magna, porttitor nec ligula sed, fringilla iaculis urna. Quisque gravida faucibus lobortis. Cras scelerisque est sit amet justo fringilla, at ullamcorper arcu aliquam. Mauris pretium scelerisque eros in pulvinar. Cras vel ipsum convallis, commodo nisl in, dapibus libero.";
            this.lblCreated.Text = @"11/14/2017 10:23:28";
        }
    }
}
