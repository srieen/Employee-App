using Employee_API.Interfaces;
using Employee_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public ILogger<EmployeeController> _logger { get; }

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;

            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<ActionResult<Employee>> GetAllEmployee(CancellationToken cancellationToken)
        {
            string correlationId = Guid.NewGuid().ToString();
            try
            {
                var employeesList = await _employeeRepository.GetAllEmployee(correlationId, cancellationToken);

                _logger.LogInformation($"Get All Employee response : {JsonSerializer.Serialize(employeesList)}");

                return Ok(employeesList);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error on GetAllEmployee : {ex} CorrelationId : {correlationId}");
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee, CancellationToken cancellationToken)
        {
            string correlationId = Guid.NewGuid().ToString();

            try
            {
                string gId = Guid.NewGuid().ToString();

                employee.Id = gId.ToString();

                var result = await _employeeRepository.AddEmployee(employee, correlationId, cancellationToken);

                _logger.LogInformation($"Add AddEmployee response : {gId}");

                return Ok(gId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error on AddEmployee : {ex} CorrelationId : {correlationId}");
                return StatusCode(500, ex.Message);
            }

        }


    }
}
