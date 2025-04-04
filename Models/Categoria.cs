using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Categoria")]
public class Categoria 
{

    public Categoria(){
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaID { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; } 

}