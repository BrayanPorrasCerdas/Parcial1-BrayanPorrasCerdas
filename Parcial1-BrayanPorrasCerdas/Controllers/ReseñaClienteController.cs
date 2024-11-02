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
    public class ReseñaClienteController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public ReseñaClienteController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: ReseñaCliente
        public async Task<IActionResult> Index(int? buscar_resena)
        {

            var resenas = from ReseñaCliente in _context.ReseñaClientes select ReseñaCliente;

            if (buscar_resena.HasValue)
            {
                resenas = resenas.Where(s => s.ValorCalificacion == buscar_resena.Value);
            }

            return View(await resenas.ToListAsync());
        }

        // GET: ReseñaCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñaClientes
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdResena == id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }

            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: ReseñaCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResena,IdCliente,IdProducto,ValorCalificacion,Comentario,FechaCreacion,FechaModificacion")] ReseñaCliente reseñaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseñaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", reseñaCliente.IdCliente);
            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñaClientes.FindAsync(id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", reseñaCliente.IdCliente);
            return View(reseñaCliente);
        }

        // POST: ReseñaCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResena,IdCliente,IdProducto,ValorCalificacion,Comentario,FechaCreacion,FechaModificacion")] ReseñaCliente reseñaCliente)
        {
            if (id != reseñaCliente.IdResena)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseñaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaClienteExists(reseñaCliente.IdResena))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", reseñaCliente.IdCliente);
            return View(reseñaCliente);
        }

        // GET: ReseñaCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñaCliente = await _context.ReseñaClientes
                .Include(r => r.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdResena == id);
            if (reseñaCliente == null)
            {
                return NotFound();
            }

            return View(reseñaCliente);
        }

        // POST: ReseñaCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseñaCliente = await _context.ReseñaClientes.FindAsync(id);
            if (reseñaCliente != null)
            {
                _context.ReseñaClientes.Remove(reseñaCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaClienteExists(int id)
        {
            return _context.ReseñaClientes.Any(e => e.IdResena == id);
        }
    }
}
