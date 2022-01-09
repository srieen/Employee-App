using Employee_API.Model;

namespace Employee_API.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployee(Employee employee, string correlationId, CancellationToken cancellationToken);

        Task<List<Employee>> GetAllEmployee(string correlationId, CancellationToken cancellationToken);
    }
}