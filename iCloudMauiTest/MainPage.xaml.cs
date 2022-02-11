namespace iCloudMauiTest;

public partial class MainPage : ContentPage
{
    int count = 0;

    private IDataService DataService { get; set; }

    public MainPage(IDataService dataService)
    {
        InitializeComponent();
        DataService = dataService;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";
        SemanticScreenReader.Announce(CounterLabel.Text);
    }

    private void HandleNotImplementedException(NotImplementedException ex)
    {
        InfoLabel.Text = ex.Message;
    }

    private void OnCreateRecordClicked(object sender, EventArgs e)
    {
        try
        {
            DataService.GetRecord();
        }
        catch (NotImplementedException ex)
        {
            HandleNotImplementedException(ex);
        }
    }

    private void OnGetRecordClicked(object sender, EventArgs e)
    {
        try
        {
            DataService.GetRecord();
        }
        catch (NotImplementedException ex)
        {
            HandleNotImplementedException(ex);
        }
    }

    private void OnUpdateRecordClicked(object sender, EventArgs e)
    {
        try
        {
            DataService.UpdateRecord();
        }
        catch (NotImplementedException ex)
        {
            HandleNotImplementedException(ex);
        }
    }

    private void OnDeleteRecordClicked(object sender, EventArgs e)
    {
        try
        {
            DataService.DeleteRecord();
        }
        catch (NotImplementedException ex)
        {
            HandleNotImplementedException(ex);
        }
    }
}
