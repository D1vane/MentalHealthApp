using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp.Models
{
    [Table("сон_факторсна")]
    public class SleepToSleepFactors
    {
        [Column("IDЗаписи"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Column("IDСна"), ForeignKey(typeof(SleepModel))]
        public int SleepID { get; set; }

        [Column("IDФактора"), ForeignKey(typeof(SleepFactorsModel))]
        public int FactorID { get; set; }
    }
}
