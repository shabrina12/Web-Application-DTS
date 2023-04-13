using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class Account
    {
        [Key]
        [Column(name: "employee_nik", TypeName = "varchar(5)")]
        public string EmployeeNik { get; set; }
        public Employee? Employee { get; set; } //relation one to one ke tabel Employee
        public ICollection<AccountRole>? AccountRoles { get; set; } //relation one to many ke tabel AccountRole

        [Column(name: "password", TypeName = "varchar(255)")]
        public string Password { get; set; }
    }
}
