using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SuperHero.Data;
using SuperHero.Models;
using SuperHero.Models.Entities;

namespace SuperHero.Controllers
{    // localhost:xxxx/api/name_of_controller
    [Route("api/[controller]")]   // it is going to access from api/controller_name route by using route it automatically maps the name_of controller
    [ApiController]  //  attribute

    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        //inject Db in controller  using constructor injection

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]      // Reading all employee data
        //action method

        public IActionResult GetAllEmployees()
        {
           var allEmployees =dbContext.Employees.ToList();
            return Ok(allEmployees);// return 200 http msg response
        }


        [HttpGet]
        [Route("{id:guid}")]

        //map id as parameter
        //it wants id to that employee as its route on that 
        //it accepts identifier in curly braces inside route

        public IActionResult GetEmployeeById(Guid id)
        {
           var employee= dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }

            return Ok(employee);


        }

        // Modify existing data ---- post method // create new employee

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeedto addEmployeedto) 
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeedto.Name,
                Email = addEmployeedto.Email,
                Description = addEmployeedto.Description,
                Phone = addEmployeedto.Phone,
                Salary = addEmployeedto.Salary


            };

            dbContext.Employees.Add(employeeEntity);   // This method needs entity employee type but we have AddEmployeedto so convert it to entity
                                                       // ef wants us to save changes
            dbContext.SaveChanges();


            return Ok(employeeEntity);


          
        }

        [HttpPut]

        public IActionResult UpdateEmployee(Guid id,UpdateEmployeedto updateEmployeedto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeedto.Name;
            employee.Email = updateEmployeedto.Email;
            employee.Phone = updateEmployeedto.Phone;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]


       public  IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();


            return Ok();

        }
       



    }
}
