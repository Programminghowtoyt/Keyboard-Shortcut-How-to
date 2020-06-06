using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessCmdKeyExample
{
    

    public class BaseForm :Form
    {
        public event OnKeyboardShortCutEventHandler OnKeyboardShortCut;

       void RaisOnKeyboardShortCut(KeyBoardShortCutEventArg e)
        {
            if(OnKeyboardShortCut!=null)
            {
                OnKeyboardShortCut(null, e);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            RaisOnKeyboardShortCut(new KeyBoardShortCutEventArg() { message = msg, KeyData = keyData });
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
