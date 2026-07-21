using AddressChallenge.Data;
using AddressChallenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AddressChallenge.Controllers;

[Authorize]
public class EnderecoController : Controller
{
    private readonly AppDbContext _context;

    public EnderecoController(AppDbContext context)
    {
        _context = context;
    }

    private Guid GetUserId()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
    }

    public async Task<IActionResult> Index()
    {
        var userId = GetUserId();
        var enderecos = await _context.Enderecos
            .Where(e => e.UsuarioId == userId)
            .ToListAsync();
        return View(enderecos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Endereco endereco)
    {
        if (ModelState.IsValid)
        {
            endereco.Id = Guid.NewGuid();
            endereco.UsuarioId = GetUserId();
            _context.Add(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(endereco);
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) return NotFound();

        var userId = GetUserId();
        var endereco = await _context.Enderecos
            .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);
            
        if (endereco == null) return NotFound();
        return View(endereco);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Endereco endereco)
    {
        if (id != endereco.Id) return NotFound();
        
        var userId = GetUserId();
        endereco.UsuarioId = userId; // security: force user id

        // Optional check for missing related data
        if (ModelState.IsValid)
        {
            try
            {
                var existingEndereco = await _context.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);
                if (existingEndereco == null) return NotFound();

                _context.Update(endereco);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(endereco);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var userId = GetUserId();
        var endereco = await _context.Enderecos.FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);
        if (endereco != null)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool EnderecoExists(Guid id)
    {
        return _context.Enderecos.Any(e => e.Id == id);
    }
}
