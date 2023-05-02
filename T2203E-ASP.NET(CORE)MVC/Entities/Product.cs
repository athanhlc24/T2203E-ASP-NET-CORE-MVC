using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace T2203E_ASP.NET_CORE_MVC.Entities
{
    [Table("Products")]
    public class Product    
    {
        [Key]// khoá chính
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        public decimal Price { get; set; }

        [StringLength (150)]
        public string thumbnail { get; set; }
    }
}
