using Android.Content;

namespace ASBridge;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class BridgeActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        StartService(new Intent(this, typeof(BridgeService)));
    }
}