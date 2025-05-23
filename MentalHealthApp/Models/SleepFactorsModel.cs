using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("ФакторСна")]
    public class SleepFactorsModel
    {
        [Column("IDФактора"), PrimaryKey, AutoIncrement]
        public int FactorID { get; set; }

        [Column("Наименование")]
        public string FactorName { get; set; }

        [Column("ПередСном")]
        public int IsBeforeSleep { get; set; }

        [ManyToMany(typeof(SleepModel))]
        public List<SleepModel> CurrentSleep { get; set; }
    }
}
