using FinalWorking.Models;

namespace FinalWorking.Pages;

public partial class CPUPage : ContentPage
{
    public CPUModel cpuModel;
	public CPUPage()
	{
		InitializeComponent();
        ListView_CPU.ItemsSource = App.cpuRepo.GetAll();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListView_CPU.ItemsSource = App.cpuRepo.GetAll();
    }

    private void ButtonAdd_Clicked(object sender, EventArgs e)
    {
        if(cpuModel != null && cpuModel.ID !=0) 
        {
            App.cpuRepo.AddorUpdate(new Models.CPUModel
            {
                ID = cpuModel.ID,
                CPUName = EntryCpuName.Text,
                CPUPrice = Convert.ToInt32(EntryCpuPrice.Text)
            });
            ListView_CPU.ItemsSource = App.cpuRepo.GetAll();
            EntryCpuName.Text = "";
            EntryCpuPrice.Text = "";

        }
        else
        {
            App.cpuRepo.AddorUpdate(new Models.CPUModel
            {
                CPUName = EntryCpuName.Text,
                CPUPrice = Convert.ToInt32(EntryCpuPrice.Text)
            });
            ListView_CPU.ItemsSource= App.cpuRepo.GetAll();
        }
        cpuModel= null;
        ButtonAdd.Text = "Add";
    }

    private void ListView_CPU_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        cpuModel = (Models.CPUModel)e.Item;
        EntryCpuName.Text = cpuModel.CPUName.ToString();
        EntryCpuPrice.Text = cpuModel.CPUPrice.ToString();
        ButtonAdd.Text = "UPDATE";
    }

    private void ButtonDelete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        cpuModel = (CPUModel)button.BindingContext;
        App.cpuRepo.Delete(cpuModel);
        ListView_CPU.ItemsSource = App.cpuRepo.GetAll();
        cpuModel= null;
    }
}