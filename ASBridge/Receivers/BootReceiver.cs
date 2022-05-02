using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASBridge.Receivers;

[BroadcastReceiver(Enabled = true, Exported = true)]
[IntentFilter(new[] { Intent.ActionBootCompleted, Intent.ActionLockedBootCompleted, "android.intent.action.QUICKBOOT_POWERON" })]
public class BootReceiver : BroadcastReceiver
{
    public override void OnReceive(Context? context, Intent? intent)
    {
        if (context is not null && intent is not null)
        {
            if (Intent.ActionBootCompleted == intent.Action)
            {
                Intent i = new(context, typeof(BridgeActivity));
                i.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(i);
            }
        }
    }
}
