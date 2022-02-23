using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        SqlOperation operation = new SqlOperation();
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }
        [HttpGet("Get Categories")]
        public IEnumerable<string> Get()
        {
            return operation.GetCategories();
        }
        [HttpPut("Add Category")]
        public StatusCodeResult Put(string name)
        {
            if (operation.AddCategory(name))
                return StatusCode(200);

            return StatusCode(500);
        }
        [HttpDelete("Delete Category")]
        public StatusCodeResult Delete(string name)
        {
            if (operation.DeleteCategory(name))
                return StatusCode(200);

            return StatusCode(500);
        }
    }
}