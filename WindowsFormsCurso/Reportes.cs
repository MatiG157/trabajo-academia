using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using ReporteCursos;
using QuestPDF.Fluent;
using Reportes;

namespace WindowsFormsCurso
{
    public partial class Reportes : Form
    {

        public Reportes()
        {
            InitializeComponent();
        }

        private async void reporteCursosButton_Click(object sender, EventArgs e)
        {
            try
            {
                reporteCursosButton.Enabled = false;

                var repo = new CursoRepository();
                var data = await repo.GetCursosConCantidadAlumnosAsync();

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Reporte_Cursos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    var doc = new ReporteCursosDocument(data);
                    doc.GeneratePdf(sfd.FileName);

                    MessageBox.Show($"Reporte generado:\n{sfd.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reporteCursosButton.Enabled = true;
            }
        }

        private async void reportePlanesButton_Click(object sender, EventArgs e)
        {
            try
            {
                reportePlanesButton.Enabled = false;

                // Obtener los datos desde el repositorio
                var repo = new PlanRepository(); // <- ajustá el nombre según tu clase real
                var data = await repo.GetPlanesConMateriasAsync(); // <- ajustá según tu método real

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Reporte_Planes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    // Generar el documento PDF
                    var doc = new ReportePlanesMateriasDocument(data); // <- ajustá el nombre de tu clase
                    doc.GeneratePdf(sfd.FileName);

                    MessageBox.Show($"Reporte generado:\n{sfd.FileName}",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                reportePlanesButton.Enabled = true;
            }
        }

    }
}
