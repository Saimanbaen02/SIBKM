using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Employee
    {
        [Key, Column("nik", TypeName = "char(5)")]
        public string nik { get; set; }
        [Column("first_name", TypeName = "varchar(50)")]
        public string first_name { get; set; }
        [Column("last_name", TypeName = "varchar(50)")]
        public string last_name { get; set; }
        [Column("birthdate", TypeName = "datetime")]
        public DateTime birthdate { get; set; }
        [Column("gender")]
        public Gender gender { get; set; }
        [Column("hiring_date", TypeName = "datetime")]
        public DateTime hiring_date { get; set; }
        [Column("email", TypeName = "varchar(50)")]
        public string email { get; set; }
        [Column("phone_number", TypeName = "varchar(50)")]
        public string phone_number { get; set; }
    }
}

public enum Gender
{
    Male,
    Female
}