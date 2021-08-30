using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsWebApplication.Models
{
    public class Visit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }
        [Display(Name = "Visit Date")]
        public DateTime VisitDateTime { get; set; }
        public int DiagnosisID { get; set; }
        [ForeignKey("DiagnosisID")]
        public Diagnosis Diagnosis { get; set; }
    }
}
