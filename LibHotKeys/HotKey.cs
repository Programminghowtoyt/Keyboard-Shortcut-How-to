using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibHotKeys
{
    public class HotKey
    {
        public int id { get; set; } 
        public KeyModifiers fsModifiers { get; set; }
        public Keys vk { get; set; }
        public Action<HotKey> OnPressed { get; set; }
        public string Purpose { get; set; }
    }
}
