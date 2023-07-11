using Microsoft.AspNetCore.Mvc;
using RentCars.Models;
using System.Collections.Generic;

namespace RentCars.Controllers
{
    public class CarController : Controller
    {
        DatabaseContext dbcontext=new DatabaseContext();
        public IActionResult Index(string sortField, string currentSortField, string sortDirection,string searchbyname)
        {
            var cars = GetCars();
            if(!string.IsNullOrEmpty(searchbyname))
                cars = cars.Where( e => e.Type.ToLower().Contains(searchbyname.ToLower())).ToList();
            return View(this.SortCars(cars, sortField, currentSortField, sortDirection));
           
        }

        private List<Car> GetCars()
        {
            List<Car> carss = dbcontext.Cars.ToList();
            return carss;
        }

        public IActionResult create()
        {
            //ViewBag.Departmentes = this.dbcontext.Departments.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult create(Car model)
        {
            ModelState.Remove("Price");
            ModelState.Remove("CarId");
            ModelState.Remove("Car");
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                dbcontext.Cars.Add(model);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Departmentes = this.dbcontext.Departments.ToList();
            return View();

        }



        public IActionResult edit(int ID)
        {

            Car data = this.dbcontext.Cars.Where(e => e.CarId == ID).FirstOrDefault();
            //ViewBag.Departmentes = this.dbcontext.Departments.ToList();
            return View("create", data);
        }


        [HttpPost]
        public IActionResult Edit(Car model)
        {

            ModelState.Remove("Price");
            ModelState.Remove("CarIdCarId");
            ModelState.Remove("Client");
            ModelState.Remove("Car");
            if (ModelState.IsValid)
            {
                dbcontext.Cars.Update(model);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View("create", model);

        }



        public IActionResult Delete(int ID)
        {
            Car data = this.dbcontext.Cars.Where(e => e.CarId == ID).FirstOrDefault();
            if (data != null)
            {
                dbcontext.Cars.Remove(data);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        private List<Car> SortCars(List<Car> cars, string sortField, string currentSortField, string sortDirection)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.sortField = "Type";
                ViewBag.sortDirection = "ASC";

            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.sortDirection = sortDirection == "Asc" ? "Desc" : "Asc";
                else
                    ViewBag.sortDirection = "Asc";
                ViewBag.sortField = sortField;
            }
            var propertyInfo = typeof(Car).GetProperty(ViewBag.sortField);
            if (ViewBag.sortDirection == "Asc")
                cars = cars.OrderBy(e => propertyInfo.GetValue(e, null)).ToList();
            else
                cars = cars.OrderByDescending(e => propertyInfo.GetValue(e, null)).ToList();
            return cars;
        }
    }
}
