using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using holidays_web_api.Models;
using holidays_web_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace holidays_web_api.Controllers
{
     [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string country, int year)
        {
           var data = await _holidayService.GetHolidays(country, year);

            return Ok(data);
        }
    }
}
