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
    public partial class Form2 : BaseForm
    {
        public Form2()
        {
            InitializeComponent();
            //OnKeyBoardShortCut += Form2_OnKeyBoardShortCut;
        }

        private void Form2_OnKeyBoardShortCut(object sender, KeyEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
