using MVClab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVClab3.Controllers
{
    public class EmployeeController : Controller
    {
        [BindProperty]
        public Employee _employee { get; set; }

        List<Employee> employees = new();
        public EmployeeController()
        {
            employees = new List<Employee>
            {
                new Employee
                {
                 Id = 0, Name = "Martin", Surname = "Simpson",
                 BirthDate = new DateTime(1992, 12, 3),
                 Position = "Marketing Expert", Image="/images/Martin.jpg"
                },
                new Employee
                {
                 Id = 1, Name = "Jacob", Surname = "Hawk",
                 BirthDate = new DateTime(1995, 10, 2), Position = "Manager", Image="/images/Jacob.jpg"
                },
                new Employee
                {
                 Id = 2, Name = "Elizabeth", Surname = "Geil",
                 BirthDate = new DateTime(2000, 1, 7),
                 Position = "Software Engineer", Image="/images/Elizabeth.jpg"
                },
                new Employee
                {
                Id = 3, Name = "Kate", Surname =  "Metain",
                BirthDate = new DateTime(1997, 2, 13),
                Position = "Admin", Image="/images/Kate.jpg"
                },
                new Employee
                {
                Id = 4, Name = "Michael", Surname = "Cook",
                BirthDate = new DateTime(1990, 12, 25),
                Position = "Marketing expert", Image="/images/Michael.jpg"
                },
                new Employee
                {
                Id = 5, Name = "John", Surname = "Snow",
                BirthDate = new DateTime(2001, 7, 15),
                Position = "Software Engineer", Image="/images/John.jpg"
                },
                new Employee
                {
                Id = 6, Name = "Nina", Surname = "Soprano",
                BirthDate = new DateTime(1999, 9, 30),
                Position = "Software Engineer", Image="/images/Nina.jpg"
                },
               new Employee
               {
               Id = 7, Name = "Tina", Surname = "Fins",
               BirthDate = new DateTime(2000, 5, 14),
               Position = "Team Leader", Image="/images/Tina.jpg"
               }



            };
        }
        //Index
        public IActionResult Index()
        {
            // Set the layout for this action
            ViewBag.Layout = "_Lab2Layout";
            return View(employees);
        }
        //Details
        public IActionResult Details(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound(); // Handle when the employee with the given ID is not found
            }
            // Set the layout for this action
            else
            {
                ViewBag.Layout = "_Lab2Layout";
                return View(employee);

            }

        }
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(m => m.Id == id);
            return View(employee);
        }
        [Route("Employee/Edit/{id}")]
        [HttpPost]
        // Property Model Binding
        public IActionResult Edit(int id, Employee employee)
        {
            ModelState.AddModelError("Title", "This Title Already Exists.");
            return View(_employee);
        }

        public IActionResult Update(int id)
        {
            var employee = employees.FirstOrDefault(m => m.Id == id);
            return View(employee);
        }
        [Route("Edit/Employee/{id}")]
        [HttpGet]
        public IActionResult Update(int id, Employee employee)
        {
            ModelState.AddModelError("Title", "This Title Already Exists.");
            return View(_employee);
        }

    }
}
