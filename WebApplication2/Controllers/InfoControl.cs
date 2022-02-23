using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : Controller
    {
        SqlOperation operation = new SqlOperation();
        private readonly ILogger<FilterController> _logger;

        public FilterController(ILogger<FilterController> logger)
        {
            _logger = logger;
        }
        [HttpGet("Filter by Date")]
        public IEnumerable<Info> GetByDate(DateTime date)
        {
            return operation.FilterByDate(date);
        }
        [HttpGet("Filter by Cost")]
        public IEnumerable<Info> GetByCost(int from, int to)
        {
            return operation.FilterByCost(from, to);
        }
        [HttpGet("Filter by Category")]
        public IEnumerable<Info> GetByCategory(string categoryName)
        {
            return operation.FilterByCategory(categoryName);
        }
    }
}