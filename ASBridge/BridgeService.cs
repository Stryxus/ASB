using Android.Content;
using Android.OS;
using Android.Net;
using Android.Util;

using Uri = Android.Net.Uri;
using Android.Graphics;

namespace ASBridge;

[Service]
public class BridgeService : Service
{
    int messageId = 0;
    int pendingIntentId = 0;
    NotificationManager manager;

    public override void OnCreate()
    {
        base.OnCreate();
    }

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        if (manager == null)
        {
            manager = (NotificationManager)GetSystemService(NotificationService);
            var channelNameJava = new Java.Lang.String("ASBridge");
            var channel = new NotificationChannel("543435345", channelNameJava, NotificationImportance.Default)
            {
                Description = "Main"
            };
            manager.CreateNotificationChannel(channel);
        }

        Intent intentSecond = new(this, typeof(BridgeActivity));
        intentSecond.PutExtra("tKey", "ASBridge");
        intentSecond.PutExtra("mkey", "ITS WORKING!!!");

        PendingIntent pendingIntent = PendingIntent.GetActivity(this, pendingIntentId++, intentSecond, PendingIntentFlags.UpdateCurrent);

        Notification.Builder builder = new Notification.Builder(this, "543435345")
            .SetContentIntent(pendingIntent)
            .SetContentTitle("ASBridge")
            .SetContentText("ITS WORKING!!!")
            .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Mipmap.ic_launcher))
            .SetSmallIcon(Resource.Mipmap.ic_launcher)
            .SetOngoing(true)
            .SetAutoCancel(false);

        Notification notification = builder.Build();
        manager.Notify(messageId++, notification);
        return StartCommandResult.Sticky;
    }

    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }
}