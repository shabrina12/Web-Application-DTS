using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using NuGet.Protocol.Core.Types;
using WebApplicationDTS.Repository;
using WebApplicationDTS.Repository.Contracts;
using WebApplicationDTS.ViewModels;

namespace WebApplicationDTS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
        }

        // GET ALL DATA
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _accountRepository.GetAll();
            return View(entities);
        }

        // GET - Register
        public IActionResult Register()
        {
            var gender = new List<SelectListItem>(){
            new SelectListItem{
                Text = "Male",
                Value = "0",
            },
            new SelectListItem{
                Text = "Female",
                Value = "1",
        }};

            ViewBag.Gender = gender;

            return View();
        }

        // POST - Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.Register(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET - Login
        public IActionResult Login()
        {
            return View();
        }

	    // POST - Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            var result = _accountRepository.Login(loginVM);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Email atau Password tidak terdaftar!");
                return View();
            }
            var getFullName = _employeeRepository.GetFullName(loginVM.Email);
            HttpContext.Session.SetString("FullName", getFullName);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(string id)
        {
            var entity = _accountRepository.GetById(id);
            return View(entity); //View untuk method Get aja, Post ga perlu view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string id)
        {
            _accountRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
