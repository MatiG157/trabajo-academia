
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Reportes;

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

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Reporte_Cursos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    var pdfBytes = await ReportesApiClient.GetReporteCursosAsync();
                    await File.WriteAllBytesAsync(sfd.FileName, pdfBytes);

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

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"Reporte_Planes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    var pdfBytes = await ReportesApiClient.GetReportePlanesAsync();
                    await File.WriteAllBytesAsync(sfd.FileName, pdfBytes);

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
