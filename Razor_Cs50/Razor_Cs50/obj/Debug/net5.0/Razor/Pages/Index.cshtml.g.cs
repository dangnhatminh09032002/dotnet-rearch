#pragma checksum "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c25d9f8aec95dca96dd52c04d9c6efcc49c1a5e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c25d9f8aec95dca96dd52c04d9c6efcc49c1a5e5", @"/Pages/Index.cshtml")]
    #nullable restore
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>This is Index Page</h1>\r\n<br>\r\n<h2>");
#nullable restore
#line 8 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
Write(System.DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 9 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
  
    int x = 12;
    int y = 11;

    int multiplication = 12 * 11;

    //nó sẽ tự động xuất ra đoạn chỗi này

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>X + Y = ");
#nullable restore
#line 16 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
           Write(x + y);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>X * Y = ");
#nullable restore
#line 17 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
          Write(multiplication);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
#nullable restore
#line 17 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
                                  ;

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul>\r\n");
#nullable restore
#line 20 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
 for(int i = 0; i < x; i++) {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Idx: ");
#nullable restore
#line 22 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "C:\Users\dangn\OneDrive\Máy tính\MINH\code\MyCode\dotnet-rearch\Razor_Cs50\Razor_Cs50\Pages\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Razor_Cs50.Pages.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor_Cs50.Pages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor_Cs50.Pages.IndexModel>)PageContext?.ViewData;
        public Razor_Cs50.Pages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591