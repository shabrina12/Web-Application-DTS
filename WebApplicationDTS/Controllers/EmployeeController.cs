using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Controllers
{
    public class EmployeeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _employeeRepository.GetAll();
            return View(entities);
        }

        //[HttpGet]
        //public IActionResult Details(string id)
        //{
        //    var entity = _employeeRepository.GetById(id);
        //    return View(entity);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var gender = new List<SelectListItem>(){
        //    new SelectListItem{
        //        Text = "Male",
        //        Value = "0",
        //    },
        //    new SelectListItem{
        //        Text = "Female",
        //        Value = "1",
        //}};
        //    ViewBag.Gender = gender;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]  //untuk menghindari serangan XSS Scripting
        //public IActionResult Create(Employee employee)
        //{
        //    _employeeRepository.Insert(employee);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Edit(string id)
        //{
        //    var entity = _employeeRepository.GetById(id);
        //    return View(entity);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Employee employee)
        //{
        //    _employeeRepository.Update(employee);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Delete(string id)
        //{
        //    var entity = _employeeRepository.GetById(id);
        //    return View(entity); //View untuk method Get aja, Post ga perlu view
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Remove(string id)
        //{
        //    _employeeRepository.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
