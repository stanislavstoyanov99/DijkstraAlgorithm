namespace DijkstraAlgorithm.App
{
    using System;
    using System.Windows.Forms;

    using DijkstraAlgorithm.Models;
    using DijkstraAlgorithm.Models.Interfaces;

    using DijkstraAlgorithm.InputOutput;
    using DijkstraAlgorithm.InputOutput.Interfaces;

    public static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            IExporter exporter = new Exporter();
            IImporter importer = new Importer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(importer, exporter));
        }
    }
}
