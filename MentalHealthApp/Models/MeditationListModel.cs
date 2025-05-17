using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    public class MeditationListModel
    {
        public string MeditationName { get; set; }
        public int MeditationTime { get; set; }
        public int Level { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string Guide { get; set; }

    }
}
