using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.Core.Enums;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GancewskaKerebinska.CeramicsCatalogue.Web.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ProducerService _service;

        public ProducerController(ProducerService service)
        {
            _service = service;
        }

        public IActionResult Index(string searchString, Country? country)
        {
            var producers = _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                producers = _service.Search(searchString);
            }
            else if (country.HasValue)
            {
                producers = _service.GetByCountry(country.Value);
            }

            // Get only available countries for the filter
            ViewBag.AvailableCountries = _service.GetAvailableCountries();
            ViewBag.SelectedCountry = country;

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
