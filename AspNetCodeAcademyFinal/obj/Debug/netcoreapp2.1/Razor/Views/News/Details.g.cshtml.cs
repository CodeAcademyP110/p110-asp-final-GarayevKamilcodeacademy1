#pragma checksum "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\News\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b893a4aa41a2588221bea5378db17ae4e0488f8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Details), @"mvc.1.0.view", @"/Views/News/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/Details.cshtml", typeof(AspNetCore.Views_News_Details))]
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
#line 1 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\_ViewImports.cshtml"
using AspNetCodeAcademyFinal;

#line default
#line hidden
#line 2 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\_ViewImports.cshtml"
using AspNetCodeAcademyFinal.Models;

#line default
#line hidden
#line 3 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\_ViewImports.cshtml"
using DAL.Domian.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b893a4aa41a2588221bea5378db17ae4e0488f8f", @"/Views/News/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03580bd3efa53a668192d5d67e4d00da44f68b26", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.Domian.Entities.News>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 42, true);
            WriteLiteral("<div>\r\n    <textbox style=\"display:block\">");
            EndContext();
            BeginContext(76, 11, false);
#line 3 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\News\Details.cshtml"
                              Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(87, 47, true);
            WriteLiteral("</textbox>\r\n    <textbox style=\"display:block\">");
            EndContext();
            BeginContext(135, 19, false);
#line 4 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\News\Details.cshtml"
                              Write(Model.TextDirectory);

#line default
#line hidden
            EndContext();
            BeginContext(154, 47, true);
            WriteLiteral("</textbox>\r\n    <textbox style=\"display:block\">");
            EndContext();
            BeginContext(202, 20, false);
#line 5 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\News\Details.cshtml"
                              Write(Model.PhotoDirectory);

#line default
#line hidden
            EndContext();
            BeginContext(222, 49, true);
            WriteLiteral("</textbox>\r\n\r\n    <textbox style=\"display:block\">");
            EndContext();
            BeginContext(272, 18, false);
#line 7 "C:\Users\magay\source\repos\CodeAcademyProject\AspNetCodeAcademyFinal\Views\News\Details.cshtml"
                              Write(Model.CreationDate);

#line default
#line hidden
            EndContext();
            BeginContext(290, 25, true);
            WriteLiteral("</textbox>\r\n   \r\n\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.Domian.Entities.News> Html { get; private set; }
    }
}
#pragma warning restore 1591
