using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.DataLayer.Repositories
{
    public interface ILoginRepository<TEntityModel> where TEntityModel : class
    {
        Task<TEntityModel> ObtenerPorLogin(string usuario, string clave);
    }
}
