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
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();

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
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();

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
    public ActionResult<Categoria> Get(int id)
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaID == id);

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
    public ActionResult<Categoria> Post(Categoria categoria)
    {

        try
        {
            if (categoria is null)
            {
                return BadRequest("Categoria não pode ser criada vazia");
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaID }, categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar categoria.");
        }


    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaID)
            {
                return BadRequest("Categoria inválida");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar atualizar categoria.");
        }

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {

        try
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaID == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar deletar categoria.");
        }

    }
}