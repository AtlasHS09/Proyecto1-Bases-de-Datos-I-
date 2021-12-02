#pragma checksum "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/CantEstudiante/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d4dafa5c77acc2d7f1fe9570b6ef5fcd285a21f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CantEstudiante_Index), @"mvc.1.0.view", @"/Views/CantEstudiante/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d4dafa5c77acc2d7f1fe9570b6ef5fcd285a21f", @"/Views/CantEstudiante/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa9d2446035d71c3da8525f20322497d7f92c3a0", @"/Views/_ViewImports.cshtml")]
    public class Views_CantEstudiante_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<title>");
#nullable restore
#line 1 "/home/andres/Documents/Bases de Datos/BasesDeDatos1Final/WebMatriculaApp/WebMatriculaApp/WebMatriculaApp/Views/CantEstudiante/Index.cshtml"
  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" -  Estudiantes por Grupo por Periodo</title>
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

<div id=""chart_div""></div>
<script type=""text/javascript"">google.charts.load('current', {
        packages: ['corechart', 'bar']
    });
    google.charts.setOnLoadCallback(LoadData);

    function LoadData() {
        $.ajax({

            url: 'CantEstudiante/grafico',
            dataType: ""json"",
            type: ""GET"",
            error: function (xhr, status, error) {
                var err = eval(""("" + xhr.responseText + "")"");
                toastr.error(err.message);
            },
            success: function (data) {
                grafico(data);
                return false;
            }
        });
        return false;
    }

    function grafico(data) {
        var dataArray = [
            ['Periodo - Grupo', 'Cantidad']
        ];
        $.each(data, function (i, item) {
            dataArray.push([item.periodoGrupo, item.cantidad]);
        });
        ");
            WriteLiteral(@"var data = google.visualization.arrayToDataTable(dataArray);
        var options = {
            title: ' grado periodo mes',
            chartArea: {
                width: '50%'
            },
            colors: ['#b0120a', '#7b1fa2', '#ffab91'],
            hAxis: {
                title: 'gradoperiodomes',
                minValue: 0
            },
            vAxis: {
                title: 'Montos'
            }
        };
        var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));

        chart.draw(data, options);
        return false;
    }
    </script>  ");
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