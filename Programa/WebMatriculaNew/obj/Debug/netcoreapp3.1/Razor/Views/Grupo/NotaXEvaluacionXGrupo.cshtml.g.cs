#pragma checksum "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a3f059d6828daa7c4e7d8cbd1208da6407351e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Grupo_NotaXEvaluacionXGrupo), @"mvc.1.0.view", @"/Views/Grupo/NotaXEvaluacionXGrupo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a3f059d6828daa7c4e7d8cbd1208da6407351e5", @"/Views/Grupo/NotaXEvaluacionXGrupo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0445ba62f944b24961b389f4f1ee135fabe0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Grupo_NotaXEvaluacionXGrupo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebMatriculaNew.Entities.NotaXEvaluacionXGrupo>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
  
    ViewData["Title"] = "Nota x Evaluacion x Grupo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.Evaluacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.Porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.CedulaEstudiante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayNameFor(model => model.Resultado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.Evaluacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.Porcentaje));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.CedulaEstudiante));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
           Write(Html.DisplayFor(modelItem => item.Resultado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 43 "/home/andres/Documents/Bases de Datos/Proyecto1-Bases-de-Datos-I-/Programa/WebMatriculaNew/Views/Grupo/NotaXEvaluacionXGrupo.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebMatriculaNew.Entities.NotaXEvaluacionXGrupo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
