using Microsoft.AspNetCore.Mvc;

namespace razor_page_cs51.Pages.Shared.Components.CategoryComponentView
{
    // Cách 1 dùng attribute ViewComponent
    //[ViewComponent]
    //public class CategoryComponentView
    //{
    //    //Invoke
    //    //InvokeAsync

    //    // Invoke phải trả về string hoặc IViewComponentRefult nếu không nó ném lỗi
    //    public string Invoke()
    //    {
    //        return "This is Component CategoryComponentView";
    //    }
    //}

    // Cách 2 dùng hậu tố ViewComponent -> trong trường hợp bên dưới ta dùng CategoryComponentView để gọi đến component
    //public class CategoryComponentViewViewComponent
    //{
    //    //Invoke
    //    //InvokeAsync

    //    // Invoke phải trả về string hoặc IViewComponentRefult nếu không nó ném lỗi
    //    public string Invoke()
    //    {
    //        return "This is Component CategoryComponentView";
    //    }
    //}

    //Cách 3 kế thừa ViewComponent (nên dùng cách này)
    public class CategoryComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Mặc định nó sẽ thi hành file Default.cshtml
        }
    }
}
