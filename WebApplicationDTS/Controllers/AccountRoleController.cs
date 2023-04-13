using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository;
using WebApplicationDTS.Repository.Contracts;
using WebApplicationDTS.ViewModels;

namespace WebApplicationDTS.Controllers
{
    public class AccountRoleController : Controller
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleController(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _accountRoleRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var accountRoles = new List<SelectListItem>(){
            new SelectListItem{
                Text = "User",
                Value = "1",
            },
            new SelectListItem{
                Text = "Admin",
                Value = "2",
        }};
            ViewBag.RoleId = accountRoles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //untuk menghindari serangan XSS Scripting
        public IActionResult Create(AccountRole accountRole)
        {
            _accountRoleRepository.Insert(accountRole);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _accountRoleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountRole accountRole)
        {
            _accountRoleRepository.Update(accountRole);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _accountRoleRepository.GetById(id);
            return View(entity); //View untuk method Get aja, Post ga perlu view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _accountRoleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
