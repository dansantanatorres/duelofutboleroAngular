using sigSG.DataLayer.Repositories;
using sigSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigSG.BussinesLayer.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository<User> _loginRepo;

        public LoginService(ILoginRepository<User> loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public async Task<User> ObtenerPorLogin(string name, string pass)
        {
            return await _loginRepo.ObtenerPorLogin(name, pass);
        }
    }
}
