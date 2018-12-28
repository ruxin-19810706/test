using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecuritySstem
{
    public partial class FrmWindow : Form
    {
        private FrmMain _frmMain = null;

        public FrmWindow(FrmMain frmMain, int width, int height)
        {
            InitializeComponent();

            _frmMain = frmMain;
            nudWidth.Value = width;
            nudHeight.Value = height;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _frmMain.WindowResize((int)nudWidth.Value, (int)nudHeight.Value);
        }
    }
}
