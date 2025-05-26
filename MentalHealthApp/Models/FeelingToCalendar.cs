using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("самочувствие_календарныйдень")]
    public class FeelingToCalendar
    {
        [Column("IDСвязи"), PrimaryKey, AutoIncrement]
        public int RelationID { get; set; }

        [Column("IDСамочувствия"),ForeignKey(typeof(FeelingModel))]
        public int FeelingID { get; set; }

        [Column("IDДня"),ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }

        [Column("Описание")]
        public string Description { get; set; }

        [Column("Время")]
        public string Time { get; set; }
    }
}
