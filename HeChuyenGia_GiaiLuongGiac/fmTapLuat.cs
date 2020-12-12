using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HeChuyenGia_GiaiLuongGiac
{
    public partial class fmTapLuat : Form
    {
        public fmTapLuat()
        {
            InitializeComponent();
        }
        //a,b,c->p.( a + b + c ) / 2
        private void fmTapLuat_Load(object sender, EventArgs e)
        {
            dgvLuat.ReadOnly = true;

            List<string> ListSV = new List<string>();
            ListSV.AddRange(File.ReadAllLines("Rules.txt"));
           // string KQ = "";
            for (int i = 0; i < ListSV.Count; i++)
            {
                string tempSTT = " R "+i;
                string tempVT = " ";
                string tempVP = " ";
                string tempCongThuc = " ";
                tempVT += ListSV[i].Split('-')[0];
                tempVP += ListSV[i].Split('>')[1].Split('.')[0];
                tempCongThuc += tempVP + " = " + ListSV[i].Split('.')[1];

               // dgvLuat.Rows[0].Cells[0].Value = tempVT;
               // dgvLuat.Rows[0].Cells[1].Value = tempVP;
               // dgvLuat.Rows[0].Cells[2].Value = tempCongThuc;

                dgvLuat.Rows.Add(tempSTT,tempVT,tempVP,tempCongThuc);



            }

           
        }
    }
}
