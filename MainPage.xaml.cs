using System.Diagnostics;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
	decimal bill;
    int tip;
    int noOfPersons = 1;

	public MainPage()
	{
		InitializeComponent();

		
	}

    void txtBill_Completed(object sender, EventArgs e)
    {
       
        bill = decimal.Parse(txtBill.Text);


        CalculateTotal();
    }

    private void CalculateTotal()
    {
        var billWTip = (bill * tip) / 100;

        var tipPerPerson = billWTip / noOfPersons;

        lblTipPerPerson.Text = $"{tipPerPerson:C}";

        //calculate subtotal

        var subtotal = bill / noOfPersons;

        lblSubtotal.Text = $"{subtotal:C}";

        //

        var totalPerPerson = (bill + billWTip) / noOfPersons;
        lblTotal.Text = $"{totalPerPerson:C}";




    }

    void TipButton_Clicked(object sender, EventArgs e)
    {
        if( sender is Button)
        {
            var button = (Button)sender;
            var percentage = int.Parse(button.Text.Replace("%", " "));

            sldTip.Value = percentage;
            CalculateTotal();
        }
    }

    void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip =  (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip.ToString()}% ";
    }

    void btnMinus_Clicked(System.Object sender, System.EventArgs e)
    {
        if(noOfPersons > 0)
        {
            noOfPersons--;
            lblNoPersons.Text = noOfPersons.ToString();
            CalculateTotal();
        }
    }

    void btnPlus_Clicked(System.Object sender, System.EventArgs e)
    {
        noOfPersons++;
        lblNoPersons.Text = noOfPersons.ToString();
        CalculateTotal();
    }
}


