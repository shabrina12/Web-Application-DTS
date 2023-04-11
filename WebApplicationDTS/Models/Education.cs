using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class Education
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }
        public Profiling Profilings { get; set; } //relation one to one ke tabel Profiling

        [Column(name: "major", TypeName = "varchar(100)")]
        public string Major { get; set; }

        [Column(name: "degree", TypeName = "varchar(10)")]
        public string Degree { get; set; }

        [Column(name: "gpa", TypeName = "varchar(5)")]
        public string Gpa { get; set; }

        [Column(name: "university_id ")]
        public int UniversityId { get; set; }
        public University Universities { get; set; } //relation one to one ke tabel University
    }
}
