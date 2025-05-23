using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("Сон")]
    public class SleepModel
    {
        [PrimaryKey,AutoIncrement, Column("IDСна")]
        public int SleepID { get; set; }

        [Column("IDДня"),ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }

        [Column("Длительность")]
        public int SleepDuration { get; set; }

        [Column("Описание")]
        public string SleepDescription { get; set; }

        [ManyToMany(typeof(SleepToSleepFactors))]
        public List<SleepFactorsModel> Factors { get; set; }

        [ManyToOne]
        public CalendarModel CalendarDay { get; set; }
    }
}
