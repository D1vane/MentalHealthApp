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
            //_connection.DropTableAsync<FeelingToCalendar>().Wait();
            //_connection.DropTableAsync<CalendarModel>().Wait();
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
            List<FeelingModel> newFeelings =
                [
                new () {FeelingName = "Отвратительно", FeelingMark = 1},
                new () {FeelingName = "Ужасно", FeelingMark = 2},
                new () {FeelingName = "Скверно", FeelingMark = 3},
                new () {FeelingName = "Плохо", FeelingMark = 4},
                new () {FeelingName = "Хочется грустить", FeelingMark = 5},
                new () {FeelingName = "Бывало и лучше", FeelingMark = 6},
                new () {FeelingName = "Хорошо", FeelingMark = 7},
                new () {FeelingName = "Отлично", FeelingMark = 8},
                new () {FeelingName = "Превосходно", FeelingMark = 9},
                new () {FeelingName = "Лучше некуда", FeelingMark = 10},
                ];
            await _connection.InsertAllAsync(newFeelings);
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

            await _connection.InsertOrReplaceWithChildrenAsync(theme,true);
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
    }
}
