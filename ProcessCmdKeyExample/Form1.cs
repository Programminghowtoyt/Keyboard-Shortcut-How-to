using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessCmdKeyExample
{

    //https://www.youtube.com/watch?v=_ozMnmxjV2s
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            OnKeyboardShortCut += Form1_OnKeyboardShortCut;
        }

        private void Form1_OnKeyboardShortCut(object Sender, KeyBoardShortCutEventArg e)
        {
            if(e.KeyData==(Keys.Control|Keys.A))
            {
                listBox1.Items.Add("Ctrl+A Pressed");
            }
            if (e.KeyData == (Keys.Control | Keys.Tab))
            {
                listBox1.Items.Add("Ctrl+Tab Pressed");
            }
            if (e.KeyData == (Keys.Control | Keys.Shift|Keys.A))
            {
                listBox1.Items.Add("Ctrl+Tab+A Pressed");
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
