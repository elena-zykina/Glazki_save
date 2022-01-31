using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Glazki_save.DataBase
{
    class Transition
    {
        public static Frame MainFrame { get; set; }
        private static GlazkiSaveEntities context;
        public static GlazkiSaveEntities Context
        {
            get
            {
                if (context == null)
                    context = new GlazkiSaveEntities();
                return context;
            }
                
        }
    }
}
