using Employee_UI.Model;

namespace Employee_UI.Integrations
{
    public interface IEmployeeApiClient
    {
        Task<bool> AddEmployee(Employee employee);

        Task<List<Employee>> GetAllEmployees();
    }
}
