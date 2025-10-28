using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using DTOs;

namespace ReportePlanes
{
    public class ReportePlanesMateriasDocument : IDocument
    {
        private readonly List<PlanMateriaDTO> _data;

        public ReportePlanesMateriasDocument(List<PlanMateriaDTO> data)
        {
            _data = data ?? new List<PlanMateriaDTO>();
        }

        public DocumentMetadata GetMetadata() =>
            new DocumentMetadata
            {
                Title = "Reporte - Planes con Materias"
            };

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);

                page.Header()
                    .AlignCenter()
                    .Text("Reporte: Planes con Materias")
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
            container.Column(column =>
            {
                column.Spacing(15);


                if (_data.Count == 0)
                {
                    column.Item().AlignCenter().Text("No hay datos para mostrar.").FontSize(12);
                    return;
                }


                var planesAgrupados = _data.GroupBy(x => new { x.IdPlan, x.PlanDescripcion });

                foreach (var plan in planesAgrupados)
                {

                    column.Item().Text($"{plan.Key.PlanDescripcion}")
                        .FontSize(13)
                        .Bold()
                        .Underline();


                    column.Item().Element(tableContainer =>
                    {
                        tableContainer.Column(tabla =>
                        {

                            tabla.Item().Row(row =>
                            {
                                row.RelativeItem().Text("ID Materia").Bold();
                                row.RelativeItem(3).Text("Materia").Bold();
                                row.ConstantItem(80).AlignRight().Text("Hs Semanales").Bold();
                                row.ConstantItem(80).AlignRight().Text("Hs Totales").Bold();
                            });

                            tabla.Item().LineHorizontal(1);


                            foreach (var m in plan)
                            {
                                tabla.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(m.IdMateria.ToString());
                                    row.RelativeItem(3).Text(m.MateriaDescripcion);
                                    row.ConstantItem(80).AlignRight().Text(m.HsSemanales.ToString());
                                    row.ConstantItem(80).AlignRight().Text(m.HsTotales.ToString());
                                });
                            }
                        });
                    });

                    column.Item().PaddingTop(10).LineHorizontal(1);
                }
            });
        }
    }
}