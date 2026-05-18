using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yurt_otomasyon_projesi
{
    [Table ("Table_category")]
    internal class Category
    {
        [Key]
        public int category_ıd { get; set; }

        [Required, MaxLength(50)]
        public string category_block { get; set; }

        [Required]
        public int category_floor { get; set; }

        [Required, MaxLength(50)]
        public string category_name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}
