namespace BMICalculatorApp;

public partial class BMICalculatorPage : ContentPage
{
	public BMICalculatorPage()
	{
		InitializeComponent();


	}

    string choice = "";

    private void TapMale_Tapped(object sender, TappedEventArgs e)
    {
        choice = "Male";
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            FrameMale.BorderColor = Color.FromArgb("#0a0e29");
            FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
        }
        else
        {
            FrameMale.BorderColor = Color.FromArgb("#fdfdfd");
            FrameFemale.BorderColor = Color.FromArgb("#0a0e29");
        }
    }

    private void TapFemale_Tapped(object sender, TappedEventArgs e)
    {
        choice = "Female";
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            FrameFemale.BorderColor = Color.FromArgb("#0a0e29");
            FrameMale.BorderColor = Color.FromArgb("#fdfdfd");
        }
        else
        {
            FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
            FrameMale.BorderColor = Color.FromArgb("#0a0e29");
        }
    }

    private void Btn_Clicked(object sender, EventArgs e)
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


        DisplayAlert("Your calculated BMI results are:", resultMessage, "Ok");
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
            return "- Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains)\n" +
                   "- Incorporate strength training to build muscle mass\n" +
                   "- Consult a nutritionist if needed";
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