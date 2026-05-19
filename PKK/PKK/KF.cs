using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKK
{
    class KF
    {
        public static void untukform(Form formapa, Panel pnlapa)
        {
            pnlapa.Controls.Clear();
            pnlapa.Controls.Add(formapa);
            formapa.FormBorderStyle = FormBorderStyle.None;
            formapa.Dock = DockStyle.Fill;
            formapa.Show();
        }
    }
}
