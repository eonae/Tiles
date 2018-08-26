using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TilesGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        public static MainForm Form { get; set; }
        public static Model Model { get; set; }
        public static Controller Controller { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Form = new MainForm();
            Model = new Model();
            Controller = new Controller(Model, Form);
            Form.Paint += Controller.Paint;

            Form.MouseMove += Controller.MouseMove;
            Form.MouseDown += Controller.MouseDown;
            Form.MouseUp += Controller.MouseUp;

            Application.Run(Form);
        }
    }
}
