#pragma checksum "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2d8864e97f1dbc10bf2b7085870592bb266653d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_AddProductResult), @"mvc.1.0.view", @"/Views/Product/AddProductResult.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2d8864e97f1dbc10bf2b7085870592bb266653d", @"/Views/Product/AddProductResult.cshtml")]
    public class Views_Product_AddProductResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<My_Expenses.ViewModels.ProductModels.AddProductResultModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "HomePage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    .resultContainer {\r\n        padding: 50px;\r\n    }\r\n</style>\r\n\r\n<div class=\"resultContainer\">\r\n    <h4>Add product result:</h4>\r\n    <p>");
#nullable restore
#line 15 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
  Write(Model.ResultMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 16 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
     if (Model.IsValid)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Product name: ");
#nullable restore
#line 18 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
                    Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Cost: ");
#nullable restore
#line 19 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
            Write(Model.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Left on spending account: ");
#nullable restore
#line 20 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
                                Write(Model.AmountLeft);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "C:\Users\Sasho\Desktop\MVC\My-Expenses\My-Expenses\My-Expenses\Views\Product\AddProductResult.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Back to ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2d8864e97f1dbc10bf2b7085870592bb266653d4960", async() => {
                WriteLiteral("Home page");
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
            WriteLiteral("</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<My_Expenses.ViewModels.ProductModels.AddProductResultModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
