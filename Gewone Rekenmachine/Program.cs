using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gewone_Rekenmachine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string enummap = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Rekenmachine/Enums/";
            string funcmap = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Rekenmachine/Functies/";
            Directory.CreateDirectory(enummap);
            Directory.CreateDirectory(funcmap);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Hoofdscherm());
        }
    }
}
