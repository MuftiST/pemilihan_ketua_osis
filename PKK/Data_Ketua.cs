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
    public partial class Data_Ketua : Form
    {
        public Data_Ketua()
        {
            InitializeComponent();
        }
        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            DB.crud("select * from calon_ketua");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["ID_Ketua"];
                string nisn = "" + baris["NISN"];
                string nm = "" + baris["Nama_Ketua"];
                string kls = "" + baris["Kelas"];
                string idp = "" + baris["ID_Pasangan"];
                
                dataGridView1.Rows.Add(id, nisn, nm, kls, idp);
            }
        }
        public void bersih()
        {
            txtnisn.Text = "";
            txtnama.Text = "";
            txtkelas.Text = "";
            id_ketua.Text = "";
            foto_ketua.Image = null;
        }

        private void guna2ComboBox1_DropDown(object sender, EventArgs e)
        {
           
        }

        OpenFileDialog fileDialog = new OpenFileDialog();
        private void btnupload_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "(*.jpg; *.png; *.jpeg)|*.JPG; *.PNG; *.JPEG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foto_ketua.ImageLocation = fileDialog.FileName;
            }
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int kolom = e.ColumnIndex;
            int brs = e.RowIndex;
            string idk = dataGridView1.Rows[brs].Cells[0].Value.ToString();
            
            if (brs < 0) return;

            if (kolom == 2) 
            {
                string nama = dataGridView1.Rows[brs].Cells[kolom].Value?.ToString().ToUpper();

                if (!string.IsNullOrEmpty(nama))
                {
                    string path = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Ketua\" + nama + ".png";

                    if (System.IO.File.Exists(path))
                    {
                        foto_ketua.ImageLocation = path;
                    }
                    else
                    {
                        MessageBox.Show("Foto tidak ditemukan: ");
                        foto_ketua.Image = null;
                    }
                }
                DB.crud($"select * from calon_ketua where ID_Ketua = '{idk}'");
                foreach (DataRow baris in DB.ds.Tables[0].Rows)
                {
                    string id = "" + baris["ID_Ketua"];
                    string nisn = "" + baris["NISN"];
                    string nm = "" + baris["Nama_Ketua"];
                    string kls = "" + baris["Kelas"];
                    id_ketua.Text = id;
                    txtnisn.Text = nisn;
                    txtnama.Text = nm;
                    txtkelas.Text = kls;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string id = id_ketua.Text;
            string nisn = txtnisn.Text;
            string nm = txtnama.Text.ToUpper();
            string kls = txtkelas.Text.ToUpper();
            DB.crud($"update calon_ketua set id_ketua='{id}', nisn='{nisn}', nama_ketua='{nm}', kelas='{kls}' where id_ketua = '{id}'");
            if (fileDialog.FileName != "")
            {
                string targetPath = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Ketua\" + nm + ".png";

                if (System.IO.File.Exists(targetPath))
                {
                    System.IO.File.Delete(targetPath);
                }
                System.IO.File.Copy(fileDialog.FileName, targetPath);
            }
            MessageBox.Show("Data Berhasil diperbarui!");
            tampildata();
            bersih();
        }

        private void cmbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void foto_ketua_Click(object sender, EventArgs e)
        {

        }

        private void Data_Ketua_Load(object sender, EventArgs e)
        {
            tampildata();
        }

        private void labelid_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_DropDown_1(object sender, EventArgs e)
        {
            
        }

        private void id_pasangan_DropDown(object sender, EventArgs e)
        {
            
        }

        private void id_ketua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void id_ketua_DropDown(object sender, EventArgs e)
        {
            
        }

        

        private void id_ketua_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void id_ketua_DropDownClosed(object sender, EventArgs e)
        {
            
            
        }
    }
}
