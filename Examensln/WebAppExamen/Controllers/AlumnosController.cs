using Entyties.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppExamen.Services.IServices;

namespace WebAppExamen.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly IAlumnosServices _alumnosServices;
        public AlumnosController(IAlumnosServices alumnosServices)
        {
            _alumnosServices=alumnosServices;
        }
        // GET: AlumnosController
        public ActionResult Index()
        {
            var lista = _alumnosServices.FindAllAlumnos();

            return View(lista);
        }

        [HttpGet]
        public ActionResult AlumnosIndex()
        {
            var lista = _alumnosServices.FindAllAlumnos() .Result;

            return View(lista);

        }

        // GET: AlumnosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlumnosController/Create
        public ActionResult Create()
        {
            AlumnoDto alumno = new AlumnoDto()
            {
                Amaterno = "hernandez",
                Apaterno = "Zapata",
                Nombre = "Sori"
            };
            var res = _alumnosServices.CreateAlumnos(alumno);
            return View(res);
        }

        // POST: AlumnosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlumnosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlumnosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
