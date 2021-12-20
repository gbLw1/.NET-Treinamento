#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula03.WebApp.Data;
using Aula03.WebApp.Models;

namespace Aula03.WebApp.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: produtos/
        [HttpGet]
        [Route("~/produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: produtos/{id}
        [HttpGet]
        [Route("~/produtos/{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View("Produto", produto);
        }

        // GET: produtos/novo
        [HttpGet]
        [Route("~/produtos/novo")]
        public IActionResult Novo()
        {
            return View("Produto");
        }

        // POST: produtos/
        [HttpPost]
        [Route("~/produtos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar([Bind("Id,Nome,Unidade,PesoGramas")] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!ProdutoExists(produto.Id))
                        _context.Add(produto);
                    else
                        _context.Update(produto);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                return View("Produto", produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: produtos/delete/{id}
        [HttpPost]
        [Route("~/produtos/delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
