using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_universities")]
    public class Universities
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("name", TypeName = "varchar(100)")]
        public string name { get; set; }
    }
}