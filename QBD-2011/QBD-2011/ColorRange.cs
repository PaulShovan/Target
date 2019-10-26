using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace QBD_2011
{
    public partial class ColorRange : Form
    {
        MainForm form;
        public ColorRange(MainForm form)
        {
            InitializeComponent();
           textBox1.Text = form.vp.laser.colorFilter.Red.Min.ToString();
           textBox2.Text = form.vp.laser.colorFilter.Red.Max.ToString();
           textBox3.Text = form.vp.laser.colorFilter.Green.Min.ToString();
           textBox4.Text = form.vp.laser.colorFilter.Green.Max.ToString();
           textBox5.Text = form.vp.laser.colorFilter.Blue.Min.ToString();
           textBox6.Text = form.vp.laser.colorFilter.Blue.Max.ToString();
            this.form = form;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.vp.laser.colorFilter.Red = new IntRange(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
            form.vp.laser.colorFilter.Green = new IntRange(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
            form.vp.laser.colorFilter.Blue = new IntRange(Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            this.Dispose();
        }

        private void ColorRange_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
