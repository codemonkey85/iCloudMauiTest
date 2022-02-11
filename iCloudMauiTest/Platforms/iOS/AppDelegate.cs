using CloudKit;
using Foundation;
using UIKit;

namespace iCloudMauiTest;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public CKDatabase PublicDatabase { get; set; }

    public CKDatabase PrivateDatabase { get; set; }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        application.RegisterForRemoteNotifications();

        // Get the default public and private databases for
        // the application
        PublicDatabase = CKContainer.DefaultContainer.PublicCloudDatabase;
        PrivateDatabase = CKContainer.DefaultContainer.PrivateCloudDatabase;

        return true;
    }

    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
    {
        Console.WriteLine($"Registered for Push notifications with token: {deviceToken}");
    }

    public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
    {
        Console.WriteLine("Push subscription failed");
    }

    public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
    {
        Console.WriteLine("Push received");
    }
}
