#pragma checksum "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7460156deef44eb3f4f817a64155d3dc6ad4ff5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Details), @"mvc.1.0.view", @"/Views/Usuario/Details.cshtml")]
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
#line 1 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7460156deef44eb3f4f817a64155d3dc6ad4ff5f", @"/Views/Usuario/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0445ba62f944b24961b389f4f1ee135fabe0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebMatriculaNew.Entities.Usuario>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalle</h1>\r\n\r\n<div>\r\n    <h4>Usuario</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Cedula\r\n            <!--");
#nullable restore
#line 15 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Cedula));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Nombre Completo\r\n            <!--");
#nullable restore
#line 22 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Fecha de Nacimiento\r\n            <!--");
#nullable restore
#line 35 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaNacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.FechaNacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 41 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 44 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 47 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Provincia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 50 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Provincia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 53 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Residencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 56 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Residencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 59 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 62 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Fecha de Creacion\r\n            <!--");
#nullable restore
#line 66 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 69 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
       Write(Html.DisplayFor(model => model.FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7460156deef44eb3f4f817a64155d3dc6ad4ff5f10101", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "/Users/lorena.portillo/Projects/WebMatriculaNew/WebMatriculaNew/Views/Usuario/Details.cshtml"
                           WriteLiteral(Model.Cedula);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7460156deef44eb3f4f817a64155d3dc6ad4ff5f12232", async() => {
                WriteLiteral("Regresar a la Lista");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebMatriculaNew.Entities.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
