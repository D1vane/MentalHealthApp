﻿using MentalHealthApp.Models;
using SQLite;
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
            ForReadingModel item1 = new ForReadingModel();
            item1.ReadingDuration = 15;
            item1.isFavourite = 0;
            item1.ImagePath = "boss_reading.jpg";
            item1.ReadingName = "Отношения с начальником";
            item1.Sections = "Что не нужно делать\r\nКак себя правильно вести\r\nКак наладить отношения с начальником\r\nКак стать ценным сотрудником\r\n";
            string content = "\tОтношения с руководством — дело непростое. Очень важно уметь сохранять баланс между качественным выполнением своих задач, не забывая при этом про грамотное общение с начальником. Раскрываем секреты коммуникации и уберегаем от ошибок, которые могут поставить крест на вашей карьере.\r\nНачальник — как много скрыто в этом слове. Многие из нас на дрожащих ногах заходят в кабинет своего руководителя, даже просто, чтобы поздороваться, не говоря уже о более глобальных целях. Нам кажется, что он строг и всесилен, а потому лишний раз стараемся не попадаться ему на глаза. Конечно, такая история далеко не у каждого, ведь у некоторых глава команды, напротив, старается общаться на равных, а порой и вовсе предпочитает неформальный язык. Тем не менее в обоих случаях очень важно уметь сохранять границы и все-таки принимать тот факт, что перед вами человек высшего ранга, а потому с ним важно соблюдать особые правила коммуникации.\r\nЕсли вы не хотите поставить крест на своем карьером росте и лишиться работы, стоит раз и навсегда забыть о следующих поступках.\r\nОтказ от выполнения поставленных задач повлечет за собой не только негативные последствия для компании, но и резкое снижение авторитета работника в глазах руководителя. Если вы выражаете свое несогласие и полную невозможность сделать то или иное дело, постарайтесь как можно более подробно это аргументировать и в обязательном порядке предложить что-то взамен. Помните, что ни один уважающий себя начальник не будет держать в своей команде того, кто не умеет качественно выполнять свои обязанности.\r\nФразы «Я не знаю», «Это не моя ответственность, не моя вина», «Мне за это не платят», «Это от меня не зависит» сразу вешают ярлык некомпетентности и выставляют вас далеко не в лучшем свете. В глазах окружающих вы будете выглядеть безынициативным, ненадежным и слабым работником, который не готов расти профессионально и брать ответственность за свои поступки. Руководителю крайне важно, чтобы вы приносили высокие результаты и демонстрировали эффективность своей работы, а в противном случае, вам просто найдут более качественную замену, при чем в самые короткие сроки.\r\nПовышенный тон, грубые выражения и полное несоблюдение субординации до добра не доведут (даже, если руководитель предпочитает неформальность и ставит себя в относительно равное с вами положение). Это говорит не столько о вас, как о работнике, сколько о человеке как таковом. Если руководство отметит, что вы не умеет выстраивать деловую коммуникацию (это самых важный профессиональный навык), то значит вам нельзя доверить общение с клиентами и партнерами, а потому заинтересованность в том, чтобы продолжать с вами сотрудничество, попросту сойдет на нет.\r\nЗабудьте о лжи и любом скрытие проблем в рабочих вопросах. В данном случае даже единичный случай утаивания и обмана может стоит компании огромных финансовых и репутационных потерь, а вам неминуемое увольнение. Важно уметь открыто заявлять о всех неполадках и просить помощи в их устранении, если это не получается сделать самостоятельно.\r\nОсуждать решения руководства не приветствуется ни наедине с ним, ни среди коллег. Вы можете сообщить, что вас что-то не устраивает, но чтобы тайком критиковать — нет, исключено! Начальники никогда не стремятся бороться с подчиненными за право принятия решений, а потому любое несогласие воспринимается им как неуважение к его личности и поступкам.\r\nПомните, что главное — это спокойствие, размеренность и твердый ум. Научитесь открыто и деликатно сообщать своему руководству о том, что вы с чем-то несогласны или какая-то задача кажется вам не по силам. Не бойтесь просить помощи и искать альтернативные, более уместные и тактичные фразы.\r\nНапример, вместо «Я не знаю» нужно сказать «Сейчас я не готов ответить на этот вопрос, но я разберусь и дополнительно вам сообщу».\r\nЗамените отрицание «Это не моя ответственность, не моя вина» на утверждение «Я сделал выводы из данной ситуации и впредь приложу все усилия, чтобы она не повторилась».\r\nПерестаньте акцентировать внимание на плате и вместо категоричного «Мне за это не платят», лучше намекните: «Так как это задание является существенной дополнительной нагрузкой к моему основному функционалу, я смогу выполнить его в определенные сроки. Но хочу обсудить возможность дополнительного вознаграждения в случае его успешного выполнения».\r\nИ не забывайте обосновывать свои отказы. Как вариант, вместо «Это от меня не зависит» используйте «Со своей стороны я приложу все усилия, но следует учитывать следующие факторы…»\r\nБудьте открытыми и честными. Помните, что начальник — это такой же обычный человек, который может войти в положение и даже помочь, если заранее информировать его о проблемах и попросить консультацию.\r\nПри несогласии с решением руководителя деликатно намекните ему об этом. Не забудьте аргументировать свою точку зрения и предлагать иные варианты.\r\nНаучитесь принимать критику. Она поможет вам расти и развиваться, ведь как ни крути, но ваш начальник опытнее вас, а значит наверняка знает как будет лучше.\r\nОтноситесь к нему уважительно и не повышайте голос. Избегайте обвинений в его адрес и не бойтесь задавать вопросы, но только после того, как он окончательно закончит свою речь.\r\nПомните, что компании всегда дорожат грамотными сотрудниками. Профессионалы ценились во все времена, а дипломатичные и тактичные вдвойне.\r\nКрайне важно быстро реагировать на запросы руководителя и уметь их качественно выполнять. Самодисциплина и уверенность в своих действиях никогда не пройдут незамеченными для глаз руководства. Умение выстраивать деловую коммуникацию и долгосрочные отношения с коллегами, клиентами и партнерами, обеспечивает хорошие отношения и с начальством.\r\nНе останавливайтесь на достигнутом и стремитесь всегда расширять свои личные и профессиональные навыки.\r\nНе забывайте о границах и учитесь адекватно оценивать результаты своей работы. Находя «плюсы» и «минусы» гораздо проще выстраивать дальнейшие траектории.\r\nНикогда не обсуждайте личную жизнь руководителя и уж тем более не распространяйте секреты или сплетни. Рано или поздно это станет известно всем, а значит вы неминуемо упадете в глазах окружающих. Кроме того, коллеги также могут начать относиться к вам человеку с недоверием — перестать делиться рабочей и личной информацией, опасаясь тоже стать объектами обсуждений.\r\nПомните, что за вами все фиксируется, а потому для дальнейший карьеры важно зарекомендовать себя в стенах одной компании, чтобы затем переместиться в другую. Все-таки силу характеристики с предыдущего места работы никто не отменял.\r\n";
            item1.Content = content.Replace("\r\n", "\n\t");
            CategoryModel categoryModel = new CategoryModel();
            //!categoryModel.NameOfCategory

            ForReadingModel item2 = new ForReadingModel();
            item2.ReadingDuration = 10;
            item2.isFavourite = 0;
            item2.ImagePath = "colleagues_reading.jpg";
            item2.ReadingName = "Отношения с коллегами";

            ForReadingModel item3 = new ForReadingModel();
            item3.ReadingDuration = 10;
            item3.isFavourite = 0;
            item3.ImagePath = "firstdaywork_reading.jpg";
            item3.ReadingName = "Первый рабочий день";

            ForReadingModel item4 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "efficiency_reading.jpg",
                ReadingName = "Производительность"
            };

            ForReadingModel item5 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "teacher_reading.jpg",
                ReadingName = "Отношения с учителем"
            };
            ForReadingModel item6 = new ForReadingModel()
            {
                ReadingDuration = 10,
                isFavourite = 0,
                ImagePath = "schoolfriends_reading.jpg",
                ReadingName = "Отношения с товарищами"
            };


            List<ForReadingModel> models = new List<ForReadingModel>() { item1, item2, item3, item4 };
            await _connection.InsertAllAsync(models);

        }
        private async void UpdateItems()
        {

           MeditationModel model = await _connection.Table<MeditationModel>().Where(x => x.MeditationName == "Медитация Анапанасати").FirstOrDefaultAsync();
            string content = "\tМедитативная практика, которая сосредоточена на внимательном наблюдении за дыханием. Она фокусируется на наблюдении за ощущением вдоха и выдоха через нос, чтобы помочь практикующему развить осознанность и сосредоточение ума. Цель и польза этой практики с психологической точки зрения – достижение полного присутствия в настоящем моменте без вмешательства мыслей или оценок, улучшить концентрацию и снизить стресс и тревогу.\r\nПринято считать, что практика памятования о дыхании довольно универсальна, поэтому часто используется как фундамент для любой медитации, так как «мы способны вступить в контакт со всеми нашими физическими и психическими способностями и поставить их в связь с нашим сознательным умом».\r\nПрактика анапанасати основана на универсальных принципах и подходит всем людям. Именно поэтому анапанасати рекомендуется как наилучшая точка отсчёта для любого вида медитации. Анапанасати может также рассматриваться как основа любой медитации, так как именно с помощью дыхания «мы способны вступить в контакт со всеми нашими физическими и психическими способностями и поставить их в связь с нашим сознательным умом».\r\nПрактика анапанасати — это, прежде всего, тренировка внимания, а не дыхательное упражнение в ключе пранаямы, дыхательной гимнастики в йоге. В буддийских практиках с дыханием намеренные воздействия не совершаются. Наблюдая за естественным течением дыхания, практикующий гармонизирует своё общее состояние. Внимательность по отношению к дыханию оказывается одним из факторов физического и психического здоровья в целом.\r\nПри целенаправленных занятиях в дальнейшем анапанасати позволяет осуществить практику более глубоких уровней медитации, таких как дхьяна и самадхи. Превращение процесса дыхания из автоматической функции тела в сознательную позволяет использовать её в дальнейшем как посредника духовных сил.\r\nМетодика практики анапанасати проста на начальном этапе настолько, что её может выполнять даже самый новоиспеченный последователь. Однако, при всей видимой простоте техники, сосредоточить внимание на дыхании удаётся далеко не сразу. Дыхание зачастую так же неупорядоченно, как и поток мыслей в сознании. Но при направлении внимания на дыхание, теряется его естественный ритм. Сложность состоит в том, чтобы не начать управлять дыханием, а спокойно следить за его течением. Поначалу для того чтобы не сбиться, медитирующий считает вдохи и выдохи. С одной стороны, цифры помогают сосредоточить внимание на дыхании и не отвлекаться на другие мысли, но и таят опасность привлечь внимание к себе как объекту.\r\nСреди главных условий практики подчёркивается естественность процесса дыхания. Медитирующего предостерегают от задержки дыхания, а также от придания ему определённого ритма. Основная задача анапанасати — не препятствовать дыханию и наблюдать за ним, не пытаясь повлиять на его ход. При выполнении упражнения точка внимания удерживается на месте соприкосновения воздуха с телом, то есть на ноздрях. Избежание преднамеренности — одна из важных черт успешности осуществления практики анапанасати. Наиболее предпочтительной при практике анапанасати считается поза «лотос» со скрещёнными ногами. В «Анапанасати-сутте» указано, что правильно выбранная поза и место для практики играют не последнюю роль. Предпочтительной является практика под руководством опытного учителя, так как любая медитация требует индивидуального подхода. Однако, избегая крайностей, человек может достичь определённых результатов и будучи один.\r\n";
            model.MeditationContent = content.Replace("\r\n", "\n\t");
            await _connection.UpdateAsync(model);
        }

        /// <summary>
        /// Получение списка категорий
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetListOfCats()
        {

            return await _connection.Table<CategoryModel>().ToListAsync();
        }

        /// <summary>
        /// Получение списка информации для чтения
        /// </summary>
        /// <returns></returns>
        public async Task<List<ForReadingModel>> GetListOfReading(int id)
        {
            return await _connection.Table<ForReadingModel>().Where(x=>x.CategoryID==id).ToListAsync();
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
        public async Task<List<PosThCardsModel>> GetListOfSubTopics(int id)
        {
            return await _connection.Table<PosThCardsModel>().Where(x => x.CategoryID == id).ToListAsync();
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
