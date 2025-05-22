using SQLite;
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

        [Column("Факторы")]
        public string SleepFactors { get; set; }

        [Column("Длительность")]
        public string SleepDuration { get; set; }

        [Column("Описание")]
        public string SleepDescription { get; set; }
    }
}
