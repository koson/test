using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace MetroFramework.Controls
{
    public class MetroBase
    {
        public class ValueChangedEventArgs : EventArgs
        {
  
            public object Value { get; set; }

        }

        public class BeforeValueChangedEventArgs : EventArgs
        {
   
            public object Value { get; set; }

            public bool Cancel { get; set; }
        }
    }
}
