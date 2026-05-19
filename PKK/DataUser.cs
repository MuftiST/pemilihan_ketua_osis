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
    public partial class DataUser : Form
    {
        public DataUser()
        {
            InitializeComponent();
        }

        private void DataUser_Load(object sender, EventArgs e)
        {
            
        }
        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            DB.crud("select * from panitia");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string nisn = "" + baris["nisn"];
                string nm = "" + baris["nama_lengkap"];
                string kls = "" + baris["Kelas"];
                string user = "" + baris["username"];
                string pass = "" + baris["password"];
                string hak = "" + baris["Hak"];
                string status = "" + baris["Status_memilih"];
                dataGridView1.Rows.Add(nisn, nm, kls, user, pass, hak, status);
            }
        }
        public void bersih()
        {
            txtnisn.Text = "";
            txtnama.Text = "";
            txtuser.Text = "";
            txtpass.Text = "";
            cmbhak.Text = "";
        }
        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (txtnama.Text != "" || txtnisn.Text != "" || txtkelas.Text != "" || txtuser.Text != "" || txtpass.Text != "" || cmbhak.SelectedIndex != -1)
            {
                string nisn = txtnisn.Text;
                string nm = txtnama.Text;
                string kls = txtkelas.Text;
                string user = txtuser.Text;
                string pass = txtpass.Text;
                string hak = cmbhak.Text;
                DB.crud($"insert into panitia (NISN, Nama_Lengkap, Kelas, Username, Password, Hak) values('{nisn}', '{nm}', '{kls}', '{user}', '{pass}', '{hak}')");
                tampildata();
                bersih();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int kolom = e.ColumnIndex;
            int brs = e.RowIndex;
            string id = dataGridView1.Rows[brs].Cells[0].Value.ToString();
            if (kolom == 7)
            {
                DB.crud($"select * from panitia where nisn = '{id}'");
                foreach (DataRow baris in DB.ds.Tables[0].Rows)
                {
                    string nisn = "" + baris["nisn"];
                    string nm = "" + baris["nama_lengkap"];
                    string user = "" + baris["username"];
                    string pass = "" + baris["password"];
                    string hak = "" + baris["Hak"];
                    txtnisn.Text = nisn;
                    txtnama.Text = nm;
                    txtuser.Text = user;
                    txtpass.Text = pass;
                    cmbhak.Text = hak;
                }
            }
            if (kolom == 8)
            {
                DialogResult setuju = MessageBox.Show("Peringatan!", "Apakah yakin ingin menghapus data?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"delete from panitia where nisn = '{id}'");
                    MessageBox.Show("Data Berhasil Dihapus!");
                }
                tampildata();
            }
        }

        private void cmbhak_DropDown(object sender, EventArgs e)
        {
            cmbhak.Items.Clear();
            cmbhak.Items.Add("Admin");
            cmbhak.Items.Add("Pemilih");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB.crud($"select * from panitia where nama_lengkap like '%{txtcari.Text}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string nisn = "" + baris["nisn"];
                string nm = "" + baris["nama_lengkap"];
                string user = "" + baris["username"];
                string pass = "" + baris["password"];
                string hak = "" + baris["Hak"];
                string status = "" + baris["Status_memilih"];
                dataGridView1.Rows.Add(nisn, nm, user, pass, hak, status);
            }
        }
    }
}
