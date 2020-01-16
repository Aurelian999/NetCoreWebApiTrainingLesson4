using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Core.Entities;
using StudentsAPIClient.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAPIClient.Controllers
{
    [Route("clientapi/[controller]")]
    [ApiController]
    public class StudentsStatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StudentsStatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public Task<IEnumerable<Statistic>> Get([FromQuery]string orderBy)
        {
            return statisticsService.Get(orderBy);
        }

    }
}
