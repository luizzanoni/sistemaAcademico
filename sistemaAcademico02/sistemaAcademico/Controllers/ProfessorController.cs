using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sistemaAcademico.Models;

namespace sistemaAcademico.Controllers
{
    public class ProfessorController : Controller
    {
        //serve para utilizar cache da maquina para salvar os dados
        public IMemoryCache _memCache;

        public ProfessorController(IMemoryCache memCache)
        {
            _memCache = memCache;
        }
        //serve para utilizar cache da maquina para salvar os dados

        public IActionResult Index()
        {
            return View(GetProfessor());

        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Professor professor)
        {

            //incluir no banco de dados 
            ViewBag.MensagemSucesso = "Aluno cadastrado com sucesso";

            IList<Professor> listaProfessor = GetProfessor();
            listaProfessor.Add(professor);

            return View("Index", listaProfessor);
        }
        public IList<Professor> GetProfessorCache()
        {
            List<Professor> listaDeProfessor = new List<Professor>();

            _memCache.Set("listaDeProfessor", listaDeProfessor, TimeSpan.FromHours(1));

            return (IList<Professor>)_memCache.Get("listaDeProfessor");
        }

        public IList<Professor> GetProfessor()
        {

            List<Professor> listaDeProfessor = new List<Professor>();
            listaDeProfessor.Add(new Professor { Nome = "Luiz", Formacao = "Port.", Materia = "Port.", Endereco = "Chapeco", Telefone = "999241385" });
            listaDeProfessor.Add(new Professor { Nome = "Luana", Formacao = "Mat.", Materia = "Mat.", Endereco = "Chapeco", Telefone = "999241388" });
            listaDeProfessor.Add(new Professor { Nome = "Anna", Formacao = "Ed. Fis.", Materia = "Ed. Fis.", Endereco = "Chapeco", Telefone = "999241348" });
            listaDeProfessor.Add(new Professor { Nome = "Joana", Formacao = "Cie.", Materia = "Cie.", Endereco = "Chapeco", Telefone = "999241555" });
            return listaDeProfessor;
        }
    }
}
