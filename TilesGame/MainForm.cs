using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TilesGame
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            base.BackColor = Color.White;
            DoubleBuffered = true;
        }
    }
}
