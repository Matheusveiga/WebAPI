using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("produtos")]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutosAsync()
    {
        try
        {
            var categorias = await _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToListAsync();

            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }

            return categorias;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar categorias.");
        }


    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetAsync()
    {
        try
        {
            var categorias = await _context.Categorias.AsNoTracking().ToListAsync();

            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }

            return categorias;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar categorias.");
        }

    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public async Task<ActionResult<Categoria>> GetAsync(int id)
    {
        try
        {
            var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.CategoriaID == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }
            return categoria;
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar categoria.");
        }


    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> PostAsync(Categoria categoria)
    {

        try
        {
            if (categoria is null)
            {
                return BadRequest("Categoria não pode ser criada vazia");
            }

            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaID }, categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar categoria.");
        }


    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutAsync(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest("Categoria inválida");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar atualizar categoria.");
        }

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {

        try
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaID == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar deletar categoria.");
        }

    }
}