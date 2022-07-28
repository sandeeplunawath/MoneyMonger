using MM.Clients;
using model = MM.Repository.Model;
namespace MauiProject.Customer;

public partial class CustomerViewPage : ContentPage
{
    public CustomerViewPage()
    {
        InitializeComponent();
    }

    private async void OnLoadButtonClicked(object sender, EventArgs e)
    {
        ApiClient apiClient = new ApiClient();
        List<model.Customer> result = await apiClient.CustomerClient.SelectAllCustomers();

        Grid grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };

        for (int i = 0; i < result.Count; i++)
        {


            grid.RowDefinitions.Add(new RowDefinition());
            grid.Add(new Label
            {
                //TextDecorations = TextDecorations.Underline,
                Text = result[i].FirstName,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            }, 0, i);
            grid.Add(new Label
            {
                Text = result[i].LastName,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            }, 1, i);
            grid.Add(new Label
            {

                Text = result[i].AadharNumber,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            }, 2, i);

            Stream stream = null;
            if (result[i].CustomerImage != null) stream = new MemoryStream(result[i].CustomerImage);

            grid.Add(new Image
            {
                HeightRequest = 30,
                Source = ImageSource.FromStream(() => stream)
            }, 3, i);

            Button button = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = result[i].Id.ToString()
            };
            button.Clicked += async (sender, args) => OnGridEditButtonClicked(sender, args);
            grid.Add(button, 4, i);

        }
        customerDetailsGrid.Clear();
        customerDetailsGrid.Add(grid);
    }

    private void OnGridEditButtonClicked(object sender, EventArgs e)
    {
        string st = ((Element)sender).AutomationId;
        Navigation.PushAsync(new CustomerPage(Convert.ToInt32(((Element)sender).AutomationId)));
        
    }

}