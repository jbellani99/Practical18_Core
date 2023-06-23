using AutoMapper;
using Practical18_Core.Models;
using Practical18_Core.ViewModel;

namespace Practical18_Core.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
