using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeChuyenGia_GiaiLuongGiac.CongThuc;

namespace HeChuyenGia_GiaiLuongGiac
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangle_Problem.FormMain m = new Triangle_Problem.FormMain();
            m.ShowDialog();
        }

        private void btnSuKien_Click(object sender, EventArgs e)
        {
            TapSuKien sukien = new TapSuKien();
            sukien.ShowDialog();
        }

        private void btnTapLuat_Click(object sender, EventArgs e)
        {
            fmTapLuat luat = new fmTapLuat();
            luat.ShowDialog();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
