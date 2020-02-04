using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using efcurso.Models;
using efcurso.Database;
using Microsoft.EntityFrameworkCore;

namespace efcurso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;
        public HomeController(ApplicationDBContext database){
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Teste()
        {
            /*Categoria c1 = new Categoria();
            c1.Nome = "Categoria 1";
            Categoria c2 = new Categoria();
            c2.Nome = "Categoria 2";
            Categoria c3 = new Categoria();
            c3.Nome = "Categoria 3";
            Categoria c4 = new Categoria();
            c4.Nome = "Categoria 4";

            List<Categoria> catList = new List<Categoria>();
            catList.Add(c1);
            catList.Add(c2);
            catList.Add(c3);
            catList.Add(c4);

            database.AddRange(catList);
            database.SaveChanges();
            */
            var listadeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Categoria")).ToList();
            Console.WriteLine("==================== Categorias ================");

            listadeCategorias.ForEach(categoria =>{
                Console.WriteLine(categoria.ToString());
                
            });

            Console.WriteLine("====================================");

            return Content("dadoos salvos");
        }

        public IActionResult Relacionamento()
        {
            /**
            Produto p = new Produto();
            p.Nome = "Doritos";
            p.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p2 = new Produto();
            p2.Nome = "Frango";
            p2.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p3 = new Produto();
            p3.Nome = "Bolo";
            p3.Categoria = database.Categorias.First(c => c.Id == 2);

            database.Add(p);
            database.Add(p2);
            database.Add(p3);
            

            var listadeProdutos = database.Produtos.Include(p => p.Categoria).ToList();
            listadeProdutos.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });
            */
            var listaDeProdutosDeCategoria = database.Produtos.Include(p => p.Categoria).Where(p => p.Categoria.Id == 1).ToList();
            listaDeProdutosDeCategoria.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });
            return Content("Relacionamento");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
