using Employee_UI.Model;

namespace Employee_UI.Integrations
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _client;

        public EmployeeApiClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _client.BaseAddress = new Uri(config.GetValue<string>("EmployeeAPIUrl"));
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            bool success = false;   
            var response = await _client.PostAsJsonAsync("api/employee", employee);

            if (response.IsSuccessStatusCode)
            {
                success =  await response.Content.ReadFromJsonAsync<bool>();
            }
            return success; 
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
           return await _client.GetFromJsonAsync<List<Employee>>("api/employee");
        }
    }
}
