using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class Profiling
    {
        [Key]
        [Column(name: "employee_nik", TypeName = "varchar(5)")]
        public string EmployeeNik { get; set; }
        public Employee? Employees { get; set; } //relation one to one ke tabel Employee

        [Column(name: "education_id")]
        public int EducationId { get; set; }
        public Education? Educations { get; set; } //relation one to one ke tabel Education
    }
}
