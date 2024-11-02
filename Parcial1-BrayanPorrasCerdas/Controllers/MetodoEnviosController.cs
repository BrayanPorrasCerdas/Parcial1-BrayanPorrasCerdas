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
    public class MetodoEnviosController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public MetodoEnviosController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: MetodoEnvios
        public async Task<IActionResult> Index(string buscar_metodo_envio)
        {
            var envios = from metodoEnvio in _context.MetodoEnvios select metodoEnvio;

            if (!string.IsNullOrEmpty(buscar_metodo_envio))
            {
                envios = envios.Where(s =>
                    (s.Nombre != null && s.Nombre.Contains(buscar_metodo_envio)) ||
                    (s.Precio.ToString().Contains(buscar_metodo_envio)));
            }

            return View(await envios.ToListAsync());
        }


        // GET: MetodoEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvios
                .FirstOrDefaultAsync(m => m.IdMetodoEnvio == id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }

            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoEnvios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetodoEnvio,Nombre,Precio,FechaCreacion,FechaModificacion")] MetodoEnvio metodoEnvio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoEnvio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvios.FindAsync(id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }
            return View(metodoEnvio);
        }

        // POST: MetodoEnvios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMetodoEnvio,Nombre,Precio,FechaCreacion,FechaModificacion")] MetodoEnvio metodoEnvio)
        {
            if (id != metodoEnvio.IdMetodoEnvio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoEnvio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoEnvioExists(metodoEnvio.IdMetodoEnvio))
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
            return View(metodoEnvio);
        }

        // GET: MetodoEnvios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoEnvio = await _context.MetodoEnvios
                .FirstOrDefaultAsync(m => m.IdMetodoEnvio == id);
            if (metodoEnvio == null)
            {
                return NotFound();
            }

            return View(metodoEnvio);
        }

        // POST: MetodoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoEnvio = await _context.MetodoEnvios.FindAsync(id);
            if (metodoEnvio != null)
            {
                _context.MetodoEnvios.Remove(metodoEnvio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoEnvioExists(int id)
        {
            return _context.MetodoEnvios.Any(e => e.IdMetodoEnvio == id);
        }
    }
}
