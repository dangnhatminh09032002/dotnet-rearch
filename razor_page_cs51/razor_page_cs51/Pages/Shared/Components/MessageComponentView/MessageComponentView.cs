using Microsoft.AspNetCore.Mvc;
namespace razor_page_cs51.Pages.Shared.Components.MessageComponentView
{
    public class MessageComponentView : ViewComponent
    {
        public class MessagePage
        {
            public string title { get; set; } = "Notify";
            public string htmlcontent { get; set; } = "";
            public string urlredirect { get; set; } = "/";
            public int secondwait { get; set; } = 3; //3s sau nó sẽ điều hướng về urlredirect
        }

        public IViewComponentResult Invoke(MessagePage message)
        {
            this.HttpContext.Response.Headers.Add("REFRESH", $"{message.secondwait};url={message.urlredirect}");
            return View<MessagePage>(message);
        }
    }
}
