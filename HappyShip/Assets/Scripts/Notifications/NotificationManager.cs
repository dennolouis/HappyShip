using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#elif UNITY_IOS
using Unity.Notifications.iOS;
#endif

using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private int hours = 72; //3 days
    private int minutes;
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
        SendIOSNotification();
#elif UNITY_ANDROID
        SendAndroidNotification();
#endif
    }

#if UNITY_IOS
    void SendIOSNotification()
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(hours, minutes, seconds),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can specify a custom identifier which can be used to manage the notification later.
            // If you don't provide one, a unique string will be generated automatically.
            Identifier = "_notification_01",
            Title = "Happy Ship",
            Body = "",
            Subtitle = "Come Back!",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };

        //make sure the notification does display too much
        iOSNotificationCenter.RemoveScheduledNotification(notification.Identifier);

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#elif UNITY_ANDROID
    void SendAndroidNotification()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }

        //remove any notifications already displayed
        AndroidNotificationCenter.CancelAllDisplayedNotifications();



        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);


        var notification = new AndroidNotification();
        notification.Title = "Happy Ship";
        notification.Text = "Come Back!";
        notification.LargeIcon = "icon_0";
        notification.FireTime = System.DateTime.Now.AddDays(3);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        //reschedule notification
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

    }
#endif
}
