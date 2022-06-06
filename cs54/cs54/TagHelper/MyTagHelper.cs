using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Text;

namespace cs54.MyTagHelper
{
    [HtmlTargetElement("mytaghelper")]
    public class MyTagHelper : TagHelper
    {
        // Thuoc tinh se la list-title
        public string ListTitle { get; set; }
        // Thuoc tinh se la list-items
        public List<string> ListItems { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("style", "background-color: blue");
            StringBuilder content = new StringBuilder();
            ListItems.ForEach(e =>
            {
                content.Append($"<li>{e}</li>");
            });
            output.Content.SetHtmlContent(content.ToString());
            base.Process(context, output);
        }
    }
}
