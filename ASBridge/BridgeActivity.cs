using Android;
using Android.Content;
using Android.Content.PM;
using ASBridge.Receivers;

namespace ASBridge;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class BridgeActivity : Activity
{
    protected override void OnResume()
    {
        Finish();
        base.OnResume();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Notes.Init();
        Intent i = new(this, typeof(BridgeService));
        i.SetFlags(ActivityFlags.NewTask);
        StartForegroundService(i);
    }
}