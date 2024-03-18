using Android.App;
using Android.Runtime;

namespace HappyHoursMobile
{
#if DEBUG // TODO: This if is planned to be removed.
    [Application(UsesCleartextTraffic = true)]
#endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
