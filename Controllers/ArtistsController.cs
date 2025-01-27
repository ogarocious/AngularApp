using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ArtistsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ArtistsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/artists
    [HttpGet]
    public IActionResult GetArtists()
    {
        var artists = _context.Artists.ToList();
        return Ok(artists);
    }

    // GET: api/artists/{id}
    [HttpGet("{id}")]
    public IActionResult GetArtist(int id)
    {
        var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
        if (artist == null)
        {
            return NotFound();
        }
        return Ok(artist);
    }
}