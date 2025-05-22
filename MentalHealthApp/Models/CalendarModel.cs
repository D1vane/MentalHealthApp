

using SQLite;


namespace MentalHealthApp.Models
{
    [Table("Событие")]
    public class CalendarModel
    {
        [PrimaryKey,AutoIncrement, Column("IDСобытия")]
        public int EventID { get; set; }

        [Column("IDЗадачи")]
        public int TaskID { get; set; }

        [Column("IDМедитации")]
        public int MeditationID { get; set; }

        [Column("IDДыхательнойТехники")]
        public int BreatheID { get; set; }

        [Column("IDСна")]
        public int SleepID { get; set; }

        [Column("IDСамочувствия")]
        public int FeelingID { get; set; }

        [Column("IDИнформации")]
        public int ForReadingID { get; set; }

        [Column("Дата")]
        public string EventDate { get; set; }

    }
}
