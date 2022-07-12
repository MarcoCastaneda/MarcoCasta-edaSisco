using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.MarcoCastañedaGrupoSicossContext context = new DL.MarcoCastañedaGrupoSicossContext())
                // using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalAdd'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}'");
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

        public static ML.Result GetByEmail(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarcoCastañedaGrupoSicossContext context = new DL.MarcoCastañedaGrupoSicossContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"GetByEmail '{email}'").AsEnumerable().FirstOrDefault();


                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;


                        result.Object = usuario;
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


    }
}