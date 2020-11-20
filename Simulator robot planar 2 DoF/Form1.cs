using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Program by:fahmi mashuri
  source : https://github.com/fahmimsh/simulasi-robot-planar-3-dof 
  created time : 20/11/2020 */
namespace Simulator_robot_planar_2_DoF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double L1 = 2, L2 = 2, L3 = 2, Teta1 = 0.0, Teta2 = 0.0, Teta3 = 0.0;
        private double x1 = 2.5, x2 = 5.0, x3 = 0.0, y1 = 0.0, y2 = 0.0, y3 = 0.0;
        private void EndOfEffector()
        {
            x1 = L1 * Math.Cos(Teta1 * Math.PI / 180);
            y1 = L1 * Math.Sin(Teta1 * Math.PI / 180);

            x2 = x1 + L2 * Math.Cos((Teta1 + Teta2) * Math.PI / 180);
            y2 = y1 + L2 * Math.Sin((Teta1 + Teta2) * Math.PI / 180);

            x3 = x2 + L3 * Math.Cos((Teta1 + Teta2 + Teta3) * Math.PI / 180);
            y3 = y2 + L3 * Math.Sin((Teta1 + Teta2 + Teta3) * Math.PI / 180);

            textBox1.Text = Math.Round((decimal)x3, 4).ToString();
            textBox2.Text = Math.Round((decimal)y3, 4).ToString();

            double[] data1 = { x1, y1, x2, y2, x3, y3 };
            drawArm(0, 1, data1);
        }
        private void drawArm(int line, int dot, double[] data)
        {
            chart1.Series[line].Points[1].XValue = data[0];
            chart1.Series[line].Points[1].YValues[0] = data[1];
            chart1.Series[dot].Points[1].XValue = data[0];
            chart1.Series[dot].Points[1].YValues[0] = data[1];

            chart1.Series[line].Points[2].XValue = data[2];
            chart1.Series[line].Points[2].YValues[0] = data[3];
            chart1.Series[dot].Points[2].XValue = data[2];
            chart1.Series[dot].Points[2].YValues[0] = data[3];

            chart1.Series[line].Points[3].XValue = data[4];
            chart1.Series[line].Points[3].YValues[0] = data[5];
            chart1.Series[dot].Points[3].XValue = data[4];
            chart1.Series[dot].Points[3].YValues[0] = data[5];
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            else
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Teta1 = (double)numericUpDown3.Value;
            EndOfEffector(); 
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Teta2 = (double)numericUpDown4.Value;
            EndOfEffector();
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Teta3 = (double)numericUpDown6.Value;
            EndOfEffector();
        }
        private void knobteta1_ValueChanged(object Sender)
        {
            Teta1 = (double)knobteta1.Value;
            EndOfEffector();
        }
        private void knobteta2_ValueChanged(object Sender)
        {
            Teta2 = (double)knobteta2.Value;
            EndOfEffector();
        }
        private void knobteta3_ValueChanged(object Sender)
        {
            Teta3 = (double)knobteta3.Value;
            EndOfEffector();
        }
        private void slideteta1_ValueChanged(object sender, EventArgs e)
        {
            Teta1 = (double)slideteta1.Value;
            EndOfEffector();
        }
        private void slideteta2_ValueChanged(object sender, EventArgs e)
        {
            Teta2 = (double)slideteta2.Value;
            EndOfEffector();
        }
        private void slideteta3_ValueChanged(object sender, EventArgs e)
        {
            Teta3 = (double)slideteta3.Value;
            EndOfEffector();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericUpDown1.Value + L2 + L3 > 6)
            {
                MessageBox.Show("Batas maksimum nilai", "TURUNKAN NILAI !!");
                numericUpDown1.Value = (decimal)L1; 
            } else{
                L1 = (double)numericUpDown1.Value;
                EndOfEffector();
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericUpDown2.Value + L1 + L3 > 6)
            {
                MessageBox.Show("Batas Maksimum nilai", "TURUNKAN NILAI !!!");  
                numericUpDown2.Value = (decimal)L2; 
            } else{
                L2 = (double)numericUpDown2.Value;
                EndOfEffector(); 
            }
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericUpDown5.Value + L2 + L1> 6)
            {
                MessageBox.Show("Batas Maksimum nilai", "TURUNKAN NILAI !!!");
                numericUpDown5.Value = (decimal)L3;
            }
            else
            {
                L3 = (double)numericUpDown5.Value;
                EndOfEffector();
            }
        }
    }
}
