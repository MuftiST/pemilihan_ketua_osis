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
    public partial class Data_Paslon : Form
    {
        public Data_Paslon()
        {
            InitializeComponent();
        }

        public void bersih()
        {
            cmbid.SelectedItem = "";
            txtvisi.Text = "";
            txtmisi.Text = "";
            txtproker.Text = "";
        }

        private void Data_Paslon_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Data_Paslon_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbid_DropDown(object sender, EventArgs e)
        {
            cmbid.Items.Clear();
            cmbid.Items.Add("1");
            cmbid.Items.Add("2");
            cmbid.Items.Add("3");
            cmbid.Items.Add("4");
        }

        private void cmbid_DropDownClosed(object sender, EventArgs e)
        {
            string id = "" + cmbid.SelectedItem;
            DB.crud($"select * from calon_pasangan where id_pasangan = '{id}'");
            foreach (DataRow brs in DB.ds.Tables[0].Rows)
            {
                string visi = "" + brs["Visi"];
                string misi = "" + brs["Misi"];
                string proker = "" + brs["Proker"];
                txtvisi.Text = visi;
                txtmisi.Text = misi;
                txtproker.Text = proker;
                string fotoPath = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Pasangan\" + id + ".png";

                if (System.IO.File.Exists(fotoPath))
                {
                    foto_pasangan.ImageLocation = fotoPath; 
                }
                else
                {
                    foto_pasangan.ImageLocation = ""; 
                }
            }
        }

        OpenFileDialog fileDialog = new OpenFileDialog();
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (txtvisi.Text != "" || txtmisi.Text != "" || txtproker.Text != "")
            {
                string visi = txtvisi.Text;
                string misi = txtmisi.Text;
                string proker = txtproker.Text;
                string id = cmbid.Text;
                DB.crud($"update calon_pasangan set visi='{visi}', misi='{misi}', proker='{proker}' where id_pasangan='{id}'");
                if (fileDialog.FileName != "")
                {
                    string targetPath = @"C:\Users\Mufti\OneDrive\Documents\PKK\PKK\PKK\bin\Foto_Pasangan\" + id + ".png";

                    if (System.IO.File.Exists(targetPath))
                    {
                        System.IO.File.Delete(targetPath);
                    }

                    System.IO.File.Copy(fileDialog.FileName, targetPath);
                }
                MessageBox.Show("Data Berhasil diperbarui!");
            }
            bersih();
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "(*.jpg; *.png; *.jpeg)|*.JPG; *.PNG; *.JPEG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foto_pasangan.ImageLocation = fileDialog.FileName;
            }
        }

        private void foto_ketua_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_3(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}