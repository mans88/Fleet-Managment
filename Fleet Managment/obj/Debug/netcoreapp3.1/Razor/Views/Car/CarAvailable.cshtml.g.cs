#pragma checksum "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d92570c9e2897c98f321446102471bc3442a77c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_CarAvailable), @"mvc.1.0.view", @"/Views/Car/CarAvailable.cshtml")]
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
#line 1 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\_ViewImports.cshtml"
using Fleet_Managment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\_ViewImports.cshtml"
using Fleet_Managment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d92570c9e2897c98f321446102471bc3442a77c9", @"/Views/Car/CarAvailable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d76053a73716dc2577063af7ce91df6e5c123cbb", @"/Views/_ViewImports.cshtml")]
    public class Views_Car_CarAvailable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Fleet_Managment.Models.CarListingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateCar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
  
    ViewData["Title"] = "CarAvailable";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>CarAvailable</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d92570c9e2897c98f321446102471bc3442a77c93773", async() => {
                WriteLiteral("Create New Car");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Numberplate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Chassis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.VehicleStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDateContract));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDateContract));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Km));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Model.Brand.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
           Write(Html.DisplayNameFor(model => model.Fuel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 52 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 59 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Numberplate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Chassis));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.VehicleStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDateContract));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndDateContract));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 77 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Km));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Model.Brand.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 83 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.DisplayFor(modelItem => item.Fuel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.ActionLink("Edit", "Update", new { id = item.IdCar }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 90 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.IdCar }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 93 "C:\Users\Manssour\source\repos\Fleet Managment\Fleet Managment\Views\Car\CarAvailable.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Fleet_Managment.Models.CarListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
