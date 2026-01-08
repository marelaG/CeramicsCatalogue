using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GancewskaKerebinska.CeramicsCatalogue.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly CeramicService _service;
        private readonly ProducerService _producerService;

        public ProductController(CeramicService service, ProducerService producerService)
        {
            _service = service;
            _producerService = producerService;
        }

        public IActionResult Index(string searchString, int? producerId)
        {
            var products = _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = _service.Search(searchString);
            }
            else if (producerId.HasValue)
            {
                products = _service.GetByProducer(producerId.Value);
            }

            // Pass the selected value (producerId) to the SelectList constructor
            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "Name", producerId);
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CeramicItemDo item)
        {
            ModelState.Remove("Producer");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "Name", item.ProducerId);
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (item == null) return NotFound();

            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "Name", item.ProducerId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CeramicItemDo item)
        {
            if (id != item.Id) return NotFound();

            ModelState.Remove("Producer");
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Producers = new SelectList(_producerService.GetAll(), "Id", "Name", item.ProducerId);
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetAll().FirstOrDefault(p => p.Id == id);
            if (item == null) return NotFound();
            return View(item);
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
