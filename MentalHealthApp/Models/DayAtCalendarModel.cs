using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    public class DayAtCalendarModel
    {
        public int? CurrentDay { get; set; }

        public bool IsHasTasks { get; set; }

        public List<FavouriteModel> ListOfEvents { get; set; }
    }
}
