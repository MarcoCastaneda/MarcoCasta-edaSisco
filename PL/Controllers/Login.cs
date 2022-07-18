using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace PL.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetByEmail(email);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (usuario.Email == email && usuario.Password == password)
                {
                    return RedirectToAction("GetAll", "Digito", new { IdUsuario = usuario.IdUsuario });
                   
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
    }
}