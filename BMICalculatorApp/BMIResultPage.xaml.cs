namespace BMICalculatorApp;

public partial class BMIResultPage : ContentPage
{
    public BMIResultPage(double bmi, string gender, string bmiCategory, string recommendations)
    {
        InitializeComponent();

        LblBMI.Text = $"Your BMI: {bmi:F2}";
        LblBMICategory.Text = $"BMI Category: {bmiCategory}";

        Recommendations = recommendations;
    }

    public string Recommendations
    {
        get; set;
    }

        private async void OnRecommendationsButtonClicked(object sender, EventArgs e)
        {
            var recommendationsPage = new HealthRecPage(Recommendations);
            await Navigation.PushAsync(recommendationsPage);
        }

        private async void OnBackToInputPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }