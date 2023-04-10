using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_roles")]
    public class Roles
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar(100)")]
        public string name { get; set; }
    }
}
