using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor_page_cs51.Pages.Shared.Components.MessageComponentView;

namespace razor_page_cs51.Areas.Notify.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            MessageComponentView.MessagePage message = new MessageComponentView.MessagePage();
            return ViewComponent("MessageComponentView", message);
        }
    }
}
