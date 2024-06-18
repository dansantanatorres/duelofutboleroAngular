using sigSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.BussinesLayer.Service
{
    public interface ILoginService
    {
        Task<User> ObtenerPorLogin(string name, string pass);
    }
}
