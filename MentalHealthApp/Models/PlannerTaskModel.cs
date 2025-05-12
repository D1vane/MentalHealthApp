using System.ComponentModel;

namespace MentalHealthApp.Models
{
    public class PlannerTaskModel
    {
        public bool IsNew { get; set; }
        public string TextTask { get; set; }

        public string TimeOfTask { get; set; }
    }
}
