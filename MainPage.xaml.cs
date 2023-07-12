namespace PerfectPay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;
	int pruebajeje;

	public MainPage()
	{
		InitializeComponent();
	}

    private void txtBill_Completed(object sender, EventArgs e)
    {
		txtBill.Unfocus();
		bill=decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

    private void CalculateTotal()
	{
		var TotalTip= (bill * tip) / 100;

		var tipByPerson = TotalTip / noPersons;

		var subTotal = bill / noPersons;

		var total = (bill + TotalTip)/noPersons;

        lblTotal.Text = "$ " + Math.Round(total, 2).ToString();
		lblSubTotal.Text = "$ " + Math.Round(subTotal,2).ToString();
		lblTipByPerson.Text = "$ " + Math.Round(tipByPerson,2).ToString();
	}

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();

	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			sldTip.Value = percentage;
		}
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
		if(noPersons > 1)
		{
			noPersons--;
		}
		lblNoPerson.Text = noPersons.ToString();
		CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
		noPersons++;
		lblNoPerson.Text = noPersons.ToString();
		CalculateTotal();
    }
}

