using SQLite;
using System.ComponentModel;

namespace MentalHealthApp.Models
{
    [Table("Задача")]
    public class PlannerTaskModel
    {
        [PrimaryKey,AutoIncrement, Column("IDЗадачи")]       
        public int TaskID { get; set; }

        [Column("Содержание")]
        public string TaskText { get; set; }

        [Column("Дата")]
        public DateTime TaskDate { get; set; }

        [Column("Выполнена")]
        public int IsComplete { get; set; }

    }
}
