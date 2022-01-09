using Employee_UI.Integrations;
using Employee_UI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Employee> EmployeeList = new List<Employee>();
        public string Message { get; private set; } = "Page models in C#";
        private readonly IEmployeeApiClient _employeeApiClient;

        public IndexModel(ILogger<IndexModel> logger, IEmployeeApiClient empApiClient)
        {
            _logger = logger;
            _employeeApiClient = empApiClient;
        }

        public async Task OnGet()
        {
            try
            {
                Message = $"Server Time : {DateTime.Now}";
                var response = await _employeeApiClient.GetAllEmployees();
                _logger.LogInformation($"api response  GetAllEmployees count : { response.Count}");
                EmployeeList = response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error onGet : {ex} ");
            }
        }

    }
}