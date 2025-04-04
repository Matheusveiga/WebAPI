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

    [HttpGet("primeiro")]
    public ActionResult<Produto> GetPrimeiro()
    {

        try
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p=> p.ProdutoID == 1);

            if (produto == null )
            {
                return NotFound();
            }

            return produto;
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar produtos.");
        }

    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {

        try
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();

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

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {

        try
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoID == id);

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
    public ActionResult Post(Produto produto)
    {

        try
        {
            if (produto is null)
            {
                return BadRequest("Produto inválido");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoID }, produto);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar produto.");
        }


    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {

        try
        {
            if (id != produto.ProdutoID)
            {
                return BadRequest("Produto inválido");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar atualizar produto.");
        }



    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {

        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoID == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok("Produto removido com sucesso");
        }

        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar remover produto.");
        }


    }



}