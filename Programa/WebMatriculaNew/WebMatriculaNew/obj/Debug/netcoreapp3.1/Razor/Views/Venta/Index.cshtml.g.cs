#pragma checksum "/home/andres/Documents/Bases de Datos/WebMatriculaNew 2/WebMatriculaNew/WebMatriculaNew/Views/Venta/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94a261d1ad8f33d0681fa5f4c2e9de7a85b64224"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venta_Index), @"mvc.1.0.view", @"/Views/Venta/Index.cshtml")]
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
#line 1 "/home/andres/Documents/Bases de Datos/WebMatriculaNew 2/WebMatriculaNew/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/andres/Documents/Bases de Datos/WebMatriculaNew 2/WebMatriculaNew/WebMatriculaNew/Views/_ViewImports.cshtml"
using WebMatriculaNew.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94a261d1ad8f33d0681fa5f4c2e9de7a85b64224", @"/Views/Venta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb0445ba62f944b24961b389f4f1ee135fabe0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Venta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<title>");
#nullable restore
#line 1 "/home/andres/Documents/Bases de Datos/WebMatriculaNew 2/WebMatriculaNew/WebMatriculaNew/Views/Venta/Index.cshtml"
  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" - Ventas por Periodo </title>
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

<div id=""chart_div""></div>
<script type=""text/javascript"">google.charts.load('current', {
        packages: ['corechart', 'bar']
    });
    google.charts.setOnLoadCallback(LoadData);

    function LoadData() {
        $.ajax({

            url: 'Venta/Grafico',
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
            ['gp', 'cobros']
        ];
        $.each(data, function (i, item) {
            dataArray.push([item.gp, item.cobros]);
        });
        var data = google.visualization.arrayToDataTable(da");
            WriteLiteral(@"taArray);
        var options = {
            title: ' Distribucion de Ventas ',
            chartArea: {
                width: '50%'
            },
            colors: ['#b0120a', '#7b1fa2'],
            hAxis: {
                title: 'Periodo',
                minValue: 0
            },
            vAxis: {
                title: 'Distribucion'
            }
        };
        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));

        chart.draw(data, options);
        return false;
    }</script>
");
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
