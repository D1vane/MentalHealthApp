using MentalHealthApp.Views;

namespace MentalHealthApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            CurrentItem = HealthPage;
            Routing.RegisterRoute("Planner", typeof(Planner));

            Routing.RegisterRoute("PositiveThinking", typeof(PositiveThinking));
            Routing.RegisterRoute("PositiveThinkingCards", typeof(PositiveThinkingCards));

            Routing.RegisterRoute("ForReading", typeof(ForReading));
            Routing.RegisterRoute("ForReadingSelected", typeof(ForReadingSelected));

            Routing.RegisterRoute("MeditationList", typeof(MeditationList));
        }
    }
}
