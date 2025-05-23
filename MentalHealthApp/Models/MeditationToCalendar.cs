using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("медитация_календарныйдень")]
    public class MeditationToCalendar
    {
        [Column("IDЗаписи"),PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [Column("IDМедитации"),ForeignKey(typeof(MeditationModel))]
        public int MeditationID { get; set; }

        [Column("IDДня"), ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }
    }
}
