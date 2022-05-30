using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minh.Cs40.Models
{
    [Table("product")]
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)] // Order là thứ tự các column số càng bé càng đứng đầu từ trái -> phải
        public int Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [ForeignKey("category_id")]
        public string? CategoryId { get; set; }

        [Column("category_id")]
        [ForeignKey("category_id")]
        public CategoryEntity Category { get; set; } // -> FK tham chieu toi PK cua 

        public void PrintInfo() => Console.WriteLine($"{Id} - {Name} - {Price}");
    }
}
