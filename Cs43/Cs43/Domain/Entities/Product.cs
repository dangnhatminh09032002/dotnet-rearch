using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs43.Domain.Entities
{
    //[Table("product")] //Nếu dùng fluent thì không cần phải khai báo điều này nữa
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void ShowInfo() => Console.WriteLine($"{Id} - {Name} - {Price} - {CategoryId}");
    }
}
