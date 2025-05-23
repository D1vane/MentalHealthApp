using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("длячтения_календарныйдень")]
    public class ReadingToCalendar
    {
        [Column("IDЗаписи"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Column("IDИнформации"), ForeignKey(typeof(ForReadingModel))]
        public int BreatheID { get; set; }

        [Column("IDДня"), ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }

        [ManyToOne]
        public CategoryModel CurrentCategory { get; set; }
    }
}
