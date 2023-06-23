using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practical18_Core.Infrastructure;
using Practical18_Core.Models;
using Practical18_Core.ViewModel;
using System;

namespace Practical18_Core.Repository
{
    public class Employeerepo : IEmployee
    {

        private readonly EmpContext _empContext;
        private readonly IMapper mapper;

        public Employeerepo(EmpContext empContext, IMapper mapper)
        {
            _empContext = empContext;
            this.mapper = mapper;
        }
    
        public void EmployeeAdd(EmployeeViewModel employee)
        {
            var emp = mapper.Map<EmployeeViewModel, Employee>(employee);
            _empContext.employees.Add(emp);
            _empContext.SaveChanges();
        }

        public List<EmployeeViewModel> GetAll()
        {
            var empList = mapper.Map<List<Employee>, List<EmployeeViewModel>>(_empContext.employees.ToList());
            return empList ;
        }

        public EmployeeViewModel GetById(int id)
        {
            var emp =  _empContext.employees.FirstOrDefault(x => x.id == id);
            var empModel = mapper.Map<Employee, EmployeeViewModel>(emp);
            return empModel;
        }

        public void Remove(int? id)
        {
            var stud = _empContext.employees.Find(id);
            _empContext.employees.Remove(stud);
            _empContext.SaveChanges();
        }

        public void Update(EmployeeViewModel employee)
        {
            var emp = mapper.Map<EmployeeViewModel, Employee>(employee);
            _empContext.Entry(emp).State = EntityState.Modified;
            _empContext.SaveChanges();
        }
    }
}
