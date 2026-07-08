
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Mvc.Models;

public class ProductosController : Controller
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Productos.ToListAsync());
    }

    // GET: PRODUCTOS/Details/5
    public async Task<IActionResult> Details(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // GET: PRODUCTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: PRODUCTOS/Edit/5
    public async Task<IActionResult> Edit(int? Codigo)
    {
        if (Codigo == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos.FindAsync(Codigo);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // POST: PRODUCTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? Codigo, Producto producto)
    {
        if (Codigo != producto.Codigo)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Codigo))
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
        return View(producto);
    }

    // GET: PRODUCTOS/Delete/5
    public async Task<IActionResult> Delete(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: PRODUCTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? codigo)
    {
        var producto = await _context.Productos.FindAsync(codigo);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductoExists(int? codigo)
    {
        return _context.Productos.Any(e => e.Codigo == codigo);
    }
}
