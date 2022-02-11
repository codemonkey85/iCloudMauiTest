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

    private void LogException(Exception ex)
    {
        Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
    }

    public void CreateRecord()
    {
        try
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
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    public void GetRecord()
    {
        try
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
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    public void UpdateRecord()
    {
        try
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
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    public void DeleteRecord()
    {
        try
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
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
}
