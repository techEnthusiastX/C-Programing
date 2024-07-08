using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            c.show();
            int num = Convert.ToInt16(textBox1.Text);
            MessageBox.Show("Square: " + c.getSquare(num));
        }
    }
}
