using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandlingKeyboarShortcuts
{
    public partial class Form1 : BaseForm
    {
        // https://www.youtube.com/watch?v=dV-ockUtYT0
        public Form1()
        {
            InitializeComponent();

            OnKeyBoardShortCut += Form1_OnKeyBoardShortCut;
        }

        

        private void Form1_OnKeyBoardShortCut(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.A))
            {
                listBox1.Items.Add("Ctrl+Shift+A Pressed");
            }            
            if (e.KeyData==(Keys.Control|Keys.Tab))
            {
                listBox1.Items.Add("Ctrl+TAB Pressed");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
