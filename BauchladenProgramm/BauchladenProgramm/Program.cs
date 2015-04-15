using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BauchladenProgramm
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Connector.Connector c = new Connector.Connector("192.168.178.33", 3000);
            c.connectToServer();
            c.sendMessageToServer("begin:1");
            c.sendMessageToServer("Hallo");
            c.sendMessageToServer("end:1");
            Thread.Sleep(2000);
            c.closeConnection();
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainwindow());*/
        }
    }
}
