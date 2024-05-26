using Fiu.Business.Exceptions;
using Fiu.Business.Services.Abstracts;
using Fiu.Core.Models;
using Fiu.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiu.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]

    public class FurnitureController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public IActionResult Index()
        {
            var furnitures = _furnitureService.GetAllFurnitures();
            return View(furnitures); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Furniture furniture)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _furnitureService.AddFurnitureAsync(furniture);
            }
            catch(ImageFileException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existFurniture = _furnitureService.GetFurniture(x => x.Id == id);

            if (existFurniture == null)
                return NotFound();

            return View(existFurniture);
        }

        [HttpPost]
        public IActionResult Update(Furniture furniture)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _furnitureService.UpdateFurniture(furniture.Id, furniture);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileeNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existFurniture = _furnitureService.GetFurniture(x => x.Id == id);

            if(existFurniture == null)
                return NotFound();

            return View(existFurniture);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _furnitureService.DeleteFurniture(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileeNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }


    }
}
