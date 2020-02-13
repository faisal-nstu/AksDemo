using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AksDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoodForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Cheerful", "Bored", "Tired", "Melancholic", "Angry", "Thoughtful"
        };

        private readonly ILogger<MoodForecastController> _logger;

        public MoodForecastController(ILogger<MoodForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MoodForeCast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 7).Select(index => new MoodForeCast
            {
                Date = DateTime.Now.AddDays(index),
                HeartBeat = rng.Next(65, 90),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
