namespace MauiProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnItemPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Item.ItemPage());
        }
        private void OnCustomerPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Customer.CustomerPage());
        }
         private void OnCustomerViewPageClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Customer.CustomerViewPage());
        }

    }
}