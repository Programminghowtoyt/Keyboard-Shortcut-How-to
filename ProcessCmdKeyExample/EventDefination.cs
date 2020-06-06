using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessCmdKeyExample
{
    public class KeyBoardShortCutEventArg:EventArgs
    {
        public Message message { get; set; }
        public Keys KeyData { get; set; }
    }
    public delegate void OnKeyboardShortCutEventHandler(object Sender, KeyBoardShortCutEventArg e);
}
