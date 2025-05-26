using MentalHealthApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealthApp
{
    public class MentalHealthAppDB
    {
        private readonly SQLiteAsyncConnection _connection;
        public  SQLiteAsyncConnection Connection { get => _connection; }

        public MentalHealthAppDB(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTablesAsync<MeditationModel, BreatheModel, MeditationToCalendar, BreatheToCalendar>().Wait();
            _connection.CreateTablesAsync<ForReadingModel, ReadingToCalendar, CalendarModel, TaskModel>().Wait();
            _connection.CreateTablesAsync<FeelingModel,SleepModel,SleepFactorsModel,SleepToSleepFactors>().Wait();
            //_connection.DropTableAsync<CategoryModel>().Wait();
            //_connection.DropTableAsync<ThemeModel>().Wait();
            _connection.CreateTablesAsync<PosThModel, ThemeModel, CategoryModel>().Wait();
            //AddItems();
            //UpdateItems();
        }

        private async void AddItems()
        {
            CategoryModel catWork = await _connection.GetWithChildrenAsync<CategoryModel>(1);

            CategoryModel catStudy = await _connection.GetWithChildrenAsync<CategoryModel>(2);

            CategoryModel catHealth = await _connection.GetWithChildrenAsync<CategoryModel>(3);

            CategoryModel catLife = await _connection.GetWithChildrenAsync<CategoryModel>(4);


            ThemeModel theme1 = new() { ThemeName = "Что обо мне думает начальник?", ImagePath = "boss_thinks.jpg" };

            ThemeModel theme2 = new() { ThemeName = "Что обо мне думают коллеги?", ImagePath = "colleagues_thinks.jpg" };

            ThemeModel theme3 = new() { ThemeName = "Нравится ли мне моя работа?", ImagePath = "islikejob_thinks.jpg" };

            ThemeModel theme4 = new() { ThemeName = "Я удовлетворен своими результатами?", ImagePath = "myresults_thinks.jpg" };


            ThemeModel theme5 = new() { ThemeName = "Что обо мне думает учитель?", ImagePath = "teacher_thinks.jpg" };

            ThemeModel theme6 = new() { ThemeName = "Что обо мне думают одноклассники?", ImagePath = "schoolfriends_thinks.jpg" };

            ThemeModel theme7 = new() { ThemeName = "Кем я буду в будущем?", ImagePath = "futureprofession_thinks.jpg" };

            ThemeModel theme8 = new() { ThemeName = "Я удовлетворен своими результатами?", ImagePath = "selfmark_thinks.jpg" };


            ThemeModel theme9 = new() { ThemeName = "Почему здоровье это важно?", ImagePath = "healthisimportant_thinks.jpg" };

            ThemeModel theme10 = new() { ThemeName = "Хочу ли я быть свободным?", ImagePath = "befree_thinks.jpg" };

            ThemeModel theme11 = new() { ThemeName = "Почему ЗОЖ это лучшее решение?", ImagePath = "hls_thinks.jpg" };

            ThemeModel theme12 = new() { ThemeName = "Как на мне скажется мое здоровье?", ImagePath = "myhealth_thinks.jpg" };


            ThemeModel theme13 = new() { ThemeName = "Я ответсвенный член семьи?", ImagePath = "responsiblememberoffamily_thinks.jpg" };

            ThemeModel theme14 = new() { ThemeName = "Мой ребенок уважает меня?", ImagePath = "childrespect_thinks.jpg" };

            ThemeModel theme15 = new() { ThemeName = "Почему важно соблюдать порядок дома?", ImagePath = "cleanhome_thinks.jpg" };

            ThemeModel theme16 = new() { ThemeName = "Не строгий ли я родитель?", ImagePath = "angryparent_thinks.jpg" };


            catWork.Themes = new List<ThemeModel> { theme1, theme2, theme3, theme4 };

            catStudy.Themes = new List<ThemeModel> { theme5, theme6, theme7, theme8 };

            catHealth.Themes = new List<ThemeModel> { theme9, theme10, theme11, theme12 };

            catLife.Themes = new List<ThemeModel> { theme13, theme14, theme15, theme16 };


            await _connection.InsertOrReplaceWithChildrenAsync(catWork, true);
            await _connection.InsertOrReplaceWithChildrenAsync(catStudy, true);
            await _connection.InsertOrReplaceWithChildrenAsync(catHealth, true);
            await _connection.InsertOrReplaceWithChildrenAsync(catLife, true);

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

           await _connection.InsertOrReplaceWithChildrenAsync(theme);
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
        public async Task <CategoryModel> GetListOfReading(int id)
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

            if (str != null)
            {
                var themeName = await _connection.Table<ThemeModel>().Where(x => x.ThemeName == str).FirstOrDefaultAsync();
                return await _connection.GetWithChildrenAsync<ThemeModel>(themeName.ThemeID);
            }
            return null;
            
        }
    }
}
