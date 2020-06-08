using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHotKeys
{
    public class AlreadyMappedException:Exception
    {

        public AlreadyMappedException(HotKey key)
            : base(string.Format("Key is already Defined for this {0} purpose",key.Purpose))
        {

        }
        
    }

    public class KeyNotFoundException : Exception
    {

        public KeyNotFoundException(string purpose)
            : base(string.Format("Key not found for this {0} purpose. cannot perform this action", purpose))
        {

        }

    }
}
