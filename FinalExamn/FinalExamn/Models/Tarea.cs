using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExamn.Models
{
    [Table("tareas")]
    public class Tarea
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }
    }
}
