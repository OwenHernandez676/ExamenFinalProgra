using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("usuarios")]
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("contrasena")]
    public string Contrasena { get; set; }


}
