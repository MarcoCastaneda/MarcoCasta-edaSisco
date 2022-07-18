using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Digito : Controller
    {

            [HttpGet]
            public ActionResult GetAll(int IdUsuario, int Numero, int Resultado)
            {

                
                ML.Digito digito = new ML.Digito();
                digito.IdUsuario = IdUsuario;
                digito.Numero = Numero;
                digito.Resultado = Resultado;

                ML.Result result = BL.Digito.GetAll(digito);

                digito.Digitos = result.Objects;
                digito.IdUsuario = IdUsuario;

                return View(digito);
            }

        

          
            

            [HttpPost]
            public ActionResult Form(ML.Digito digito, int IdUsuario)
            {
                ML.Result result = new ML.Result();

                

                if (digito.IdDigito == 0)
                {

                result = BL.Digito.Calculo(digito);

                String numeros = digito.Numero.ToString();
                char[] arrayNumeros = numeros.ToCharArray();

                digito.Resultado = 0;

                
                    

                    foreach (char numero in arrayNumeros)
                    {

                        digito.Resultado += int.Parse(numero.ToString());

                    }
                    arrayNumeros = digito.Resultado.ToString().ToArray();

                    for (int i = 0; arrayNumeros.Length > 1; i++)
                    {

                     String numeros2 = digito.Resultado.ToString();
                     char[] arrayNumeros2 = numeros2.ToCharArray();

                    digito.Resultado = 0;

                    foreach (char numero2 in arrayNumeros2)
                    {

                        digito.Resultado += int.Parse(numero2.ToString());

                        arrayNumeros = digito.Resultado.ToString().ToArray();
                    }

                    }
                
                  
                
                
                
               



               
                    result = BL.Digito.Add(digito);


                    if (result.Correct)
                    {




                        ViewBag.IdUsuario = IdUsuario;
                        
                        
                        ViewBag.Mensaje = "El usuario se ha agregado";
                        
                    }
                    else
                    {
                        ViewBag.Mensaje = "El usuario no se ha agregado";
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



                     return RedirectToAction("GetAll", "Digito", new { IdUsuario = IdUsuario, Numero = digito.Numero, Resultado = digito.Resultado });
            }

        public ActionResult Delete(int IdDigito, int IdUsuario)
        {
            ML.Digito digito = new ML.Digito();
            digito.IdDigito = IdDigito;
            ML.Result result = BL.Digito.Delete(digito);



            if (result.Correct)

            {
                

                ViewBag.Mensaje = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.Error;

            }
            return RedirectToAction("GetAll", "Digito", new { IdUsuario = IdUsuario });
        }




    }
    }
