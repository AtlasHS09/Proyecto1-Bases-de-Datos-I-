#pragma checksum "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ingreso/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6493aefa0bb7c788e01e9fc6de93f7a2202bf27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ingreso_Index), @"mvc.1.0.view", @"/Views/Ingreso/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6493aefa0bb7c788e01e9fc6de93f7a2202bf27", @"/Views/Ingreso/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9d2446035d71c3da8525f20322497d7f92c3a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Ingreso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<title>");
#nullable restore
#line 1 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/Ingreso/Index.cshtml"
  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" - Ingresos por Grupo por Periodo </title>
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

<div id=""chart_div""></div>
<script type=""text/javascript"">google.charts.load('current', {
        packages: ['corechart', 'bar']
    });
    google.charts.setOnLoadCallback(LoadData);

    function LoadData() {
        $.ajax({

            url: 'Ingreso/grafico',
            dataType: ""json"",
            type: ""GET"",
            error: function (xhr, status, error) {
                var err = eval(""("" + xhr.responseText + "")"");
                toastr.error(err.message);
            },
            success: function (data) {
                Grafico(data);
                return false;
            }
        });
        return false;
    }

    function Grafico(data) {
        var dataArray = [
            ['Ingreso', 'Porcentaje']
        ];
        $.each(data, function (i, item) {
            dataArray.push([item.grupoPeriodo, item.ingreso]);
        });
        var data = google");
            WriteLiteral(@".visualization.arrayToDataTable(dataArray);
        var options = {
            title: 'Ingresos ',
            chartArea: {
                width: '50%'
            },
            colors: ['#b0120a', '#7b1fa2'],
            hAxis: {
                title: 'Grupo - Periodo',
                minValue: 0
            },
            vAxis: {
                title: 'Porcentaje'
            }
        };
        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));

        chart.draw(data, options);
        return false;
    }</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
