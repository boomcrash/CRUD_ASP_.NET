using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Models;
using CRUDCORE.Datos;
using System.Collections.Generic;
using System;


//MantenedorController.cs
namespace CRUDCORE.Controllers
{

    public class MantenedorController : Controller
    {

        ContactoDatos contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            List<ContactoModel> lista = contactoDatos.Listar();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar( ContactoModel contacto)
        {
            if(ModelState.IsValid)
            {
                if (contactoDatos.Guardar(contacto))
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

            
        }

        //editar
        public IActionResult Editar(int IdContacto)
        {
            ContactoModel contacto = contactoDatos.Obtener(IdContacto);
            return View(contacto);
        }

        [HttpPost]
         public IActionResult Editar( ContactoModel contacto)
        {
            if(ModelState.IsValid)
            {
                if (contactoDatos.Editar(contacto))
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

            
        }
        


        public IActionResult Eliminar(int IdContacto)
        {
            ContactoModel contacto = contactoDatos.Obtener(IdContacto);
            return View(contacto);
        }

        [HttpPost]
         public IActionResult Eliminar( ContactoModel contacto)
        {
            int id=Convert.ToInt32(contacto.IdContacto);

            if (contactoDatos.Eliminar(id))
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }   
        }
    }
}