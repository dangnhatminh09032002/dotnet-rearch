using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minh.Cs40.Models
{
    [Table("persion")]
    public class PersionEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)] // Order là thứ tự các column số càng bé càng đứng đầu từ trái -> phải
        public int Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        public void PrintInfo() => Console.WriteLine($"{Id} - {Name} - {Age}");
    }
}
