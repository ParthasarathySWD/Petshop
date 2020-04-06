using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Petshop.Models;

namespace Petshop.Controllers
{
    public class PetsController : Controller
    {

        private PetsDBContext db = new PetsDBContext();

        //IList<Pets> pets = new List<Pets> {
        //                        new Pets() { PetUID = 1, PetName = "Cats" },
        //                        new Pets() { PetUID = 1, PetName = "Dogs" },
        //                        new Pets() { PetUID = 1, PetName = "Reptiles" },
        //                };

        // GET: Pets
        public ActionResult Index()
        {
            var pets = from p in db.Pets
                       orderby p.PetUID
                       select p;
            return View(pets);
        }

        // GET: Pets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        public ActionResult Create(Pets pet)
        {
            try
            {
                // TODO: Add insert logic here
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int Id)
        {
            var pet = db.Pets.Where(p => p.PetUID == Id).FirstOrDefault();
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        public ActionResult Edit(int PetUID, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var pet = db.Pets.Single(p => p.PetUID == PetUID);
                if(TryUpdateModel(pet))
                {
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var pet = db.Pets.Single(p => p.PetUID == PetUID);
                return View(pet);
            }
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
