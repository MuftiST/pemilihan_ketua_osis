using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PKK
{
    public partial class Pilih_Paslon_Putaran2 : Form
    {
        public Pilih_Paslon_Putaran2()
        {
            InitializeComponent();
        }
        public string NISN;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                DialogResult setuju = MessageBox.Show("Apakah Anda Yakin untuk memilih Paslon 1?", "Konfirmasi Pilihan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"update panitia set status_memilih = 'Sudah' where NISN = '{NISN}'");
                    DB.crud("update calon_pasangan set Jumlah_Suara = Jumlah_Suara + '1' where ID_Pasangan = 1");
                    LogOut pilih = new LogOut();
                    pilih.Visible = true;
                    this.Hide();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (true)
            {
                DialogResult setuju = MessageBox.Show("Apakah Anda Yakin untuk memilih Paslon 2?", "Konfirmasi Pilihan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"update panitia set status_memilih = 'Sudah' where NISN = '{NISN}'");
                    DB.crud("update calon_pasangan set Jumlah_Suara = Jumlah_Suara + '1' where ID_Pasangan = 2");
                    LogOut pilih = new LogOut();
                    pilih.Visible = true;
                    this.Hide();
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Visi_Misi vm = new Visi_Misi();
            vm.SetDataFromDB(1);
            List<Control> controls = new List<Control>(vm.Controls.Cast<Control>());

            foreach (Control ctrl in controls)
            {
                vm.Controls.Remove(ctrl);
                this.Controls.Add(ctrl);
                ctrl.BringToFront();
                ctrl.Width = (int)(ctrl.Width * 1.5);
                ctrl.Height = (int)(ctrl.Height * 1.5);
                ctrl.Location = new Point
                ((this.ClientSize.Width - ctrl.Width) / 2,
                (this.ClientSize.Height - ctrl.Height) / 2);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Visi_Misi vm = new Visi_Misi();
            vm.SetDataFromDB(2);
            List<Control> controls = new List<Control>(vm.Controls.Cast<Control>());

            foreach (Control ctrl in controls)
            {
                vm.Controls.Remove(ctrl);
                this.Controls.Add(ctrl);
                ctrl.BringToFront();
                ctrl.Width = (int)(ctrl.Width * 1.5);
                ctrl.Height = (int)(ctrl.Height * 1.5);
                ctrl.Location = new Point
                ((this.ClientSize.Width - ctrl.Width) / 2,
                (this.ClientSize.Height - ctrl.Height) / 2);
            }
        }
        private void TampilkanFoto(PictureBox pb, string idPasangan)
        {
            string folderFoto = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Pasangan\";
            string filePath = folderFoto + idPasangan + ".png";

            if (File.Exists(filePath))
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(filePath)))
                {
                    pb.Image = Image.FromStream(ms);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pb.Image = null;
                MessageBox.Show("Foto tidak ditemukan: " + filePath);
            }
        }
        private void TampilkanPaslon()
        {
            DB.crud("SELECT * FROM calon_pasangan inner join calon_ketua on calon_ketua.id_pasangan = calon_pasangan.id_pasangan inner join calon_wakil on calon_wakil.id_pasangan = calon_pasangan.id_pasangan");
            DataTable dt = DB.ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                string id1 = dt.Rows[0]["ID_Pasangan"].ToString();
                string kt = dt.Rows[0]["Nama_Ketua"].ToString();
                lblpaslon1.Text = kt;
                TampilkanFoto(Paslon1, id1);
            }

            if (dt.Rows.Count > 1)
            {
                string id2 = dt.Rows[1]["ID_Pasangan"].ToString();
                string nm = dt.Rows[1]["Nama_Ketua"].ToString();
                lblpaslon2.Text = nm;
                TampilkanFoto(Paslon2, id2);
            }
        }
        private void Pilih_Paslon_Putaran2_Load(object sender, EventArgs e)
        {
            TampilkanPaslon();
        }

        private void Pilih_Paslon_Putaran2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
