namespace BMICalculatorApp;

public partial class UserInputPage : ContentPage
{
	public UserInputPage()
	{
		InitializeComponent();


	}

    string choice = "";

    private void TapMale_Tapped(object sender, TappedEventArgs e)
    {
        choice = "Male";
        UpdateGenderSelection();
    }

    private void TapFemale_Tapped(object sender, TappedEventArgs e)
    {
        choice = "Female";
        UpdateGenderSelection();
       
    }

    private void UpdateGenderSelection()
    {
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            FrameMale.BorderColor = (choice == "Male") ? Color.FromArgb("#0a0e29") : Color.FromArgb("#fdfdfd");
            FrameFemale.BorderColor = (choice == "Female") ? Color.FromArgb("#0a0e29") : Color.FromArgb("#fdfdfd");
        }
        else
        {
            FrameMale.BorderColor = (choice == "Male") ? Color.FromArgb("#fdfdfd") : Color.FromArgb("#0a0e29");
            FrameFemale.BorderColor = (choice == "Female") ? Color.FromArgb("#fdfdfd") : Color.FromArgb("#0a0e29");
        }
    }

    private async void Btn_Clicked(object sender, EventArgs e)
    {
        double heightInches = SliderHeight.Value;
        double weightLbs = SliderWeight.Value;

        double bmi = CalculateBMI(weightLbs, heightInches);

        string healthStatus = GetHealthStatus(bmi);

        string recommendations = GetHealthRecommendations(bmi);

        string resultMessage = $"Gender: {choice}\n" +
                           $"BMI: {bmi:F2}\n" +
                           $"Health Status: {healthStatus}\n\n" +
                           $"Recommendations:\n{recommendations}";

        var resultPage = new BMIResultPage(bmi, choice, healthStatus, recommendations);
        await Navigation.PushAsync(resultPage);
    }

    private double CalculateBMI(double weightLbs, double heightInches)
    {
        return (weightLbs * 703) / (heightInches * heightInches);
    }

    private string GetHealthStatus(double bmi)
    {
        if (choice == "Male")
        {
            if (bmi < 18.5) return "Underweight";
            else if (bmi >= 18.5 && bmi < 25) return "Normal weight";
            else if (bmi >= 25 && bmi < 30) return "Overweight";
            else return "Obese";
        }
        else if (choice == "Female")
        {
            if (bmi < 18) return "Underweight";
            else if (bmi >= 18 && bmi < 24) return "Normal weight";
            else if (bmi >= 24 && bmi < 29) return "Overweight";
            else return "Obese";
        }
        return "Please select a gender"; 
    }

    private string GetHealthRecommendations(double bmi)
    {
        if (bmi < 18.5)
        {
            return "- Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains).\n" +
                   "- Incorporate strength training to build muscle mass.\n" +
                   "- Consult a nutritionist if needed.";
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            return "- Maintain a balanced diet with proteins, healthy fats, and fiber.\n" +
                   "- Stay physically active with at least 150 minutes of exercise per week.\n" +
                   "- Keep regular check-ups to monitor overall health.";
        }
        else if (bmi >= 25 && bmi < 30)
        {
            return "- Reduce processed foods and focus on portion control.\n" +
                   "- Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.\n" +
                   "- Drink plenty of water and track your progress.";
        }
        else
        {
            return "- Consult a doctor for personalized guidance.\n" +
                   "- Start with low-impact exercises (e.g., walking, cycling).\n" +
                   "- Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes.\n" +
                   "- Avoid sugary drinks and maintain a consistent sleep schedule.";
        }
    }
}