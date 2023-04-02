    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2_BZ
{
    public partial class Form1 : Form
    {   
        public double G1(double G)
        {
            double M = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 75.1))), 2);
            return M;
        }
        public double G2(double G)
        {
            double M = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 85.1))), 2);
            return M;
        }
        public double G3(double G)
        {
            double M = Math.Pow(Math.Exp(-0.2 * Math.Log(10 * Math.Abs(G - 100.1))), 2);
            return M;
        }
        public double W1(double W)
        {
            double M = 0.5 - 0.5 * Math.Sin(Math.PI / 15 * (W - 12.5));
            return M;
        }
        public double W2(double W)
        {
            double M = 1 - 0.5 * Math.Sin(Math.PI / 15 * Math.Abs(W - 12.5));
            return M;
        }
        public double W3(double W)
        {
            double M = 0.5 + 0.5 * Math.Sin(Math.PI / 15 * (W - 12.5));
            return M;
        }
        public Form1()
        {
            
            InitializeComponent();
            for(double G = 70; G <= 110; G++) {
                
                chart1.Series[0].Points.AddXY(G, G1(G));
            }
            for (double G = 70; G <= 110; G++)
            {
                chart1.Series[1].Points.AddXY(G, G2(G));
            }
            for (double G = 70; G <= 110; G++)
            {
                chart1.Series[2].Points.AddXY(G, G3(G));
            }

            for (double W = 5; W <= 20; W++)
            {
                chart2.Series[0].Points.AddXY(W, W1(W));
            }
            for (double W = 5; W <= 20; W++)
            {
                chart2.Series[1].Points.AddXY(W, W2(W));
            }
            for (double W = 5; W <= 20; W++)
            {
                chart2.Series[2].Points.AddXY(W, W3(W));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n11 = Math.Min(G1((double)(numericUpDown1.Value)), W1((double)(numericUpDown2.Value)));
            double n12 = Math.Min(G1((double)(numericUpDown1.Value)), W2((double)(numericUpDown2.Value)));
            double M1 = Math.Max(n11,n12);

            double n21 = Math.Min(G2((double)(numericUpDown1.Value)), W1((double)(numericUpDown2.Value)));
            double n22 = Math.Min(G2((double)(numericUpDown1.Value)), W2((double)(numericUpDown2.Value)));
            double n23 = Math.Min(G1((double)(numericUpDown1.Value)), W3((double)(numericUpDown2.Value)));
            double M2 = Math.Max(Math.Max(n21, n22), n23);

            double n31 = Math.Min(G2((double)(numericUpDown1.Value)), W3((double)(numericUpDown2.Value)));
            double n32 = Math.Min(G3((double)(numericUpDown1.Value)), W2((double)(numericUpDown2.Value)));
            double n33 = Math.Min(G3((double)(numericUpDown1.Value)), W3((double)(numericUpDown2.Value)));
            double M3 = Math.Max(Math.Max(n31, n32), n33);

            double n41 = Math.Sqrt(G1((double)(numericUpDown1.Value)));
            double n42 = Math.Max(Math.Max(W1((double)(numericUpDown2.Value)), W2((double)(numericUpDown2.Value))), W3((double)(numericUpDown2.Value)));
            double M4 = Math.Min(n41, n42);

            double Mp1 = Math.Min(Math.Min(Math.Min(1, (2 - M1)), Math.Min((1 - M2), (1 - M3))), (1 - M4));
            double Mp2 = Math.Min(Math.Min(Math.Min(1, (1 - M1)), Math.Min((2 - M2), (1 - M3))), (1 - M4));
            double Mp3 = Math.Min(Math.Min(Math.Min(1, (1 - M1)), Math.Min((1 - M2), (2 - M3))), (1 - M4));
            double Mp4 = Math.Min(Math.Min(Math.Min(1, (1 - M1)), Math.Min((1 - M2), (1 - M3))), (2 - M4));
            double M_fin = Math.Max(Math.Max(Mp1, Mp2), Math.Max(Mp3, Mp4));


            if (Mp1 == M_fin)
            {
                label1.Text = "Первый";
            }
            if (Mp2 == M_fin)
            {
                label1.Text = "Второй";
            }
            if (Mp3 == M_fin)
            {
                label1.Text = "Третий";
            }
            if (Mp4 == M_fin)
            {
                label1.Text = "Четвёртый";
            }

        }
    }
}
