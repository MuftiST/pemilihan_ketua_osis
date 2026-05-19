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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnlogin_Click(object sender, EventArgs e)
        {
            DB.crud($"select * from panitia where username = '{txtuser.Text}' and password = '{txtpass.Text}'");
            int cekbaris = DB.ds.Tables[0].Rows.Count;

            if (cekbaris == 1)
            {
                string role = DB.ds.Tables[0].Rows[0]["Hak"].ToString();
                string status = DB.ds.Tables[0].Rows[0]["status_memilih"].ToString();

                if (role == "Admin")
                {
                    DashAdmin fm = new DashAdmin();
                    fm.Visible = true;
                    this.Hide();
                    DB.crud("SELECT SUM(jumlah_suara) AS jumlah_suara FROM calon_pasangan");
                }
                else if (role == "Pemilih")
                {
                    if (status == "Sudah")
                    {
                        MessageBox.Show("Anda sudah melakukan pemilihan!\nTidak dapat masuk kembali.",
                                        "Akses Ditolak",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return; 
                    }
                    DataRow baris = DB.ds.Tables[0].Rows[0];
                    string nisn= "" + baris["NISN"];

                    //jika ada putaran 2, tambahkan Putaran2 setelah Pilih_Paslon dibawah ini
                    Pilih_Paslon fm = new Pilih_Paslon();

                    fm.Visible = true;
                    fm.NISN = nisn;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hak tidak dikenali!");
                }
            }
            else
            {
                MessageBox.Show("Username atau Password salah!");
            }
        }

        private void txtpass_IconRightClick(object sender, EventArgs e)
        {
            
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        
        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
