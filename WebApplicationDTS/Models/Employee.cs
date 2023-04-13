using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplicationDTS.Models
{
    [Index("Email", "PhoneNumber", IsUnique = true)]
    public class Employee
    {
        [Key]
        [Column(name: "NIK", TypeName = "varchar(5)")]
        public string Nik { get; set; }
        public Profiling? Profilings { get; set; } //relation one to one ke tabel Profiling
        public Account? Accounts { get; set; } //relation one to one ke tabel Account

        [Column(name: "first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column(name: "last_name", TypeName = "varchar(50)")]
        public string? LastName { get; set; }

        [Column(name: "birth_date")]
        public DateTime BirthDate { get; set; }

        [Column(name: "gender")]
        public GenderEnum Gender { get; set; }

        [Column(name: "hiring_date")]
        public DateTime HiringDate { get; set; }

        [Column(name: "email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column(name: "phone_number", TypeName = "varchar(20)")]
        public string PhoneNumber { get; set; }
    }

    public enum GenderEnum
    {
        Male, Female 
    }
}
