using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace MVClab3.Views.Employee.Components.LeftNavigation
{
    public class LeftNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Define the links here
            var links = new List<LeftNavigationLink>
        {
            new LeftNavigationLink { Text = "Home", Controller = "Home", Action = "Index" },
            new LeftNavigationLink { Text = "Employees", Controller = "Employee", Action = "Index" },
            new LeftNavigationLink { Text = "Privacy", Controller = "Home", Action = "Privacy" }
        };

            return View(links);
        }
    }
    public class LeftNavigationLink
    {
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}

