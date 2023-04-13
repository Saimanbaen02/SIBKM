﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_tr_profilings")]
public class Profiling
{
    [Key, Column("employee_nik", TypeName = "char(5)")]
    public string EmployeeNIK { get; set; }
    [Column("education_id", TypeName = "int")]
    public int? EducationId { get; set; }

    // Cardinality
    public Education Education { get; set; }
    public Employee Employee { get; set; }
}
