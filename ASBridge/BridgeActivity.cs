using Android;
using Android.Content;
using Android.Content.PM;

namespace ASBridge;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class BridgeActivity : Activity
{
    protected override void OnResume()
    {
        Finish();
        base.OnResume();
    }

    private int permcode = 100;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Notes.Init(); 
        Intent i = new(this, typeof(BridgeService));
        i.SetFlags(ActivityFlags.NewTask);
        StartForegroundService(i);
    }
}