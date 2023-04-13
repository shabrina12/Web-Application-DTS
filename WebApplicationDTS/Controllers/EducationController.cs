using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDTS.Models;
using WebApplicationDTS.Repository.Contracts;

namespace WebApplicationDTS.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        public IActionResult Index()
        {
            var entities = _educationRepository.GetAll();
            return View(entities);
        }

        public IActionResult Create()
        {
            var universities = _universityRepository.GetAll();
            var selectListUniverities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniverities;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _educationRepository.Insert(education);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var universities = _universityRepository.GetAll();
            var selectListUniverities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            ViewBag.UniversityId = selectListUniverities;
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            _educationRepository.Update(education);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }
    }
}
