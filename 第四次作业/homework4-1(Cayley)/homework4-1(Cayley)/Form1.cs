using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework4_1_Cayley_
{
    public partial class cayleytree : Form
    {
        public int N { get; set; }                     // 递归深度
        public double Th1 { get; set; }                // 右分支角度
        public double Th2 { get; set; }                // 左分支角度
        public double Per1 { get; set; }               // 右分支长度
        public double Per2 { get; set; }               // 左分支长度
        public double Length { get; set; }             // 树枝长度
        public double BifurcateFactor { get; set; }    //两棵子树分叉的因子

        public bool isRandom { get; set; }             //是否随机产生参数

        private Graphics graphics;
        private Pen pen;
        private Random rd = new Random();
        public cayleytree()
        {
            InitializeComponent();
        }

        private void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, Per1 * leng, th + Th1);
            DrawCayleyTree(n - 1, x1, y1, Per2 * leng, th - Th2);
        }
             
        void DrawDynamic()
        {
       
     
            //绘图
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(BackColor);

            DrawCayleyTree(N, panel1.Width / 2, panel1.Height - 10, Length, -Math.PI / 2);
        }
        private void DrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

       

        private void DrawButton_Load(object sender, EventArgs e)
        {
            N = 12;
            Th1 = Math.Round(30 * Math.PI / 180, 2);
            Th2 = Math.Round(20 * Math.PI / 180, 2);
            Per1 = 0.7;
            Per2 = 0.8;
            Length = 100;
            BifurcateFactor = 1;
            isRandom = false;

         

            graphics = this.panel1.CreateGraphics();
            pen = new Pen(Color.Cyan);
            pen.Width += 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            dialogColor.ShowDialog();
            pen.Color = dialogColor.Color;
            ColorButton.BackColor = dialogColor.Color;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void th2_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            per1_box.Invalidate();

            start();
        }
        private void start()
        {
            graphics.Clear(Color.White);
            DrawDynamic();
          
        }
        private void N_box_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void per1_box_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void per2_box_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void length_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
