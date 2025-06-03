using MentalHealthApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp
{
    public class MentalHealthAppDB
    {
        private readonly SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Connection { get => _connection; }

        public MentalHealthAppDB(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTablesAsync<ForReadingModel, ReadingToCalendar, CalendarModel, TaskModel>().Wait();
            _connection.CreateTablesAsync<MeditationModel, BreatheModel, MeditationToCalendar, BreatheToCalendar>().Wait();
            _connection.CreateTablesAsync<FeelingModel, SleepModel, SleepFactorsModel, SleepToSleepFactors>().Wait();
            _connection.CreateTablesAsync<PosThModel, ThemeModel, CategoryModel, FeelingToCalendar>().Wait();
        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetListOfCats()
        {

            return await _connection.GetAllWithChildrenAsync<CategoryModel>();
        }

        /// <summary>
        /// Получение списка информации для чтения
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryModel> GetListOfReading(int id)
        {
            return await _connection.GetWithChildrenAsync<CategoryModel>(id);
        }

        /// <summary>
        /// Получение списка дыхательных техник
        /// </summary>
        /// <returns></returns>
        public async Task<List<BreatheModel>> GetListOfBreathes()
        {
            return await _connection.Table<BreatheModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка медитаций
        /// </summary>
        /// <returns></returns>
        public async Task<List<MeditationModel>> GetListOfMeditations()
        {
            return await _connection.Table<MeditationModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка позитивного мышления
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryModel> GetListOfSubTopics(int id)
        {
            return await _connection.GetWithChildrenAsync<CategoryModel>(id);
        }

        /// <summary>
        /// Получение негативных и позитвных мыслей
        /// </summary>
        /// <returns></returns>
        public async Task<ThemeModel> GetListOfThinks(string str)
        {
            var themeName = await _connection.Table<ThemeModel>().Where(x => x.ThemeName == str).FirstOrDefaultAsync();
            return await _connection.GetWithChildrenAsync<ThemeModel>(themeName.ThemeID);
        }

        /// <summary>
        /// Получение списка эмоций
        /// </summary>
        /// <returns></returns>
        public async Task<List<FeelingModel>> GetListOfFeelings()
        {
            return await _connection.Table<FeelingModel>().ToListAsync();
        }

        /// <summary>
        /// Запись отмеченного самочувствия в БД
        /// </summary>
        /// <param name="textDate"></param>
        /// <param name="textTime"></param>
        /// <param name="feelingMark"></param>
        /// <param name="descr"></param>
        /// <returns></returns>
        public async Task<FeelingToCalendar> WriteFeelingsToDB(string textDate, string textTime, int feelingMark, string descr)
        {
            var currentDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == textDate).FirstOrDefaultAsync();

            var feeling = await _connection.Table<FeelingModel>().Where(x => x.FeelingID == feelingMark).FirstOrDefaultAsync();

            if (currentDate != null)
            {
                await App.Database.Connection.InsertWithChildrenAsync(new FeelingToCalendar()
                {
                    FeelingID = feelingMark,
                    DayID = currentDate.DayID
                ,
                    Description = descr,
                    Time = textTime
                });
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = textDate });
                currentDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == textDate).FirstOrDefaultAsync();
                await App.Database.Connection.InsertWithChildrenAsync(new FeelingToCalendar()
                {
                    FeelingID = feelingMark,
                    DayID = currentDate.DayID
                                ,
                    Description = descr,
                    Time = textTime
                });
            }
            return null;
        }
        /// <summary>
        /// Получение списка факторов сна
        /// </summary>
        /// <returns></returns>
        public async Task<List<SleepFactorsModel>> GetListOfFactors()
        {
            return await _connection.Table<SleepFactorsModel>().ToListAsync();
        }

        /// <summary>
        /// Запись отмеченного сна в БД
        /// </summary>
        /// <param name="todaySleep"></param>
        /// <returns></returns>
        public async Task<CalendarModel> WriteSleepToDB(SleepModel todaySleep)
        {
            DateTime dateTimeNow = new DateTime();
            dateTimeNow = DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset;
            string currentDate = dateTimeNow.ToString("dd/MM/yyyy");

            var date = await _connection.Table<CalendarModel>().Where(x => x.FullDate == currentDate).FirstOrDefaultAsync();
            if (date != null)
            {
                todaySleep.CalendarDay = date;
                await _connection.InsertWithChildrenAsync(todaySleep);
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = currentDate });
                date = await _connection.Table<CalendarModel>().Where(x => x.FullDate == currentDate).FirstOrDefaultAsync();
                todaySleep.CalendarDay = date;
                await _connection.InsertWithChildrenAsync(todaySleep);
            }
            var newDate = await _connection.GetWithChildrenAsync<CalendarModel>(date.DayID);
            return newDate;
        }

        public async Task<CalendarModel> GetCurrentDay(string[] date)
        {
            string formatedDate = date[0] + "/" + date[1] + "/" + date[2];
            var todayDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
            if (todayDate != null)
            {
                var todayDateWithChildren = await _connection.GetWithChildrenAsync<CalendarModel>(todayDate.DayID);
                return todayDateWithChildren;
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = formatedDate });
                todayDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
                var todayDateWithChildren = await _connection.GetWithChildrenAsync<CalendarModel>(todayDate.DayID);
                return todayDate;
            }
                
        }
    }
}
