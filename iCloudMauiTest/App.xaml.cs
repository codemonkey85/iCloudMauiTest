namespace iCloudMauiTest;

public partial class App : Application
{
    public App(IDataService dataService)
    {
        InitializeComponent();
        MainPage = new MainPage(dataService);
    }
}
