#pragma checksum "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fc469e64e97f514e4d36bbc3d828547eb6690ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grupo_AsistenciaXGrupo), @"mvc.1.0.view", @"/Views/Grupo/AsistenciaXGrupo.cshtml")]
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
#line 1 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fc469e64e97f514e4d36bbc3d828547eb6690ce", @"/Views/Grupo/AsistenciaXGrupo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0445ba62f944b24961b389f4f1ee135fabe0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Grupo_AsistenciaXGrupo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebMatriculaNew.Entities.AsistenciaXGrupo>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
  
    ViewData["Title"] = "Asitencia x Grupo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.CodigoGrupo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.CedulaEstudiante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.Porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodigoGrupo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.CedulaEstudiante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.Porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           <!-- <td>\r\n                <a asp-action=\"Edit\" asp-route-id=\"");
#nullable restore
#line 37 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
                                              Write(item.CodigoGrupo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Edit</a> |\r\n                <a asp-action=\"Details\" asp-route-id=\"");
#nullable restore
#line 38 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
                                                 Write(item.CodigoGrupo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Details</a> |\r\n                <a asp-action=\"Delete\" asp-route-id=\"");
#nullable restore
#line 39 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
                                                Write(item.CodigoGrupo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Delete</a>\r\n                <a asp-action=\"AsistenciaXGrupo\" asp-route-id=\"");
#nullable restore
#line 40 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
                                                          Write(item.CodigoGrupo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Asistencia x Grupo</a>\r\n            </td> -->\r\n        </tr>\r\n");
#nullable restore
#line 43 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/AsistenciaXGrupo.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebMatriculaNew.Entities.AsistenciaXGrupo>> Html { get; private set; }
    }
}
#pragma warning restore 1591