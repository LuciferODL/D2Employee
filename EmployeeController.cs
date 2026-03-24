using D2Employee.Data;
using D2Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace D2Employee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            var data = D2Employee.Data.SeedData.Employees.Select(e => new Models.EmployeeView
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                BirthDate = e.BirthDate,
                Salary = e.Salary,
                Position = e.Position
            }).ToList();
            return View(data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = D2Employee.Data.SeedData.Employees.FirstOrDefault(e => e.EmployeeId == id);
            var EmployeeView = new Models.EmployeeView
            {
                Name = employee?.Name,
                BirthDate = employee?.BirthDate ?? DateTime.MinValue,
                Salary = employee?.Salary ?? 0,
                Position = employee?.Position
            };
            return View(EmployeeView);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(Data.SeedData.Employees, "EmployeeId", "Name");
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                //Tu dong tang id
                newEmployee.EmployeeId = Data.SeedData.Employees.Max(e => e.EmployeeId) + 1;
                //Them TT moi vao danh sach
                Data.SeedData.Employees.Add(newEmployee);
                return RedirectToAction(nameof(Index));
            }
            
            return View(newEmployee);
            
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = Data.SeedData.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.EmployeeId = new SelectList(Data.SeedData.Employees, "EmployeeId", "Name", employee.EmployeeId);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Employee editEmployee)
        {
           if (ModelState.IsValid)
            {
                var employee = Data.SeedData.Employees.FirstOrDefault(e => e.EmployeeId ==editEmployee.EmployeeId );
                if (employee == null)
                {
                    return NotFound();
                }
                employee.Name = editEmployee.Name;
                employee.BirthDate = editEmployee.BirthDate;
                employee.Salary = editEmployee.Salary;
                employee.Position = editEmployee.Position;

                return RedirectToAction(nameof(Index));
            }
           ViewBag.EmployeeId = new SelectList(Data.SeedData.Employees, "EmployeeId", "Name", editEmployee);
            return View(editEmployee);
            
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = Data.SeedData.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.EmployeeId = new SelectList(Data.SeedData.Employees, "EmployeeId", "Name", employee.EmployeeId);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var employee = Data.SeedData.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            Data.SeedData.Employees.Remove(employee);

            return RedirectToAction(nameof(Index));
            return View();
        }
        //Tim kiem theo ten NV va Ngay sinh
                public ActionResult Search(string name, DateTime? birthDate)
        {
            var data = D2Employee.Data.SeedData.Employees.Select(e => new Models.EmployeeView
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                BirthDate = e.BirthDate,
                Salary = e.Salary,
                Position = e.Position
            }).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(e => e.Name != null && e.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (birthDate.HasValue)
            {
                data = data.Where(e => e.BirthDate.Date == birthDate.Value.Date).ToList();
            }
            return View("Index", data);
        }
    }
}
