using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("дыхательнаятехника_календарныйдень")]
    public class BreatheToCalendar
    {
        [Column("IDЗаписи"),PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [Column("IDТехники"),ForeignKey(typeof(BreatheModel))]
        public int BreatheID { get; set; }

        [Column("IDДня"), ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }
    }
}
