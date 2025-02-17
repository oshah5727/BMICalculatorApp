namespace BMICalculatorApp;

public partial class HealthRecPage : ContentPage
{
	public HealthRecPage(string recommendations)
	{
		InitializeComponent();

        RecommendationsLabel.Text = recommendations;
    }


    private async void OnBackToBMIResultPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnBackToInputPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}