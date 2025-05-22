using SQLite;
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

        [Column("Оценка")]
        public int FeelingMark { get; set; }

        [Column("Описание")]
        public string FeelingDescription { get; set; }

    }
}
