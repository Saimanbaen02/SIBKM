using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_tr_profilings")]
    public class Profilings
    {
        [Key, Column("employee_nik", TypeName = "char(5)")]
        public string employee_nik { get; set; }

        [Column("education_id")]
        public string education_id { get; set; }
    }
}
