using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dlina_xB = (double)(numericUpDown1.Value);
            Dlina_yB = (double)(numericUpDown2.Value);
            Mom = (double)(numericUpDown3.Value);
            Dlina_xC = (double)(numericUpDown7.Value);
            Dlina_yC = (double)(numericUpDown6.Value);
            F = (double)(numericUpDown4.Value);
            Alfa = 90 - (double)(numericUpDown5.Value);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

        }
        public static double Dlina_xB, Dlina_yB, Mom, F, Dlina_xC, Dlina_yC, Alfa;
        public static double X_A, Y_A, R_A, Ugol, R_B, Fx, Fy, CosAlpha, SinAlpha;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            CosAlpha = Math.Cos(Alfa * Math.PI / 180);
            SinAlpha = Math.Sin(Alfa * Math.PI / 180);

            Fx = F * CosAlpha;
            Fy = F * SinAlpha;


            if (radioButton1.Checked == true)
            {

                X_A = -Fx;
                R_B = -(Mom + Fy * Dlina_xC - Fx * Dlina_yC) / Dlina_xB;
                Y_A = -R_B - Fy;
                R_A = Math.Sqrt(X_A * X_A + Y_A * Y_A);
                Ugol = Math.Acos(X_A / R_A);


                if ((X_A < 0 && Y_A < 0) || (X_A > 0 && Y_A < 0))
                    Ugol = -Ugol;

                textBox3.Text = Convert_Strig(Convert.ToString(X_A));
                textBox7.Text = Convert_Strig(Convert.ToString(R_B));
                textBox5.Text = Convert_Strig(Convert.ToString(Y_A));
                textBox6.Text = Convert_Strig(Convert.ToString(Ugol * 180 / Math.PI));
                textBox4.Text = Convert_Strig(Convert.ToString(R_A));
            }

            else
            {
                Y_A = -Fy;
                R_B = (Mom + Fy * Dlina_xC - Fx * Dlina_yC) / Dlina_yB;
                X_A = -R_B - Fx;
                R_A = Math.Sqrt(X_A * X_A + Y_A * Y_A);
                Ugol = Math.Acos(X_A / R_A);


                if ((X_A < 0 && Y_A < 0) || (X_A > 0 && Y_A < 0))
                    Ugol = -Ugol;



                textBox3.Text = Convert_Strig(Convert.ToString(X_A));
                textBox7.Text = Convert_Strig(Convert.ToString(R_B));
                textBox5.Text = Convert_Strig(Convert.ToString(Y_A));
                textBox6.Text = Convert.ToString(Convert.ToInt32(Ugol * 180 / Math.PI));
                textBox4.Text = Convert_Strig(Convert.ToString(R_A));




            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Alfa = 90 - 70;
            //F = 8.0;
            //Mom = 12.0;
            //Dlina_xC = 3.0;
            //Dlina_yC = -3.0;
            //Dlina_xB = 4.0;
            //Dlina_yB = -5.0;
            Alfa = 90 - 50;
            F = 7.0;
            Mom = -14.0;
            Dlina_xC = 2.5;
            Dlina_yC = -2.6;
            Dlina_xB = 3.5;
            Dlina_yB = 1.2;
            radioButton1.Checked = false;
            radioButton2.Checked = true;

            numericUpDown1.Value = Convert.ToDecimal(Dlina_xB);
            numericUpDown2.Value = Convert.ToDecimal(Dlina_yB);
            numericUpDown3.Value = Convert.ToDecimal(Mom);
            numericUpDown7.Value = Convert.ToDecimal(Dlina_xC);
            numericUpDown6.Value = Convert.ToDecimal(Dlina_yC);
            numericUpDown4.Value = Convert.ToDecimal(F);
            numericUpDown5.Value = Convert.ToDecimal(90 - Alfa);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox3.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсовая работа \r\n Халяпиной Анастасии\r\nстудентки 4-го курса\r\nспециальность механика \r\nОдесского национального университета\r\n им. И.И.Мечникова.", " Компьютерное Моделирование в механие");
        }

        public static string Convert_Strig(string s)
        {
            string str = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    str += "," + s[i + 1] + s[i + 2] + s[i + 3];
                    return str;
                }
                str += s[i];
            }
            return str;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
