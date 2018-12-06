using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDAE2.Areas.General.Services;
using AppDAE2.Models;

namespace AppDAE2.Areas.General.Controllers
{
    [Area("General")]
    public class FicCatEdificiosController : Controller
    {
        FicSrcCatEdificiosList FicService;
        List<eva_cat_edificios> FicLista;
        eva_cat_edificios edi;

        public FicCatEdificiosController() {
            FicService = new FicSrcCatEdificiosList();
        }
        //Lista Edificio-------------------------------------------
        public IActionResult FicViCatEdificiosList()
        {
            try
            {
                FicService = new FicSrcCatEdificiosList();
                FicLista = FicService.FicGetListCatEdificios().Result;
                ViewBag.Title = "Catalogo de edificios";
                return View(FicLista);
            }
            catch (Exception e) {
                throw;
            }
        }
   
        //Detalle Edificio------------------------------------------
        public IActionResult FicViCatEdificiosDetalle(int id)
        {
            try
            {
                FicService = new FicSrcCatEdificiosList();
                eva_cat_edificios FicLista = FicService.FicGetDetailCatEdificios(id).Result;
                ViewBag.Title = "Detalle de edificios";
                return View(FicLista);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Editar edificio
        public IActionResult FicViCatEdificiosUpdate(short id)
        {
            try
            {
                FicService = new FicSrcCatEdificiosList();
                edi = FicService.FicGetDetailCatEdificios(id).Result;
                ViewBag.Title = "Editar Edificio";
                return View(edi);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult FicViCatEdificiosUpdate(eva_cat_edificios edificio)
        {
            FicService.FicCatEdificiosUpdate(edificio).Wait();
            return RedirectToAction("FicViCatEdificiosList");
        }

        //Nuevo Edificio 
        public ActionResult FicViCatEificiosAdd()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult FicViCatEificiosAdd(eva_cat_edificios ed)
        {
            FicService.FicCatEdificiosCreate(ed).Wait();
            return RedirectToAction("FicViCatEdificiosList");
        }

        //Eliminar Edificio----------------------------------------- 
        public ActionResult FicViCatEdificiosDelete(short id)
        {
            if (id != null)
            {
                FicService.FicCatEdificiosDelete(id).Wait();
                return RedirectToAction("FicViCatEdificiosList");
            }
            return null;
        }

    }
}