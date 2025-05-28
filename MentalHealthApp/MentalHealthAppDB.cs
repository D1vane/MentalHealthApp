using MentalHealthApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using SQLitePCL;
using System;
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
            //_connection.DropTableAsync<TaskModel>().Wait();
            //_connection.DropTableAsync<CalendarModel>().Wait();
            //_connection.DropTableAsync<FeelingToCalendar>().Wait();
            _connection.CreateTablesAsync<ForReadingModel, ReadingToCalendar, CalendarModel, TaskModel>().Wait();
            _connection.CreateTablesAsync<MeditationModel, BreatheModel, MeditationToCalendar, BreatheToCalendar>().Wait();
            _connection.CreateTablesAsync<FeelingModel, SleepModel, SleepFactorsModel, SleepToSleepFactors>().Wait();
            //_connection.DropTableAsync<CategoryModel>().Wait();
            //_connection.DropTableAsync<ThemeModel>().Wait();
            _connection.CreateTablesAsync<PosThModel, ThemeModel, CategoryModel, FeelingToCalendar>().Wait();
            //AddItems();
            //UpdateItems();
        }

        private async void AddItems()
        {
            List<SleepFactorsModel> newFactors =
                [
                    new () {FactorName = "Гаджет", ImagePath = "phone_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Легкий перекус", ImagePath = "smalleat_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Тяжелая пища", ImagePath = "hardeating_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Кофеин", ImagePath = "coffee_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Никотин", ImagePath = "nicotine_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Алкоголь", ImagePath = "alcohol_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Сильный стресс", ImagePath = "stress_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Умственная нагрузка", ImagePath = "brainthink_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Физическая нагрузка", ImagePath = "physicalexecrises_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Выпито много воды", ImagePath = "alotofwater_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Прием лекарств", ImagePath = "medicines_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Помещение проветрено", ImagePath = "wind_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Чтение книги", ImagePath = "bookreading_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Прогулка на воздухе", ImagePath = "walkingonair_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Теплый душ", ImagePath = "shower_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Спокойная музыка", ImagePath = "headphones_icon.jpg", IsBeforeSleep = 1},
                    new () {FactorName = "Посторонние звуки", ImagePath = "earvolume_icon.jpg", IsBeforeSleep = 0},
                    new () {FactorName = "Нарушение темноты", ImagePath = "lamp_icon.jpg", IsBeforeSleep = 0},
                    new () {FactorName = "Нарушение режима", ImagePath = "brokensleeptime_icon.jpg", IsBeforeSleep = 0},
                ];
            await _connection.InsertAllAsync(newFactors);
        }
        private async void UpdateItems()
        {

            ThemeModel theme = await _connection.GetWithChildrenAsync<ThemeModel>(1);
            List<PosThModel> listOfThinks =
                [
                new() {isFavourite = 0, NegativeThink = "Начальник не замечает мои достижения и обесценивает мой труд",
                    PositiveThink = "Возможно, начальник просто не осведомлён о моих результатах — мне стоит научиться быть более заметным"},
                new() {isFavourite = 0, NegativeThink = "Начальник придирается ко мне и требует больше, чем от других сотрудников",
                    PositiveThink = "Вероятно, начальник видит во мне потенциал и потому предъявляет более высокие требования — это шанс расти профессионально"},
                new() {isFavourite = 0, NegativeThink = "Начальник предвзято относится ко мне",
                    PositiveThink = "Может быть, я интерпретирую ситуацию слишком лично. Стоит попробовать открыто обсудить рабочие моменты и уточнить ожидания, чтобы прояснить недопонимания"},
                new() {isFavourite = 0, NegativeThink = "Начальник игнорирует мои просьбы и предложения",
                    PositiveThink = "Возможно, мои идеи требуют более чёткого обоснования или подачи в нужное время"},
                new() {isFavourite = 0, NegativeThink = "Начальник намеренно не хочет повышать меня и давать новые проекты",
                    PositiveThink = "Вероятно, сейчас не лучшее время для повышения по объективным причинам. Я могу уточнить, что нужно улучшить, чтобы перейти на следующий уровень, и показать свою готовность к новым задачам"},
                new() {isFavourite = 0, NegativeThink = "Начальник не хочет повышать мне зарплату",
                    PositiveThink = "Возможно дело в обстоятельствах, не зависящих от моего начальника - мне стоит спросить его об этом напрямую"},
                ];
            theme.Thinks = listOfThinks;

            await _connection.InsertOrReplaceWithChildrenAsync(theme, true);
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

        public async Task<CalendarModel> GetCurrentDay()
        {
            DateTime dateTimeNow = new DateTime();
            dateTimeNow = DateTime.UtcNow + TimeZoneInfo.Local.BaseUtcOffset;
            string currentDate = dateTimeNow.ToString("dd/MM/yyyy");
            return await _connection.Table<CalendarModel>().Where(x => x.FullDate == currentDate).FirstOrDefaultAsync();
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
            CalendarModel fullDay;

            if (currentDate != null)
            {
                fullDay = await _connection.GetWithChildrenAsync<CalendarModel>(currentDate.DayID);
                if (fullDay.Feelings != null)
                    fullDay.Feelings.Add(feeling);
                else
                    fullDay.Feelings = new List<FeelingModel>() { feeling };
                await _connection.UpdateWithChildrenAsync(fullDay);
            }
            else
            {
                await _connection.InsertAsync(new CalendarModel() { FullDate = textDate });
                currentDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == textDate).FirstOrDefaultAsync();
                fullDay = await _connection.GetWithChildrenAsync<CalendarModel>(currentDate.DayID);
                fullDay.Feelings = new List<FeelingModel>() { feeling };
                await _connection.UpdateWithChildrenAsync(fullDay);
            }

            var feelsToCalendar = await _connection.Table<FeelingToCalendar>().Where(x => x.DayID == fullDay.DayID).ToListAsync();
            var additionalInfo = await _connection.GetWithChildrenAsync<FeelingToCalendar>(feelsToCalendar.Last().DayID);
            additionalInfo.Time = textTime;
            if (descr != null)
                additionalInfo.Description = descr;
            await _connection.UpdateWithChildrenAsync(additionalInfo);
            return additionalInfo;
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

        public async Task<CalendarModel> GetTasksFromACurrentDay(DateTime date)
        {
            string formatedDate = date.ToString("dd/MM/yyyy");
            var todayDate = await _connection.Table<CalendarModel>().Where(x => x.FullDate == formatedDate).FirstOrDefaultAsync();
            if (todayDate != null)
            {
                var todayDateWithChildren = await _connection.GetWithChildrenAsync<CalendarModel>(todayDate.DayID);
                return todayDateWithChildren;
            }
            else
                return todayDate;
        }
    }
}
