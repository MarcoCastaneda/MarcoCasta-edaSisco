﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Usuario : Controller
    {

        
        [HttpGet]
        public ActionResult Form(int? Idusuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            if (Idusuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = new ML.Result();
                //result = BL.Usuario.GetById(Idusuario.Value);

                if (result.Correct)
                {
                    usuario = ((ML.Usuario)result.Object);
                }

            }
            return View(usuario);
        }



        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();




            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);


                if (result.Correct)
                {

                    LoginController email = new LoginController();




                    ViewBag.Mensaje = "Registro Exitoso";
                }
                else
                {
                    ViewBag.Mensaje = "Error al hacer registro intentelo mas tarde";
                }
            }
            else
            {
                //result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "El usuario se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.Error;
                }
            }



            return PartialView("Modal");
        }
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.Delete(usuario);



            if (result.Correct)
            {
                ViewBag.IdUsuario = IdUsuario;
                ViewBag.Mensaje = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.Mensaje = "ocurrió un error al eliminar el registro " + result.Error;

            }
            return PartialView("Modal");
        }

    }
}
