using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_educations")]
    public class Educations
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("major", TypeName = "varchar(100)")]
        public string major { get; set; }
        [Column("degree", TypeName = "varchar(10)")]
        public string degree { get; set; }
        [Column("gpa", TypeName = "varchar(100)")]
        public string gpa { get; set; }
        [Column("university_id")]
        public int university_id { get; set; }
    }
}
