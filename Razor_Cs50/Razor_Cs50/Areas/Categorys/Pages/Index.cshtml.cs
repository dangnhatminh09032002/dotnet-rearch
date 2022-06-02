using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Razor_Cs50.Areas.Categorys.Pages
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }

    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class IndexModel : PageModel
    {
        private Category[] _catogoryData;
        public Category[] CategoryData => _catogoryData;
        public void OnGet()
        {
            _catogoryData = new Category[] {
                new Category() {Id = 1, Name = "dien thoai", Description = "chi ban androi"},
                new Category() {Id = 2, Name = "may tinh", Description = "khong ban apple"},
                new Category() {Id = 3, Name = "may giat", Description = "ban samsung dat qua"},
                new Category() {Id = 4, Name = "ban phim", Description = "edra pha gia"},
            };
            Console.WriteLine("OnGet of Categorys Index Page called");
        }
    }
}
