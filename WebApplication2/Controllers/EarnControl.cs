using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : ControllerBase
    {
        SqlOperation operation = new SqlOperation();
        private readonly ILogger<ManagementController> _logger;

        public ManagementController(ILogger<ManagementController> logger)
        {
            _logger = logger;
        }
        [HttpPut("Add Income")]
        public StatusCodeResult PutIncome(int count, string categoryName)
        {
            if (operation.AddIncome(count, categoryName))
                return StatusCode(200);

            return StatusCode(500);
        }
        [HttpPut("Add Expense")]
        public StatusCodeResult PutExpense(int count, string categoryName)
        {
            if (operation.AddIncome(count, categoryName))
                return StatusCode(200);

            return StatusCode(500);
        }
    }
}