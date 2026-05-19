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
    public partial class Data_Wakil : Form
    {
        public Data_Wakil()
        {
            InitializeComponent();
        }
        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            DB.crud("select * from calon_wakil");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["ID_Wakil"];
                string nisn = "" + baris["NISN"];
                string nm = "" + baris["Nama_Wakil"];
                string kls = "" + baris["Kelas"];
                string idp = "" + baris["ID_Pasangan"];

                dataGridView1.Rows.Add(id, nisn, nm, kls, idp);
            }
        }
        public void bersih()
        {
            
        }

        private void cmbkelas_DropDown(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Data_Wakil_Load(object sender, EventArgs e)
        {
            tampildata();
        }
        OpenFileDialog fileDialog = new OpenFileDialog();
        private void btnubah_Click(object sender, EventArgs e)
        {
            string id = id_wakil.Text;
            string nisn = txtnisn.Text;
            string nm = txtnama.Text.ToUpper();
            string kls = txtkelas.Text.ToUpper();
            DB.crud($"update calon_wakil set id_wakil='{id}', nisn='{nisn}', nama_wakil='{nm}', kelas='{kls}' where id_wakil = '{id}'");
            if (fileDialog.FileName != "")
            {
                string targetPath = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Wakil\" + nm + ".png";

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

        private void btnupload_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "(*.jpg; *.png; *.jpeg)|*.JPG; *.PNG; *.JPEG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foto_ketua.ImageLocation = fileDialog.FileName;
            }
        }
    }
}
