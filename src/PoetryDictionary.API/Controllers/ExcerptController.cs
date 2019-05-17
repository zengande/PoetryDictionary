using Masuit.Tools.DateTimeExt;
using Microsoft.AspNetCore.Mvc;
using PoetryDictionary.API.Infrastructures;
using PoetryDictionary.Database.Models;
using PoetryDictionary.Service;
using SmartSql.IdGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetryDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcerptController : ControllerBase
    {
        private readonly ExcerptService _service;
        private readonly IIdGenerator _idGenerator;
        public ExcerptController(ExcerptService service,
            IdGeneratorFactory idGeneratorFactory)
        {
            _service = service;
            _idGenerator = idGeneratorFactory.CreateSnowflakeIdGenerator();
        }

        [HttpGet]
        public async Task<IEnumerable<Excerpt>> Get(int days = 7)
        {
            return await _service.QueryAsync();

            //if (days <= 0 || days > 90)
            //{
            //    return null;
            //}

            //var excerpts = new ExcerptViewModel[days];
            //for (var i = 0; i < days; i++)
            //{
            //    var now = DateTime.Now.AddDays(i);
            //    var today = new ChineseCalendar(now);
            //    excerpts[i] = new ExcerptViewModel
            //    {
            //        Date = today.Date,
            //        Day = now.Day,
            //        Week = today.WeekDayStr,
            //        AnimalString = today.AnimalString,
            //        Holiday = today.ChineseCalendarHoliday,
            //        GanZhiDate = new GanZhiDate
            //        {
            //            Year = today.GanZhiYearString,
            //            Month = today.GanZhiMonthString,
            //            Day = today.GanZhiDayString
            //        },
            //        Verse = new Verse
            //        {
            //            Contents = FakeVerses[i % FakeVerses.Length],
            //            Author = "诗人名",
            //            Source = "出于何处"
            //        }
            //    };
            //}
            //return excerpts;
        }

        //[HttpPost]
        //public long Post([FromBody]Excerpt excerpt)
        //{
        //    return _service.Insert(excerpt);
        //}

        [HttpPost]
        public void Post([FromBody]IEnumerable<Excerpt> excerpts)
        {
            _service.BulkInsert(excerpts?.Select(e => { e.Id = _idGenerator.NextId(); return e; }));
        }

        private string[][] FakeVerses = new[]
        {
            new string[]{"海内存知己","天涯若比邻" },
            new string[]{"会当凌绝顶","一览众山小" },
            new string[]{"人生若只如初见","何事秋风悲画扇" },
        };
    }

    public class ExcerptViewModel
    {
        public DateTime Date { get; set; }
        public int Day { get; set; }
        public string Week { get; set; }
        public string AnimalString { get; set; }
        public string Holiday { get; set; }
        public GanZhiDate GanZhiDate { get; set; }
        public Verse Verse { get; set; }
    }

    public class GanZhiDate
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }

    public class Verse
    {
        public string[] Contents { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
    }
}
