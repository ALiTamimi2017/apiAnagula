using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiAng.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace apiAng.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataApiContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger ,DataApiContext  context)
        {
            _logger = logger;
            _context=context;
        }

    
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
            [HttpGet]
        public async Task<IActionResult> GetValuse(){
            var valse=await _context.Valuse.ToListAsync();
        return Ok(valse);
        }

[HttpGet("{id}")]
        public async Task<IActionResult> GetValuse(int id){
            var valuses=await _context.Valuse.FirstOrDefaultAsync(x=>x.Id==id);
return  Ok(valuses);
        }
    }
}
