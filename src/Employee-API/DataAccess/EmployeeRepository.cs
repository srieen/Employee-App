using Employee_API.Interfaces;
using Employee_API.Model;

namespace Employee_API.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private static List<Employee> _employeesList = new List<Employee>();  

        public async Task<bool> AddEmployee(Employee person, string correlationId, CancellationToken cancellationToken)
        {
            person.CreatedDate = DateTime.Now;
            person.ModifiedDate = DateTime.Now;

            _employeesList.Add(person);     

            return await Task.FromResult(true);
        }

        public async Task<List<Employee>> GetAllEmployee(string correlationId, CancellationToken cancellationToken)
        {
            var a = _employeesList.OrderByDescending( d => d.CreatedDate ).ToList();

            return await Task.FromResult(a);
        }

    }
}
