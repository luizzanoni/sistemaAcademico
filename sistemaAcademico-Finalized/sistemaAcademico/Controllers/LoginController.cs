using sistemaAcademico.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Catalogo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(Usuario usuario)
        {

            //Validação do usuário e senha


            Claim login = new Claim(ClaimTypes.Name, usuario.Login);
            Claim perfil = new Claim("Perfil", "Administrador");

            var claims = new List<Claim>();
            claims.Add(login);
            claims.Add(perfil);

            var identity = new ClaimsIdentity(claims, "loginSchema");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("loginSchema", principal);


            return View();
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
