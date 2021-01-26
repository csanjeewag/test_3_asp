using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_3.IRepository;
using test_3.Models;

namespace test_3.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository ;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Student> students = _repository.GetAll();

                return View(students);
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return BadRequest();
            }
            
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Student student = _repository.GetById(id);
                return View(student);
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return BadRequest();
            }
        }

        [Authorize(Roles ="Admin")]
        // GET: StudentController/Create
        public ActionResult Create()
        {
            List<String> streams = new List<String>();
            streams.Add("Maths");
            streams.Add("Science");
            streams.Add("Commerce");
            ViewBag.streams = streams;
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection, Student model)
        {
            

            if (!ModelState.IsValid)
            {
                @TempData["errorMsg"] = "There are some misatake try again.";

                return BadRequest();
            }
            try
            {
                _repository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return View();
            }
        }

        [Authorize]     
        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Student student = _repository.GetById(id);
                return View(student);
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return BadRequest();
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Student model)
        {
            if (!ModelState.IsValid)
            {
                @TempData["errorMsg"] = "There are some misatake try again.";

                return BadRequest();
            }
            try
            {
                _repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return View();
            }
        }

        // Get: StudentController/SearchByName/sa

        public ActionResult SearchByName(string search)
        {
            try
            {
                IEnumerable<Student> students = _repository.SearchByName(search);
                return View("Index",students);
            }
            catch
            {
                @TempData["errorMsg"] = "There are some misatake try again.";
                return BadRequest();
            }
        }
    }
}
