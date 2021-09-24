using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using holidays_web_api.Models;

namespace holidays_web_api.Services
{
     public class HolidayService : IHolidayService
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _clientFactory;
        public HolidayService(HttpClient client)
        {
            _client = client;
            client.Timeout = Timeout.InfiniteTimeSpan;
        }

        public  HolidayService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = clientFactory.CreateClient("PublicHolidaysApi");
        }
        public async Task <List<Holiday>> GetHolidays(string country,int year)
        {
            string url = string.Format($"/holidays?accesskey=MT_ACCESS_KEY&secretkey=MY_SECRET_KEY&version=3&country={country}&year={year}&lang=en");
            var result = new List < Holiday > ();
            // var client = new HttpClient();

            using var cts = new CancellationTokenSource(Timeout.InfiniteTimeSpan);

            var response = await _client.GetAsync(url, cts.Token).ConfigureAwait(false); // this line takes to run more than 5mins

            if (response.IsSuccessStatusCode) {

                var responseStream = await response.Content.ReadAsStringAsync();
                var tempresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseStream);
                result = tempresult.holidays;

            } else {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }


      public async Task <List<Holiday>> GetHolidayType(string country,int year)  
        {
            string url = string.Format($"/holidays?accesskey=dYjG8ztthf&secretkey=veUV06dNmrnp7bbaYq0u&version=3&country={country}&year={year}&lang=en");
            var result = new List < Holiday > ();
            // var client = new HttpClient();

            using var cts = new CancellationTokenSource(Timeout.InfiniteTimeSpan);

            var response = await _client.GetAsync(url, cts.Token).ConfigureAwait(false);

            if (response.IsSuccessStatusCode) {

                var responseStream = await response.Content.ReadAsStringAsync();
                var tempresult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseStream);
                result = tempresult.holidays;

            } else {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
      
    }
}