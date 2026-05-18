using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yurt_otomasyon_projesi
{
    [Table ("Table_room")]
    internal class Room
    {
        [Key]
        public int room_ıd {  get; set; }

        [Required,MaxLength(50)]
        public string room_number { get; set; }

        [Required]
        public int room_capacity { get; set; }

        [ForeignKey ("Category")]
        public int category_ıd { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }





    }
}
