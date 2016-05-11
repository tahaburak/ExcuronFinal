using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excuron
{
    public partial class Loading : Form
    {
        
        public Loading(String text)
        {
            InitializeComponent();
            label1.Text = text;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
    }
}
