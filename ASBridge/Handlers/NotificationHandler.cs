using Android.Graphics;
using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;

namespace ASBridge;

public static class Notes
{
    private static int notifyID = 1;
    private static int pendingIntentID = 0;
    private static NotificationManager? notifMan;

    public static void Init()
    {
        notifMan = (NotificationManager?)Application.Context.GetSystemService(Context.NotificationService);
        notifMan?.CreateNotificationChannel(new(Application.Context.Resources?.GetString(Resource.String.app_notification_channel_id), new Java.Lang.String("ASBridge"), NotificationImportance.Max)
        {
            LightColor = Color.Black,
            LockscreenVisibility = NotificationVisibility.Secret
        });
    }

    public static (int, Notification) CreateNote(string title, string desc, Bitmap? largeIcon, int smallIcon, bool isOngoing)
    {
        Notification.Builder builder = new(Application.Context, Application.Context.Resources?.GetString(Resource.String.app_notification_channel_id));
        builder.SetContentIntent(PendingIntent.GetActivity(Application.Context, pendingIntentID++, new(Application.Context, typeof(BridgeActivity)), 0));
        builder.SetContentTitle(title);
        builder.SetContentText(desc);
        builder.SetSmallIcon(smallIcon < 0 ? Resource.Mipmap.ic_launcher : smallIcon);
        builder.SetLargeIcon(largeIcon is null ? BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Mipmap.ic_launcher) : largeIcon);
        if (isOngoing) builder.SetOngoing(true);
        return (notifyID, builder.Build());
    }

    public static void PushNote(int id, Notification? not) => notifMan?.Notify(id, not);

    public static void PushLooseNote(string title, string desc, Bitmap? largeIcon, int smallIcon, bool isOngoing)
    {
        notifMan?.Notify(notifyID++, new Notification.Builder(Application.Context, Application.Context.Resources?.GetString(Resource.String.app_notification_channel_id))
            .SetContentIntent(PendingIntent.GetActivity(Application.Context, pendingIntentID++, new(Application.Context, typeof(BridgeActivity)), PendingIntentFlags.UpdateCurrent))
            .SetContentTitle(title)
            .SetContentText(desc)
            .SetSmallIcon(smallIcon < 0 ? Resource.Mipmap.ic_launcher : smallIcon)
            .SetLargeIcon(largeIcon is null ? BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Mipmap.ic_launcher) : largeIcon)
            .SetOngoing(isOngoing)
            .Build());
    }

    public static void DestroyNotes() => notifMan?.DeleteNotificationChannel(Application.Context.Resources?.GetString(Resource.String.app_notification_channel_id));
}
