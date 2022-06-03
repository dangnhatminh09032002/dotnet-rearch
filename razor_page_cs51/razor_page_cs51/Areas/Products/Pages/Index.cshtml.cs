using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_page_cs51.Areas.Products.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        //public PartialViewResult OnGet()
        //{
        //    return Partial("_CardPartialView");
        //    //Có thể trả về partial ở trong này
        //    // Trong pagemodel ta dùng: Partial, ViewComponent
        //    // Trong controller ta dùng: PartialView, ViewComponent 
        //}
    }
}
