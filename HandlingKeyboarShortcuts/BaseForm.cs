using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandlingKeyboarShortcuts
{



    public class BaseForm : Form
    {
        public event OnKeyBoardShortCutEventHandler OnKeyBoardShortCut;

        public BaseForm()
        {
            KeyPreview = true;
        }

        internal void RaiseOnKeyBoardShortCut(KeyEventArgs e)
        {
            RaisEvent(e);
        }

        private void RaisEvent(KeyEventArgs e)
        {
            if (this.OnKeyBoardShortCut != null)
            {
                OnKeyBoardShortCut(null, e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            RaiseOnKeyBoardShortCut(e);
            base.OnKeyDown(e);
        }
    }
}
