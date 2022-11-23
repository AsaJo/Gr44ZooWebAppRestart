using Gr44ZooWebApp.Models;
using Gr44ZooWebApp.Models.Repos;
using Gr44ZooWebApp.Models.Servises;
using Gr44ZooWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Gr44ZooWebApp.Controllers
{

    public class AnimalsController : Controller
    {
        private readonly IAnimalsService _animalsService;
        public AnimalsController(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }
        public IActionResult ZooPark()
        {
            return View(_animalsService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateAnimalViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateAnimalViewModel createAnimal)
        {
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _animalsService.Create(createAnimal);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("Animal & species", exception.Message);// Key And value
                    return View(createAnimal);
                }


                return RedirectToAction(nameof(ZooPark));
            }
            return View(createAnimal);
        }
        public  IActionResult Details(int id)
        {
            Animal animal = _animalsService.FindById(id);
            if(animal == null)
            {
                return RedirectToAction(nameof(ZooPark));
            }
            return View(animal);
        }

        public IActionResult Delete(int id)
        {
            Animal animal = _animalsService.FindById(id);
            if (animal!=null)
            {
                _animalsService.Remove(id);
            }
            else
            {
                return RedirectToAction(nameof(ZooPark));
            }
            return View();
        }



        //************************ Used for AJAX  ***************************************
        public IActionResult LastAnimalArrivel()
        {
        
            Animal animal = _animalsService.LastAdded();
            if(animal != null)
            {
                return PartialView("_AnimalRow", animal);
            }
            return NotFound();// for Fun 418 normal use 404 

        }
        public IActionResult LastAnimalArrivelJSON() // getLastAnimalJSON
        {
            Animal animal = _animalsService.LastAdded();
            if (animal != null)
            {
                return Json(animal);
            }
            return NotFound();//404 /418
        }
        public IActionResult AjaxAnimalList()
        {
            List<Animal> animal = _animalsService.GetAll();
            if (animal != null)
            {
                return PartialView("_AnimalList", animal);

            }
            return BadRequest();

        }
        public IActionResult AnimalDetails(int id)
        {
            Animal animal = _animalsService.FindById(id);
            if (animal != null)
            {
                return PartialView("_AnimalRow", animal);
            }
            return View(animal);
        }
        public IActionResult AnimalSpecies(string species)
        {
            List<Animal> animal = _animalsService.FindBySpecies(species);
            if (animal != null)
            {
                return PartialView("_AnimalList", animal);

            }
            return BadRequest();

        }
        public IActionResult DeleteAnimalAjax(int id)
        {
            Animal animal = _animalsService.FindById(id);
            if (animal!= null)
            {
                
                return PartialView("_AnimalList", _animalsService.GetAll());
            }
            return NotFound();
        }


    }
}
