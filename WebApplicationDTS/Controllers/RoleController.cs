using Microsoft.AspNetCore.Mvc;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _roleRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //untuk menghindari serangan XSS Scripting
        public IActionResult Create(Role role)
        {
            _roleRepository.Insert(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role)
        {
            _roleRepository.Update(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity); //View untuk method Get aja, Post ga perlu view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
