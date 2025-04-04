using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Produto")]
public class Produto 
{
    [Key]
    public int ProdutoID { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaID { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
   
