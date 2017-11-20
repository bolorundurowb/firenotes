using Android.App;
using Android.Widget;
using firenotes.Droid;
using firenotes.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
namespace firenotes.Droid
{
    public class Message : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}