using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class StarPurchasesController : ControllerBase
{
    private readonly AppDbContext _context;

    public StarPurchasesController(AppDbContext context)
    {
        _context = context;
    }

    // Get all star purchases
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StarPurchase>>> GetStarPurchases()
    {
        return await _context.StarPurchases.ToListAsync();
    }

    // Get star purchases by Artist ID
    [HttpGet("artist/{artistId}")]
    public async Task<ActionResult<IEnumerable<StarPurchase>>> GetStarPurchasesByArtistId(int artistId)
    {
        var purchases = await _context.StarPurchases
            .Where(sp => sp.ArtistId == artistId)
            .ToListAsync();

        if (purchases == null || !purchases.Any())
        {
            return NotFound($"No star purchases found for artist with ID {artistId}.");
        }

        return purchases;
    }

    [HttpGet("totals")]
    public async Task<ActionResult<IEnumerable<object>>> GetArtistStarTotals()
    {
        var totals = await _context.StarPurchases
            .GroupBy(sp => sp.ArtistId)
            .Select(g => new
            {
                ArtistId = g.Key,
                TotalStars = g.Sum(sp => sp.StarsPurchased)
            })
            .ToListAsync();

        return Ok(totals);
    }

    // Create a new star purchase
   [HttpPost]
    public async Task<IActionResult> CreateStarPurchase([FromBody] StarPurchase starPurchase)
    {

        if (starPurchase == null || starPurchase.ArtistId <= 0)
        {
            return BadRequest(new { Message = "Invalid StarPurchase data." });
        }

        var artist = await _context.Artists.FindAsync(starPurchase.ArtistId);
        if (artist == null)
        {
            return BadRequest(new { Message = "Artist not found." });
        }

       // Attach the existing artist to the StarPurchase
         starPurchase.Artist = artist;

        // Add the StarPurchase
        _context.StarPurchases.Add(starPurchase); 

         try
        {
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Star purchase created successfully." });
        }
        catch (DbUpdateException ex)
        {
            // Log the error and return a 500 error if needed
            return StatusCode(500, new { Message = "An error occurred while saving the purchase.", Detail = ex.Message });
        }
    }
}