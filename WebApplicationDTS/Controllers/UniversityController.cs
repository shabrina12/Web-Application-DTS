using Microsoft.AspNetCore.Mvc;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _universityRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //untuk menghindari serangan XSS Scripting
        public IActionResult Create(University university)
        {
            _universityRepository.Insert(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(University university)
        {
            _universityRepository.Update(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity); //View untuk method Get aja, Post ga perlu view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _universityRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
