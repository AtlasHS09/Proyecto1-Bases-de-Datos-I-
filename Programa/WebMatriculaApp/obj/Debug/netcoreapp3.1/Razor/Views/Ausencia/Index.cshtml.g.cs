#pragma checksum "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a51e95af429b5a3ec5ab8139621e310d76090dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ausencia_Index), @"mvc.1.0.view", @"/Views/Ausencia/Index.cshtml")]
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
#line 1 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/_ViewImports.cshtml"
using WebMatriculaApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/_ViewImports.cshtml"
using WebMatriculaApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a51e95af429b5a3ec5ab8139621e310d76090dc", @"/Views/Ausencia/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9d2446035d71c3da8525f20322497d7f92c3a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Ausencia_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebMatriculaApp.Entities.Ausencia>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Top 10 Estudiantes con mas Ausencias</h1>\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 13 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 16 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 22 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 25 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 28 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 31 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ausencia/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebMatriculaApp.Entities.Ausencia>> Html { get; private set; }
    }
}
#pragma warning restore 1591
