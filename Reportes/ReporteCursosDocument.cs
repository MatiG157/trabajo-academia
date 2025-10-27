using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using DTOs;

namespace ReporteCursos
{
    public class ReporteCursosDocument : IDocument
    {
        private readonly List<CursoCountDTO> _data;

        public ReporteCursosDocument(List<CursoCountDTO> data)
        {
            _data = data ?? new List<CursoCountDTO>();
        }

        public DocumentMetadata GetMetadata() =>
            new DocumentMetadata
            {
                Title = "Reporte - Cantidad de Alumnos por Curso"
            }; 

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);

                page.Header()
                    .Height(50)
                    .AlignCenter()
                    .Text("Reporte: Cantidad de alumnos por curso")
                    .FontSize(16)
                    .Bold();

                page.Content()
                    .PaddingTop(10)
                    .Element(ComposeContent);

                page.Footer()
                    .AlignCenter()
                    .Text($"Generado el {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
                    .FontSize(9);
            });
        }

        private void ComposeContent(IContainer container)
        {
            var maxAlumnos = _data.Any() ? _data.Max(d => d.Cantidad) : 1;

            container.Column(column =>
            {
                column.Spacing(20);

                
                column.Item().Element(tableContainer =>
                {
                    tableContainer.Column(tabla =>
                    {
                        tabla.Spacing(5);

                        
                        tabla.Item().Row(row =>
                        {
                            row.RelativeItem().Text("ID").Bold();
                            row.RelativeItem(3).Text("Descripción").Bold();
                            row.ConstantItem(60).AlignRight().Text("Alumnos").Bold();
                        });

                        tabla.Item().LineHorizontal(1);

                       
                        foreach (var d in _data)
                        {
                            tabla.Item().Row(row =>
                            {
                                row.RelativeItem().Text(d.IdCursoCount.ToString());
                                row.RelativeItem(3).Text(d.Descripcion);
                                row.ConstantItem(60).AlignRight().Text(d.Cantidad.ToString());
                            });
                        }

                       
                        if (!_data.Any())
                            tabla.Item().PaddingTop(20).AlignCenter().Text("No hay cursos para mostrar.");
                    });
                });

               
                column.Item()
                    .AlignCenter()
                    .Text("Cantidad de alumnos por curso (Gráfico de barras vertical)")
                    .FontSize(12)
                    .Bold();

            
                column.Item().AlignCenter().Height(300).Element(chart =>
                {
                    chart.Row(row =>
                    {
                        row.Spacing(10); 

                        foreach (var d in _data)
                        {
                            float porcentaje = (float)d.Cantidad / maxAlumnos; 

                        
                            var color = porcentaje > 0.7 ? Colors.Green.Medium :
                                        porcentaje > 0.4 ? Colors.Orange.Medium :
                                        Colors.Red.Medium;

                            row.RelativeItem().AlignBottom().Element(col =>
                            {
                                col.Column(columna =>
                                {
                                    columna.Spacing(3);

                                   
                                    columna.Item()
                                        .AlignCenter()
                                        .PaddingBottom(2)
                                        .Text(d.Cantidad.ToString())
                                        .FontSize(9)
                                        .Bold();

                                  
                                    columna.Item()
                                        .Height(porcentaje * 250) 
                                        .Width(25)
                                        .Background(color)        
                                        .CornerRadius(3);

                                    columna.Item()
                                        .Width(50)
                                        .AlignCenter()
                                        .Text(d.Descripcion)
                                        .FontSize(8);
                                });
                            });
                        }
                    });
                });

                if (!_data.Any())
                    column.Item().PaddingTop(20).AlignCenter().Text("No hay cursos para mostrar.");
            });
        }
    }
}