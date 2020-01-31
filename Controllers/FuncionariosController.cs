using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using efcurso.Models;
using efcurso.Database;

namespace efcurso.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database;

        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if(funcionario.Id == 0){
                database.Funcionarios.Add(funcionario);
            }else{
                Funcionario funcionarioDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Salario = funcionario.Salario;
                funcionarioDoBanco.Cpf = funcionario.Cpf;
            }

            
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}