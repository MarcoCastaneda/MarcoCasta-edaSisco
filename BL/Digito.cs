using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Digito
    {
        public static ML.Result Add(ML.Digito digito)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.MarcoCastañedaGrupoSicossContext context = new DL.MarcoCastañedaGrupoSicossContext())
                // using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var query = context.Database.ExecuteSqlRaw($"DigitoAdd {digito.Numero},'{digito.Resultado}','{digito.Fecha}',{digito.IdUsuario}");
                    // string query = "UsuarioAdd";
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {


                result.Correct = false;
                result.Error = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result GetAll(ML.Digito digito)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarcoCastañedaGrupoSicossContext context = new DL.MarcoCastañedaGrupoSicossContext())
                {
                    var query = context.Digitos.FromSqlRaw($"DigitoGetAll {digito.IdUsuario}").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {


                            digito = new ML.Digito();

                            digito.IdDigito = obj.IdDigito;
                            digito.Numero = obj.Numero.Value;
                            digito.Resultado = obj.Resultado.Value;
                            digito.Fecha = obj.Fecha.ToString();




                            result.Objects.Add(digito);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Error = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Digito digito)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarcoCastañedaGrupoSicossContext context = new DL.MarcoCastañedaGrupoSicossContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DigitoDelete {digito.IdDigito}");

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Error = "No se ha podido realizar el delete";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Error = ex.Message;
            }
            return result;
        }

        public static ML.Result Calculo(ML.Digito digito)
        {
            ML.Result result = new ML.Result();






           
            
            return result;



        }

    }

}