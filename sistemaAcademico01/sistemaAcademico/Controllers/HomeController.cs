using Microsoft.AspNetCore.Mvc;
using sistemaAcademico.Models;

namespace sistemaAcademico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            List<Aluno> listadeAlunos = new List<Aluno>();
            listadeAlunos.Add(new Aluno { Nome = "Luiz", Matricula = "011111", Endereco = "Chapeco", Telefone = "999241385" });
            listadeAlunos.Add(new Aluno { Nome = "Luana", Matricula = "022222", Endereco = "Chapeco", Telefone = "999241388" });
            listadeAlunos.Add(new Aluno { Nome = "Anna", Matricula = "033333", Endereco = "Chapeco", Telefone = "999241348" });
            listadeAlunos.Add(new Aluno { Nome = "Joana", Matricula = "044444", Endereco = "Chapeco", Telefone = "999241555" });
   
            return View(listadeAlunos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
