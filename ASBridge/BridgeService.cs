using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Net;
using Android.Util;

using Uri = Android.Net.Uri;
using Android.Graphics;
using Android;

namespace ASBridge;

[Service(Enabled = true, DirectBootAware = true)]
public class BridgeService : Service
{
    private (int, Notification?) ForegroundNoteInstance { get; set; }

    public override void OnCreate()
    {
        ForegroundNoteInstance = Notes.CreateNote(GetString(Resource.String.app_notification_main_title),
                              GetString(Resource.String.app_notification_main_desc),
                              null, -1, true);
        StartForeground(ForegroundNoteInstance.Item1, ForegroundNoteInstance.Item2);
        base.OnCreate();
    }

    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        StartForeground(ForegroundNoteInstance.Item1, ForegroundNoteInstance.Item2);
        Notes.PushNote(ForegroundNoteInstance.Item1, ForegroundNoteInstance.Item2);
        return StartCommandResult.Sticky;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Notes.DestroyNotes();
    }
}