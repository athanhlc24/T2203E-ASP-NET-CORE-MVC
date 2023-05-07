using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotNetAPI.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]// khoá chính
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        [StringLength(150)]
        public string thumbnail { get; set; }
    }
}
