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
    public partial class TapSuKien : Form
    {
        public TapSuKien()
        {
            InitializeComponent();
        }

        private void TapSuKien_Load(object sender, EventArgs e)
        {
           /*
            string tenfile = ".txt";
            FileStream fs1 = new FileStream(tenfile, FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fs1);
            fs1.Seek(0, SeekOrigin.Begin);//doc tu dau file
            string noidung1 = rd.ReadToEnd();
           
            rd.Close();
            fs1.Close();
            txtSuKien.Text = noidung1;
            * */

             List<string> ListSV= new List<string>();
             ListSV.AddRange(File.ReadAllLines("Facts.txt"));
             string KQ = "";
             for (int i = 1; i < ListSV.Count-1; i++)
             {
                 string tempStr = "    ";
                 tempStr = tempStr + ListSV[i] + "\n \n";
                 KQ += tempStr;
             }

             txtSuKien.Text = KQ;

        }
    }
}
