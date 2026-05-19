using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKK
{
    public partial class Visi_Misi : Form
    {
        public Visi_Misi()
        {
            InitializeComponent();
        }

        public void SetDataFromDB(int idPaslon)
        {
            DB db = new DB();
            DataTable dt = db.GetVisiMisi(idPaslon);

            if (dt.Rows.Count > 0)
            {
                lblvisi.Text = dt.Rows[0]["Visi"].ToString();
                lblmisi.Text = dt.Rows[0]["Misi"].ToString();
                lblproker.Text = dt.Rows[0]["Proker"].ToString();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                pnlvisi_misi.Visible = false;
            }
        }
        
        private void pnlvisi_misi_Paint(object sender, PaintEventArgs e)
        {
            
        }
        
        private void Visi_Misi_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblmisi_Click(object sender, EventArgs e)
        {

        }
    }
}
