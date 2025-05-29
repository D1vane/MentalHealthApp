using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("Самочувствие")]
    public class FeelingModel
    {
        [PrimaryKey,AutoIncrement, Column("IDСамочувствия")]
        public int FeelingID { get; set; }

        [Column("Наименование")]
        public string FeelingName { get; set; }

        [Column("Оценка"),Unique]
        public int FeelingMark { get; set; }

        [ManyToMany(typeof(FeelingToCalendar))]
        public List<CalendarModel> Days { get; set; }

    }
}
