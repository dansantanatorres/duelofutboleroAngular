using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigSG.BussinesLayer.Service;
using sigSG.Models;
using sigSG.ModelsLayer.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using sigSG.ModelsLayer;

namespace sigSGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult Login(Login dataLogin)
        {
            var user = Autenticacion(dataLogin);
            if(user != null)
            {
                return new JsonResult(user);
            }
            return NotFound("Usuario no encontrado");
        }

        [HttpGet]
        public IActionResult PruebaAPI()
        {
            User aux = new sigSG.Models.User();
            aux.Usuario = "Usuario de Prueba";
            aux.Clave = "123456";
            
            return new JsonResult(aux);
        }

        private User Autenticacion(Login usr)
        {
            User usuarioActual = _loginService.ObtenerPorLogin(usr.Usuario, usr.Clave).Result;
            return usuarioActual;
        }
    }
}
