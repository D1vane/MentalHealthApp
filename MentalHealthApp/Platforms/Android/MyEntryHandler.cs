
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Platform;

namespace MentalHealthApp.Platforms.Android
{
    public class MyEntryHandler:Microsoft.Maui.Handlers.EntryHandler
    {
        protected override void ConnectHandler(AppCompatEditText platformView)
        {
            platformView.Background = null;
            base.ConnectHandler(platformView);
        }
    }
}
