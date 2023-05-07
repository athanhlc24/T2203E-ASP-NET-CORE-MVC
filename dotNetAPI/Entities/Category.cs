using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotNetAPI.Entities
{
    [Table("categories")]
    [Index(nameof(slug),IsUnique =true)]
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string slug { get; set; }
    }
}
