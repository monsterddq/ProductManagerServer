using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class Unit
    {
        [Key]
        [Required]
        public int UnitId { get; set; }
        public string Name { get; set; } = "";
    }
}
