#pragma checksum "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5ca7c311e0371873ba209c9062c639b0f6d1fb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AppliedJob_Index), @"mvc.1.0.view", @"/Views/AppliedJob/Index.cshtml")]
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
#nullable restore
#line 1 "C:\ASP.NET\LinkedIn\Views\_ViewImports.cshtml"
using LinkedIn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ASP.NET\LinkedIn\Views\_ViewImports.cshtml"
using LinkedIn.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\ASP.NET\LinkedIn\Views\_ViewImports.cshtml"
using LinkedIn.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5ca7c311e0371873ba209c9062c639b0f6d1fb0", @"/Views/AppliedJob/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69ca2e4b9c85adf276d646f14edbc9ff40c1b58e", @"/Views/_ViewImports.cshtml")]
    public class Views_AppliedJob_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JobSeeker>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h2 class=""text-info"">Candidate Lists</h2>

<br />

<table class=""table table-striped"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>City</th>
            <th>Mobile</th>
            <th>Resume</th>
            <th>Experience</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
         foreach (var obj in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
               Write(obj.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
               Write(obj.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
               Write(obj.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
               Write(obj.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a class=\"btn btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 646, "\"", 673, 2);
#nullable restore
#line 27 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
WriteAttributeValue("", 653, WC.image, 653, 9, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
WriteAttributeValue("", 662, obj.Resume, 662, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" download>Download</a>\r\n                </td>\r\n                <td>");
#nullable restore
#line 29 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
                Write(obj.Experience ? "Yes" : "No");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\ASP.NET\LinkedIn\Views\AppliedJob\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JobSeeker>> Html { get; private set; }
    }
}
#pragma warning restore 1591