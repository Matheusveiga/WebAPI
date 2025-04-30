using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
    {
        try
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();

            if (produtos == null || !produtos.Any())
            {
                return NotFound();
            }

            return produtos;
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar produtos.");
        }
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public async Task<ActionResult<Produto>> GetAsync(int id)
    {

        try
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoID == id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar produto.");
        }

    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(Produto produto)
    {

        try
        {
            if (produto is null)
            {
                return BadRequest("Produto inválido");
            }

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoID }, produto);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar produto.");
        }


    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutAsync(int id, Produto produto)
    {

        try
        {
            if (id != produto.ProdutoID)
            {
                return BadRequest("Produto inválido");
            }

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar atualizar produto.");
        }



    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {

        try
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoID == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok("Produto removido com sucesso");
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar remover produto.");
        }


    }



}