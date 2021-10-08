using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=student;Integrated Security=TRUE");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            float d1, d2, d3, toplam;
            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select cinsiyet from student";
            //veri tabanında student adında veri tabanı ve student adında tablo var, tablolarda cinsiyet sütunu var, değerleri e veya k olacak
            dr = cmd.ExecuteReader();
            int erkeksayisi = 0;
            int kizsayisi = 0;
            while (dr.Read())
            {
                if (dr[0].ToString() == "e")
                {
                    erkeksayisi++;
                }
                else
                {
                    kizsayisi++;
                }
            }
            int s1 = erkeksayisi;
            int s2 = kizsayisi;
            int s3 = 20; //s3 kaldırılıp 2 değer tutulabilir. 20, öylesine girildi, değişken olabilir
            con.Close();
            d1 = erkeksayisi;
            d2 = kizsayisi;
            d3 = s3;
            toplam = d1 + d2+d3;
            float pd1, pd2, pd3;
            pd1 = (d1 / toplam) * 360;
            pd2 = (d2 / toplam) * 360;
            pd3 = (d3 / toplam) * 360;
            Pen p = new Pen(Color.Black, 2);
            Graphics g = this.CreateGraphics();
            Rectangle r = new Rectangle(button1.Location.X + button1.Size.Width + 50, 50, 200, 200);
            Brush b1 = new SolidBrush(Color.Green);
            Brush b2 = new SolidBrush(Color.Red);
            Brush b3 = new SolidBrush(Color.Blue);
            g.Clear(Form1.DefaultBackColor);
            g.DrawPie(p, r, 0, pd1);
            g.FillPie(b1, r, 0, pd1);
            g.DrawPie(p, r, pd1, pd2);
            g.FillPie(b2, r, pd1, pd2);
            g.DrawPie(p, r, pd1+pd2, pd3);
            g.FillPie(b3, r, pd1+pd2, pd3);


        }
    }
}
