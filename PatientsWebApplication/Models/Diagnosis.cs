using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsWebApplication.Models
{
    public class Diagnosis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosisID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Name of diagnoses")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
