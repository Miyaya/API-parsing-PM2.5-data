using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Practice01.Models;
using Newtonsoft.Json;

namespace Practice01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // get open data in json string by webclient
        // static String string json = @"{'Site':'崙背','county':'雲林縣','PM25':6,'DataCreationDate':'2019-07-10 13:00','ItemUnit':'μg/m3'}"; 
        static readonly String json = new WebClient().DownloadString("https://opendata.epa.gov.tw/ws/Data/ATM00625/?$format=json");
        Data[] datas = JsonConvert.DeserializeObject<Data[]>(json);

        // GET api/values
        
        //[HttpGet]
        //public ActionResult<IEnumerable<Data>> Get()
        //{
        //    return datas;
        //}

        // GET api/values/QueryStringGet?pm25=5&county=雲林縣
        [HttpGet]
        public IEnumerable<Data> Get([FromQuery] Data dataQuery)
        {
            // request for specific data by pm2.5 and county, or only county
            // return datas.Where(el => el.county.Equals(dataQuery.county));
            if (dataQuery.County == null) return datas;
            return datas.Where(el => el.PM25 == dataQuery.PM25 && el.County.Equals(dataQuery.County));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
