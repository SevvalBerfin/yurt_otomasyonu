using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yurt_otomasyon_projesi
{
    [Table ("Table_registration")]
    internal class Registration
    {
        [Key]
        public int registration_ıd {  get; set; }

        [ForeignKey ("student")]
        public int student_ıd { get; set; }

        [ForeignKey ("Room")]
        public int room_ıd { get; set; }

        [Required]
        public DateTime registration_date { get; set; }

        [Required]
        public decimal registration_price { get; set; }

        public virtual student student { get; set; }
        public virtual Room Room { get; set; }
    }
}
