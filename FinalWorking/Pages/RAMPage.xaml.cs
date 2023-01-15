namespace FinalWorking.Pages;

public partial class RAMPage : ContentPage
{

    public static string RamSize { get; set; } = "4GB";
    public RAMPage()
	{
		InitializeComponent();
	}

    private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblRamSize.Text = stepper.Value.ToString() + "GB";
        RamSize= lblRamSize.Text;
    }
}