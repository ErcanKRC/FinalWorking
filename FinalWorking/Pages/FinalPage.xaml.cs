using FinalWorking.Models;

namespace FinalWorking.Pages;

public partial class FinalPage : ContentPage
{

	public FinalPage(CheckoutModel item)
	{
		InitializeComponent();
		if (item != null) fnl_lbl.Text = "Thanks for buying. Have a nice day";

	}
}