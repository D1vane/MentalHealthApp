﻿

using SQLite;
using SQLiteNetExtensions.Attributes;


namespace MentalHealthApp.Models
{
    [Table("КалендарныйДень")]
    public class CalendarModel
    {
        [PrimaryKey,AutoIncrement, Column("IDДня")]
        public int DayID { get; set; }

        [Column("Дата"),Unique]
        public string FullDate { get; set; }

        [ManyToMany(typeof(MeditationToCalendar))]
        public List<MeditationModel> Meditations { get; set; }

        [ManyToMany(typeof(BreatheToCalendar))]
        public List<BreatheModel> Breathes { get; set; }

        [ManyToMany(typeof(ReadingToCalendar))]
        public List<ForReadingModel> Readings { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TaskModel> Tasks { get; set; }

        [ManyToMany(typeof(FeelingToCalendar))]
        public List<FeelingModel> Feelings { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public SleepModel Sleep { get; set; }



    }
}
