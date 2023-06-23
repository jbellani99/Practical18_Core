using Practical18_Core.Models;
using Practical18_Core.ViewModel;

namespace Practical18_Core.Infrastructure
{
    public interface IEmployee
    {
        List<EmployeeViewModel> GetAll();

        EmployeeViewModel GetById(int id);
        void EmployeeAdd(EmployeeViewModel employee);
        void Update(EmployeeViewModel employee);
        void Remove(int? id);
    }
}
