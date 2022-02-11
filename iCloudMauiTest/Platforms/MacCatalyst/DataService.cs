using CloudKit;
using Foundation;
using UIKit;

namespace iCloudMauiTest.Services;

public class DataService : IDataService
{
    public AppDelegate ThisApp => (AppDelegate)UIApplication.SharedApplication.Delegate;

    private void LogNsError(NSError error)
    {
        Console.WriteLine(error.DebugDescription);
    }

    public void CreateRecord()
    {
        const string ReferenceItemRecordName = "MyRecordName";
        string name = "This is a test!";

        // Create a new record
        var newRecord = new CKRecord(ReferenceItemRecordName);
        newRecord["name"] = (NSString)name;

        // Save it to the database
        ThisApp.PublicDatabase.SaveRecord(newRecord, (record, err) =>
        {
            // Was there an error?
            if (err != null)
            {
                LogNsError(err);
            }
            Console.WriteLine($"Created record '{record["name"]}'");
        });
    }

    public void GetRecord()
    {
        // Create a record ID and fetch the record from the database
        var recordID = new CKRecordID("MyRecordName");
        ThisApp.PublicDatabase.FetchRecord(recordID, (record, err) =>
        {
            // Was there an error?
            if (err != null)
            {
                LogNsError(err);
            }
            Console.WriteLine($"Fetched record '{record["name"]}'");
        });
    }

    public void UpdateRecord()
    {
        // Create a record ID and fetch the record from the database
        var recordID = new CKRecordID("MyRecordName");
        ThisApp.PublicDatabase.FetchRecord(recordID, (record, err) =>
        {
            // Was there an error?
            if (err != null)
            {
                LogNsError(err);
            }
            else
            {
                // Modify the record
                record["name"] = (NSString)"New Name";

                // Save changes to database
                ThisApp.PublicDatabase.SaveRecord(record, (r, e) =>
                {
                    // Was there an error?
                    if (e != null)
                    {
                        LogNsError(e);
                    }
                    Console.WriteLine($"Updated record '{record["name"]}'");
                });
            }
        });
    }

    public void DeleteRecord()
    {
        var recordID = new CKRecordID("MyRecordName");
        ThisApp.PublicDatabase.DeleteRecord(recordID, (recordId, err) =>
        {
            // Was there an error?
            if (err != null)
            {
                LogNsError(err);
            }
            Console.WriteLine($"Deleted record id '{recordId}'");
        });
    }
}
