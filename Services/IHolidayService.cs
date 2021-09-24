using System.Collections.Generic;
using System.Threading.Tasks;
using holidays_web_api.Models;

namespace holidays_web_api.Services
{
    public interface IHolidayService
    {
        Task <List<Holiday>> GetHolidays(string country,int year);

        Task <List<Holiday>> GetHolidayType(string country,int year);
    }
}
