using ObjTool;
using System;
using System.Windows.Forms;
namespace CG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = ProgramX.drawBitmap();
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
