using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices;

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

            string cetId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Central European Standard Time" : "Europe/Berlin";
            string istId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "India Standard Time" : "Asia/Kolkata";
            string estId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Eastern Standard Time" : "America/New_York";

            var times = new
            {
                UTC = now.ToString("yyyy-MM-dd HH:mm:ss"),
                CET = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById(cetId)).ToString("yyyy-MM-dd HH:mm:ss"),
                IST = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById(istId)).ToString("yyyy-MM-dd HH:mm:ss"),
                EST = TimeZoneInfo.ConvertTimeFromUtc(now, TimeZoneInfo.FindSystemTimeZoneById(estId)).ToString("yyyy-MM-dd HH:mm:ss")
            };
            return Ok(times);
        }
    }
}
