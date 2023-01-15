using FinalWorking.Models;

namespace FinalWorking.Pages;

public partial class MonitorPage : ContentPage
{
    RadioButton rb;
    public MonitorModel monitor;
    public string monitorName;

    public MonitorPage()
    {
        InitializeComponent();
        ListView_Monitor.ItemsSource = App.monitorRepo.GetAll();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListView_Monitor.ItemsSource = App.monitorRepo.GetAll();
        AsusRadio.IsChecked = true;
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        rb = sender as RadioButton;
        monitorName = rb.Content.ToString();
    }

    private void ButtonAdd_Clicked(object sender, EventArgs e)
    {
        if (monitor != null && monitor.ID != 0 && rb != null)
        {
            App.monitorRepo.AddorUpdate(new Models.MonitorModel
            {
                ID = monitor.ID,
                MonitorName = rb.Content.ToString(),
                MonitorPrice = Convert.ToInt32(EntryMonitorPrice.Text),
            });

            EntryMonitorPrice.Text = "";
        }
        else
        {
            App.monitorRepo.AddorUpdate(new Models.MonitorModel
            {
                MonitorName = monitorName,
                MonitorPrice = Convert.ToInt32(EntryMonitorPrice.Text)
            });
            ListView_Monitor.ItemsSource = App.monitorRepo.GetAll();
            rb = null;
            ButtonAdd.Text = "Add";
        }
    }

    private void ListView_Monitor_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        monitor = (MonitorModel)e.Item;
        monitorName = monitor.MonitorName;

        EntryMonitorPrice.Text= monitor.MonitorPrice.ToString();
        ButtonAdd.Text = "Update";
    }

    private void ButtonDelete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        monitor = (MonitorModel)button.BindingContext;
        App.monitorRepo.Delete(monitor);

        ListView_Monitor.ItemsSource = App.monitorRepo.GetAll();
    }
}