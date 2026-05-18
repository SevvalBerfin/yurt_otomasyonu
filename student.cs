using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace yurt_otomasyon_projesi
{
    [Table("Table_student")]
    internal class student
    {
        [Key]
        public int student_ıd { get; set; }

        [Required]
        [MaxLength (50)]
        public string student_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string student_surname { get; set; }

        [Required]
        [MaxLength(11)]
        public string student_tc { get; set; }

        [Required]
        [MaxLength(50)]
        public string student_email { get; set; }

        [Required]
        [MaxLength(11)]
        public string student_phone { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
