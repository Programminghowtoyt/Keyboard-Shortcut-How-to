using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibHotKeys;

namespace HotKeysExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        public void ShowForm(HotKey k)
        {
            listBox1.Items.Add(string.Format("{0} hot key Capture", k.Purpose));
            this.Activate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                HotKeyController.Instance.UnRegisterHotKey(ApplicationStrings.ActivateMainForm);
                listBox1.Items.Add(string.Format("{0} hot key is Removed ", ApplicationStrings.ActivateMainForm));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { 
            HotKeyController.Instance.ReplaceHotKey(ApplicationStrings.ActivateMainForm, KeyModifiers.CONTROL|KeyModifiers.Alt, Keys.A, new Action<HotKey>(ShowForm));
                listBox1.Items.Add(string.Format("{0} hot key is replaced ", ApplicationStrings.ActivateMainForm));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            { 
            HotKeyController.Instance.RegisterHotKey(ApplicationStrings.ActivateMainForm, KeyModifiers.CONTROL, Keys.A, new Action<HotKey>(ShowForm));
                listBox1.Items.Add(string.Format("{0} hot key is Registered ", ApplicationStrings.ActivateMainForm));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
