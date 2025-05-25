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
            _connection.CreateTablesAsync<PosThModel, ThemeModel, CategoryModel>().Wait();
            AddItems();
            //UpdateItems();
        }

        private async void AddItems()
        {
            //!CategoryModel catWork = await _connection.GetWithChildrenAsync<CategoryModel>(1);

            CategoryModel catStudy = await _connection.GetWithChildrenAsync<CategoryModel>(2);

            CategoryModel catHealth = await _connection.GetWithChildrenAsync<CategoryModel>(3);

            CategoryModel catLife = await _connection.GetWithChildrenAsync<CategoryModel>(4);


            ThemeModel theme1 = new() { ThemeName = "Что обо мне думает начальник?", ImagePath = "boss_thinks.jpg"};

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


            await _connection.InsertOrReplaceWithChildrenAsync(catWork,true);
            await _connection.InsertOrReplaceWithChildrenAsync(catStudy, true);
            await _connection.InsertOrReplaceWithChildrenAsync(catHealth, true);
            await _connection.InsertOrReplaceWithChildrenAsync(catLife, true);

        }
        private async void UpdateItems()
        {

           ForReadingModel model = await _connection.Table<ForReadingModel>().Where(x => x.CategoryID == 1).FirstOrDefaultAsync();
            //var category = await _connection.Table<CategoryModel>().ToListAsync();
            CategoryModel category = new CategoryModel { NameOfCategory = "Работа", CategoryID = 1 };
            // string content = "\tМедитативная практика, которая сосредоточена на внимательном наблюдении за дыханием. Она фокусируется на наблюдении за ощущением вдоха и выдоха через нос, чтобы помочь практикующему развить осознанность и сосредоточение ума. Цель и польза этой практики с психологической точки зрения – достижение полного присутствия в настоящем моменте без вмешательства мыслей или оценок, улучшить концентрацию и снизить стресс и тревогу.\r\nПринято считать, что практика памятования о дыхании довольно универсальна, поэтому часто используется как фундамент для любой медитации, так как «мы способны вступить в контакт со всеми нашими физическими и психическими способностями и поставить их в связь с нашим сознательным умом».\r\nПрактика анапанасати основана на универсальных принципах и подходит всем людям. Именно поэтому анапанасати рекомендуется как наилучшая точка отсчёта для любого вида медитации. Анапанасати может также рассматриваться как основа любой медитации, так как именно с помощью дыхания «мы способны вступить в контакт со всеми нашими физическими и психическими способностями и поставить их в связь с нашим сознательным умом».\r\nПрактика анапанасати — это, прежде всего, тренировка внимания, а не дыхательное упражнение в ключе пранаямы, дыхательной гимнастики в йоге. В буддийских практиках с дыханием намеренные воздействия не совершаются. Наблюдая за естественным течением дыхания, практикующий гармонизирует своё общее состояние. Внимательность по отношению к дыханию оказывается одним из факторов физического и психического здоровья в целом.\r\nПри целенаправленных занятиях в дальнейшем анапанасати позволяет осуществить практику более глубоких уровней медитации, таких как дхьяна и самадхи. Превращение процесса дыхания из автоматической функции тела в сознательную позволяет использовать её в дальнейшем как посредника духовных сил.\r\nМетодика практики анапанасати проста на начальном этапе настолько, что её может выполнять даже самый новоиспеченный последователь. Однако, при всей видимой простоте техники, сосредоточить внимание на дыхании удаётся далеко не сразу. Дыхание зачастую так же неупорядоченно, как и поток мыслей в сознании. Но при направлении внимания на дыхание, теряется его естественный ритм. Сложность состоит в том, чтобы не начать управлять дыханием, а спокойно следить за его течением. Поначалу для того чтобы не сбиться, медитирующий считает вдохи и выдохи. С одной стороны, цифры помогают сосредоточить внимание на дыхании и не отвлекаться на другие мысли, но и таят опасность привлечь внимание к себе как объекту.\r\nСреди главных условий практики подчёркивается естественность процесса дыхания. Медитирующего предостерегают от задержки дыхания, а также от придания ему определённого ритма. Основная задача анапанасати — не препятствовать дыханию и наблюдать за ним, не пытаясь повлиять на его ход. При выполнении упражнения точка внимания удерживается на месте соприкосновения воздуха с телом, то есть на ноздрях. Избежание преднамеренности — одна из важных черт успешности осуществления практики анапанасати. Наиболее предпочтительной при практике анапанасати считается поза «лотос» со скрещёнными ногами. В «Анапанасати-сутте» указано, что правильно выбранная поза и место для практики играют не последнюю роль. Предпочтительной является практика под руководством опытного учителя, так как любая медитация требует индивидуального подхода. Однако, избегая крайностей, человек может достичь определённых результатов и будучи один.\r\n";
            model.CurrentCategory = category;
            model.CategoryID = category.CategoryID;
            await _connection.UpdateAsync(model);
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
        public async Task<List<PosThModel>> GetListOfThinks(string str)
        {
            return await _connection.Table<PosThModel>().ToListAsync();
        }
    }
}
