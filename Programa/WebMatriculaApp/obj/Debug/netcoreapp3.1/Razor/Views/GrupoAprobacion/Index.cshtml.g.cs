#pragma checksum "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0bc1c0cc08041319bc9674a2d0b8245a49192b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GrupoAprobacion_Index), @"mvc.1.0.view", @"/Views/GrupoAprobacion/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0bc1c0cc08041319bc9674a2d0b8245a49192b3", @"/Views/GrupoAprobacion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9d2446035d71c3da8525f20322497d7f92c3a0", @"/Views/_ViewImports.cshtml")]
    public class Views_GrupoAprobacion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebMatriculaApp.Entities.GrupoAprobacion>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Top 15 Grupos con mayores Porcentajes de Aprobacion</h1>\n\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 13 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.grupoperiodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 16 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 22 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.nombreMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 28 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 31 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.grupoperiodo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 34 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 37 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 40 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.nombreMateria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 43 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/GrupoAprobacion/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebMatriculaApp.Entities.GrupoAprobacion>> Html { get; private set; }
    }
}
#pragma warning restore 1591
