using sigSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.BussinesLayer.Service
{
    public interface IUserService
    {
        Task<bool> Insertar(User modelo);
        Task<bool> Actualizar(User modelo);
        Task<bool> Eliminar(int id);
        Task<User> Obtener(int id);
        Task<IQueryable<User>> ObtenerTodos();

        Task<User> ObtenerPorNombre(string name);
    }
}
