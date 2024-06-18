using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sigSG.DataLayer.DataContext;
using sigSG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.DataLayer.Repositories
{
    public class LoginRepository : ILoginRepository<User>
    {
        private readonly AplicationDbContext _dbcontext;

        public LoginRepository(AplicationDbContext aplicationDbContext)
        {
            _dbcontext = aplicationDbContext;
        }
        
        public async Task<User> ObtenerPorLogin(string usuario, string clave)
        {
            User response = new User();

            //if (usuario == "dsantana" && clave == "1")
            //{
            //    response.Usuario = "dsantana";
            //    response.Nombre1 = "Dan";
            //    response.Nombre2 = "";
            //    response.Apellido1 = "Santana";
            //    response.Apellido2 = "";
            //    response.Rut = "";
            //    response.Email = "";
            //    response.Sexo = "M";
            //    response.IdEstado = 1;
            //    response.IdPerfil = 1;
            //    response.Empresa = "KGHM";
            //}

            using (SqlConnection sql = new SqlConnection(_dbcontext.Database.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_LOGINUSAURIO_Obtener", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                    cmd.Parameters.Add(new SqlParameter("@clave", clave));
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Usuario = reader["USUARIO"].ToString();
                            response.Nombre1 = reader["NOMBRE1"].ToString();
                            response.Nombre2 = reader["NOMBRE2"].ToString();
                            response.Apellido1 = reader["APELLIDO1"].ToString();
                            response.Apellido2 = reader["APELLIDO2"].ToString();
                            response.Rut = reader["RUT"].ToString();
                            response.Email = reader["EMAIL"].ToString();
                            response.Sexo = reader["SEXO"].ToString();
                            response.IdPerfil = (int)reader["IDPERFIL"];
                            response.Empresa = reader["EMPRESA"].ToString();
                        }
                    }
                }
            }

            return response;
        }
    }
}
