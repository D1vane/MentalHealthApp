namespace MentalHealthApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlannerHomePage_Clicked(object sender, TappedEventArgs e)
        {
            Shell.Current.GoToAsync("Planner");
        }
    }

}
