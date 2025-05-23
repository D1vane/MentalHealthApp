using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace MentalHealthApp.Models
{
    [Table("Задача")]
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement, Column("IDЗадачи")]
        public int TaskID { get; set; }

        [Column("Наименование")]
        public string TaskText { get; set; }

        [Column("IDДня"), ForeignKey(typeof(CalendarModel))]
        public int DayID { get; set; }

        [Column("Выполнена")]
        public int IsComplete { get; set; }

        [ManyToOne]
        public CalendarModel CalendarDay { get; set; }

    }
}
