
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("ДыхательнаяТехника")]
    public class BreatheModel
    {
        [PrimaryKey, AutoIncrement, Column("IDДыхательнойТехники")]
        public int BreatheID { get; set; }

        [Column("Наименование")]
        public string NameOfBreathe { get; set; }

        [Column("Руководство")]
        public string Guide { get; set; }

        [Column("ДлительностьЦикла")]
        public int LoopDuration { get; set; }

        [Column("Изображение")]
        public string ImagePath { get; set; }

        [Column("Избранное")]
        public int IsFavourite { get; set; }

        [ManyToMany(typeof(BreatheToCalendar))]
        public List<CalendarModel> Days { get; set; }


    }
}
