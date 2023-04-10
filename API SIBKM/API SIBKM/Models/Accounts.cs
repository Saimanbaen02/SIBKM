using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Accounts
    {
        [Key, Column("employee_nik", TypeName = "varchar(5)")]
        public string employee_nik { get; set; }
        [Column("password", TypeName = "varchar(255)")]
        public string password { get; set; }
    }
}