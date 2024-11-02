using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1_BrayanPorrasCerdas.Models;

namespace Parcial1_BrayanPorrasCerdas.Controllers
{
    public class CategoriaProductoesController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public CategoriaProductoesController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: CategoriaProductoes
        public async Task<IActionResult> Index(string buscar_categoria)
        {
            var categorias = from CategoriaProducto in _context.CategoriaProductos select CategoriaProducto;

            if (!String.IsNullOrEmpty(buscar_categoria))
            {
                categorias = categorias.Where(s =>
                        s.NombreCategoria!.Contains(buscar_categoria));
            }
            return View(await categorias.ToListAsync());

        }

        // GET: CategoriaProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos
                .Include(c => c.IdCategoriaPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdCategoriaPadre"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "IdCategoria");
            return View();
        }

        // POST: CategoriaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,IdCategoriaPadre,NombreCategoria,FechaCreacion,FechaModificacion")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoriaPadre"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "IdCategoria", categoriaProducto.IdCategoriaPadre);
            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }
            ViewData["IdCategoriaPadre"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "IdCategoria", categoriaProducto.IdCategoriaPadre);
            return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,IdCategoriaPadre,NombreCategoria,FechaCreacion,FechaModificacion")] CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProductoExists(categoriaProducto.IdCategoria))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoriaPadre"] = new SelectList(_context.CategoriaProductos, "IdCategoria", "IdCategoria", categoriaProducto.IdCategoriaPadre);
            return View(categoriaProducto);
        }

        // GET: CategoriaProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos
                .Include(c => c.IdCategoriaPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return View(categoriaProducto);
        }

        // POST: CategoriaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto != null)
            {
                _context.CategoriaProductos.Remove(categoriaProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProductoExists(int id)
        {
            return _context.CategoriaProductos.Any(e => e.IdCategoria == id);
        }
    }
}
