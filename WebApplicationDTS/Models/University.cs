using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class University
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "name", TypeName = "varchar(100)")]
        public string Name { get; set; }
        public ICollection<Education>? Educations { get; set; } //relation one to many ke tabel Education
    }
}
