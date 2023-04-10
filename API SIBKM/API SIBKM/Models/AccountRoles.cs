using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_tr_account_roles")]
    public class AccountRoles
    {
        [Key, Column("id")]
        public int id { get; set; }
        [Column("account_nik", TypeName = "char(5)")]
        public string account_nik { get; set; }
        [Column("role_id")]
        public int role_id { get; set; }
    }
}