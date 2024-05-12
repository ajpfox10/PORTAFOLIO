using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static readonly String DEST = "C:\\FORMULARIOS\\TICKETS.pdf";

        public static readonly String SRC = "C:\\FORMULARIOS\\TICKETS 1.pdf";

        public static readonly String CHECKED_FIELD_NAME = "checked";
        public static readonly String UNCHECKED_FIELD_NAME = "unchecked";

        public static readonly String CHECKED_STATE_VALUE = "Yes";
        public static readonly String UNCHECKED_STATE_VALUE = "Off";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FORMULARIOPRINCIPAL());           
        }
    }
}
