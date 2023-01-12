using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using sistemaAcademico.Models;

namespace sistemaAcademico.Controllers
{
    public class AlunoController : Controller
    {

        //serve para utilizar cache da maquina para salvar os dados
        public IMemoryCache _memCache; 

        public AlunoController(IMemoryCache memCache)
        {
            _memCache = memCache;
        }
        //serve para utilizar cache da maquina para salvar os dados

        public IActionResult Index()
        {
            return View(GetAlunos());

        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Aluno aluno)
        {

            //incluir no banco de dados 
            ViewBag.MensagemSucesso = "Aluno cadastrado com sucesso";

            IList<Aluno> listaAlunos = GetAlunos();
            listaAlunos.Add(aluno);

            return View("Index", listaAlunos);
        }
        public IList<Aluno> GetAlunosCache()
        {
            List<Aluno> listaDeAlunos = new List<Aluno>();

            _memCache.Set("listaDeAlunos", listaDeAlunos, TimeSpan.FromHours(1));

            return (IList<Aluno>)_memCache.Get("listaDeAlunos");
        }


        public IList<Aluno> GetAlunos()
        {
            List<Aluno> listadeAlunos = new List<Aluno>();
            listadeAlunos.Add(new Aluno { Nome = "Luiz", Matricula = "011111", Endereco = "Chapeco", Telefone = "999241385" });
            listadeAlunos.Add(new Aluno { Nome = "Luana", Matricula = "022222", Endereco = "Chapeco", Telefone = "999241388" });
            listadeAlunos.Add(new Aluno { Nome = "Anna", Matricula = "033333", Endereco = "Chapeco", Telefone = "999241348" });
            listadeAlunos.Add(new Aluno { Nome = "Joana", Matricula = "044444", Endereco = "Chapeco", Telefone = "999241555" });
            return listadeAlunos;
        }
    }
}
