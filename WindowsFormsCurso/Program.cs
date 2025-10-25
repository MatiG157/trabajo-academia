using QuestPDF.Infrastructure;
using WindowsFormsCurso;
using QuestPDF;

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura la licencia de QuestPDF antes de cualquier uso
            QuestPDF.Settings.License = LicenseType.Community;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new InicioSesion());

        }
    }
}