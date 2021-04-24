using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerKingCore.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="SubCategory Name")]
        public string Name { get; set; }


        // kategori ve alt katego arası ilişki kuruyoruz
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        //public int Category { get; set; }
        // ileride değişikli olursa yapabilmek için virtual yaptık
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        /* kategori ve sub kategori arasıda bire çok ilişi kurduk  key ile birincil anahtar yaptık
         * kategoriyede foreign key dedik ve category id yi verip bağlamış olduk */

    }
}
