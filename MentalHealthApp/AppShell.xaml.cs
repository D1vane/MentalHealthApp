namespace MentalHealthApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            CurrentItem = HealthPage;
            Routing.RegisterRoute("Planner", typeof(Planner));
        }
    }
}
