using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tareas")]
public class Tarea
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("descripcion")]
    public string Descripcion { get; set; }


}
