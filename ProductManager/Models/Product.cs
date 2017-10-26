using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = "Sản phẩm";
        public float Price { get; set; } = 0;
        public string Image { get; set; } = "";
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Units { get; set; }
    }
}
