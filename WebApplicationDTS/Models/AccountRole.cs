using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class AccountRole
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "account_nik", TypeName = "varchar(5)")]
        public string AccountNik { get; set; }
        public Account Accounts { get; set; } //relation one to many ke tabel Account

        [Column(name: "role_id")]
        public int RoleId { get; set; }
        public Role Roles { get; set; } //relation one to many ke tabel Role
    }
}
