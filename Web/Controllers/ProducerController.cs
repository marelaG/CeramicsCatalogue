using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GancewskaKerebinska.CeramicsCatalogue.Web.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ProducerService _service;

        public ProducerController(ProducerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var producers = _service.GetAll();
            return View(producers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProducerDo producer)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    _service.Add(producer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(producer);
        }

        public IActionResult Edit(int id)
        {
            var producer = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProducerDo producer)
        {
            if (id != producer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(producer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(producer);
        }

        public IActionResult Delete(int id)
        {
            var producer = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (producer == null) return NotFound();
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
