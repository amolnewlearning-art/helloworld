
using Microsoft.AspNetCore.Mvc;
using System;

namespace helloworld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        [HttpGet("current-time")]
        public IActionResult GetCurrentTime()
        {
            var now = DateTime.UtcNow;
            var times = new
            {
                UTC = now.ToString("yyyy-MM-dd HH:mm:ss"),
                CET = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")).ToString("yyyy-MM-dd HH:mm:ss"),
                IST = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString("yyyy-MM-dd HH:mm:ss"),
                EST = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).ToString("yyyy-MM-dd HH:mm:ss")
            };
            return Ok(times);
        }
    }
}
