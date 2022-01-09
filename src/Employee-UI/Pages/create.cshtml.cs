using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Employee_UI.Integrations;
using Employee_UI.Model;

namespace Employee_UI.Pages
{
    public class createModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        private readonly ILogger<createModel> _logger;
        private readonly IEmployeeApiClient _employeeApiClient;

        public createModel(ILogger<createModel> logger, IEmployeeApiClient empApiClient)
        {
            _logger = logger;
            _employeeApiClient = empApiClient;
        }

        public void OnGet()
        {
        
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Employee.Id = String.Empty;
                    var result = await _employeeApiClient.AddEmployee(Employee);
                    _logger.LogInformation($"api response AddPerson : { result}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error OnPost : {ex} ");
            }

            return RedirectToPage("Index");
        }
    }
}
