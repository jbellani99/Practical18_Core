using Microsoft.AspNetCore.Mvc;
using Practical18_Core.Infrastructure;
using Practical18_Core.Models;
using Practical18_Core.ViewModel;

namespace Practical18_Core.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {


        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployee _repo;
        private readonly EmpContext _empContext;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployee repostiory) {

            _logger = logger;
            _repo = repostiory;
        }

        public IEnumerable<EmployeeViewModel> Index()
        {
            var item = _repo.GetAll();
            return item;
        }

        [HttpGet("{id}")]
        public EmployeeViewModel Details(int id)
        {
            var item = _repo.GetById(id);
            return item;
        }


        [HttpPost]
        public void Create(EmployeeViewModel employee)
        {
            _repo.EmployeeAdd(employee);

        }



        [HttpPut]
        public EmployeeViewModel Edit(EmployeeViewModel employee)
        {

            if (ModelState.IsValid)
            {

                _repo.Update(employee);
                return employee;
            }
            return employee;
        }

        [HttpDelete("{id}")]
        public void  DeleteConfirmed(int id)
        {
            _repo.Remove(id);
          
        }
    }
}
