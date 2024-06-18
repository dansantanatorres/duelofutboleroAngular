using sigSG.DataLayer.Repositories;
using sigSG.Models;
using sigSG.ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.BussinesLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepo;

        public UserService(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<bool> Actualizar(User modelo)
        {
            return await _userRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _userRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(User modelo)
        {
            return await _userRepo.Insertar(modelo);
        }

        public async Task<User> Obtener(int id)
        {
            return await _userRepo.Obtener(id);
        }

        public async Task<User> ObtenerPorNombre(string name)
        {
            IQueryable<User> qryUser = await _userRepo.ObtenerTodos();
            User usuario = qryUser.Where(c => c.Nombre1 == name).FirstOrDefault();
            return usuario;
        }

        public async Task<IQueryable<User>> ObtenerTodos()
        {
            return await _userRepo.ObtenerTodos();
        }
    }
}
