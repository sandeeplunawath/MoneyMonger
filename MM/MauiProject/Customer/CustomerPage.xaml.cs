namespace MauiProject.Customer;

using MM.Clients;
using MM.Repository;
using model = MM.Repository.Model;
public partial class CustomerPage : ContentPage
{
    int id = 0;
    public CustomerPage()
    {
        InitializeComponent();
    }
    public CustomerPage(int customerID)
    {
        buttonClicked(customerID);
        InitializeComponent();
    }

    private async Task buttonClicked(int customerID)
    {
        ApiClient apiClient = new ApiClient();
        model.Customer customer = await apiClient.CustomerClient.SelectCustomerById(customerID);
        firstNameEntry.Text = customer.FirstName;
        lastNameEntry.Text = customer.LastName;
        FatherOrHusbandNameEntry.Text = customer.FatherOrHusbandName;
        NationalityOrReligionEntry.Text = customer.NationalityOrReligion;
        phoneNumberEntry.Text = customer.PhoneNumber;
        aadharNumberEntry.Text = customer.AadharNumber;
        if (customer.DateOfBirth != null) DOBDate.Date = customer.DateOfBirth.Value;
        addressEditor.Text = customer.Address;

        if (customer.CustomerImage != null)
        {
            byte[] byteArray = customer.CustomerImage;
            Stream stream = new MemoryStream(byteArray);
            //retrieveImage.Source = ImageSource.FromStream(() => stream);
            CustomerImage.Source = ImageSource.FromStream(() => stream);

        }
        if (customer.Gender == "Male") rdbMale.IsChecked = true;
        if (customer.Gender == "Female") rdbfemale.IsChecked = true;
        this.id = customer.Id;
    }



    private async void OnCustomerImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync();
        if (result is not null)
        {
            using var stream = await result.OpenReadAsync();
            CustomerImage.Source = result.FullPath;
        }
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        byte[] byteArray = null;
        if (CustomerImage.Source != null)
        {
            ImageSource is1 = CustomerImage.Source;
            string path = ((FileImageSource)CustomerImage.Source).File;
            FileStream img = new FileStream(path, FileMode.Open);
            MemoryStream memoryStream = new MemoryStream();
            img.CopyTo(memoryStream);
            byteArray = memoryStream.ToArray();
        }
        model.Customer customer = new model.Customer()
        {
            FirstName = firstNameEntry.Text,
            LastName = lastNameEntry.Text,
            FatherOrHusbandName = FatherOrHusbandNameEntry.Text,
            NationalityOrReligion = NationalityOrReligionEntry.Text,
            PhoneNumber = phoneNumberEntry.Text,
            AadharNumber = aadharNumberEntry.Text,
            DateOfBirth = DOBDate.Date,
            Address = addressEditor.Text,
            CustomerImage = byteArray,
            Gender = (rdbMale.IsChecked == true) ? "Male" : "Female"
        };
        ApiClient apiClient = new ApiClient();
        if (id == 0)
            await apiClient.CustomerClient.CreateCustomer(customer);
        else
        {
            customer.Id = id;
            await apiClient.CustomerClient.UpdateCustomer(customer);

            await Navigation.PushAsync(new CustomerViewPage());
        }

    }
}