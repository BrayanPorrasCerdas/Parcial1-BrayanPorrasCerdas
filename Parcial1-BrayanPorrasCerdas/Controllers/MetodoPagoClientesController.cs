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
    public class MetodoPagoClientesController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public MetodoPagoClientesController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: MetodoPagoClientes
        public async Task<IActionResult> Index(string buscar_metodo_pago)

        {
            var metodopago = from MetodoPagoCliente in _context.MetodoPagoClientes select MetodoPagoCliente;

            if (!String.IsNullOrEmpty(buscar_metodo_pago))
            {
                metodopago = metodopago.Where(s =>
                    s.NombreProveedor!.Contains(buscar_metodo_pago));
            }

            return View(await metodopago.ToListAsync());
        }

        // GET: MetodoPagoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagoCliente = await _context.MetodoPagoClientes
                .Include(m => m.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdMetodoPago == id);
            if (metodoPagoCliente == null)
            {
                return NotFound();
            }

            return View(metodoPagoCliente);
        }

        // GET: MetodoPagoClientes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: MetodoPagoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetodoPago,IdCliente,IdTipoPago,NombreProveedor,Cuenta,FechaExpira,PorDefecto,FechaCreacion,FechaModificacion")] MetodoPagoCliente metodoPagoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPagoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", metodoPagoCliente.IdCliente);
            return View(metodoPagoCliente);
        }

        // GET: MetodoPagoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagoCliente = await _context.MetodoPagoClientes.FindAsync(id);
            if (metodoPagoCliente == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", metodoPagoCliente.IdCliente);
            return View(metodoPagoCliente);
        }

        // POST: MetodoPagoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMetodoPago,IdCliente,IdTipoPago,NombreProveedor,Cuenta,FechaExpira,PorDefecto,FechaCreacion,FechaModificacion")] MetodoPagoCliente metodoPagoCliente)
        {
            if (id != metodoPagoCliente.IdMetodoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPagoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagoClienteExists(metodoPagoCliente.IdMetodoPago))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", metodoPagoCliente.IdCliente);
            return View(metodoPagoCliente);
        }

        // GET: MetodoPagoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPagoCliente = await _context.MetodoPagoClientes
                .Include(m => m.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdMetodoPago == id);
            if (metodoPagoCliente == null)
            {
                return NotFound();
            }

            return View(metodoPagoCliente);
        }

        // POST: MetodoPagoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoPagoCliente = await _context.MetodoPagoClientes.FindAsync(id);
            if (metodoPagoCliente != null)
            {
                _context.MetodoPagoClientes.Remove(metodoPagoCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagoClienteExists(int id)
        {
            return _context.MetodoPagoClientes.Any(e => e.IdMetodoPago == id);
        }
    }
}
