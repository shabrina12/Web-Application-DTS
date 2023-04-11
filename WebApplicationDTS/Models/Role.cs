using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.Models
{
    public class Role
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }
        public ICollection<AccountRole> AccountRoles { get; set; } //relation one to many ke tabel AccountRole

        [Column(name: "name", TypeName = "varchar(50)")]
        public string Name { get; set; }

    }
}
