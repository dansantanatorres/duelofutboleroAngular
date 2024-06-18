using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using sigSG.DataLayer.DataContext;
using sigSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.DataLayer.Repositories
{
    public class UsuarioRepository : IGenericRepository<User>
    {
        private readonly AplicationDbContext _dbcontext;

        public UsuarioRepository(AplicationDbContext aplicationDbContext)
        {
            _dbcontext = aplicationDbContext;
        }
        public async Task<bool> Actualizar(User modelo)
        {
            _dbcontext.Users.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Eliminar(int id)
        //{
        //    User user = _dbcontext.Users.First(c => c.Id == id);
        //    _dbcontext.Users.Remove(user);
        //    await _dbcontext.SaveChangesAsync();
        //    return true;
        //}

        public async Task<bool> Insertar(User modelo)
        {
            _dbcontext.Users.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<User> Obtener(int id)
        {
            return await _dbcontext.Users.FindAsync(id);
        }

        public async Task<IQueryable<User>> ObtenerTodos()
        {
            IQueryable<User> listaUsuarios = _dbcontext.Users;
            return listaUsuarios;
        }

        public async Task<User> ObtenerPorLogin(string usuario, string clave)
        {
            IQueryable<User> lects = _dbcontext.Database.SqlQueryRaw<User>(
                "GetUsuarioPorLogin @usuario, @clave",
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@clave", clave));

            User dataUser = lects.FirstOrDefault();
            return dataUser;
        }
    }
}
