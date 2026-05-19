using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;

namespace PKK
{
    public partial class DashAdmin : Form
    {
        private void TampilkanChart()
        {
            DataTable dt = DB.chart("SELECT calon_ketua.Nama_Ketua AS nama_ketua,calon_wakil.Nama_Wakil AS nama_wakil,calon_pasangan.Jumlah_Suara FROM calon_pasangan INNER JOIN calon_ketua ON calon_pasangan.ID_Ketua = calon_ketua.ID_Ketua INNER JOIN calon_wakil ON calon_pasangan.ID_Wakil = calon_wakil.ID_Wakil ORDER BY calon_pasangan.Jumlah_Suara DESC");

            if (dt.Rows.Count == 0) return;

            // Reset chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Tambah ChartArea baru
            ChartArea area = new ChartArea("area1");
            chart1.ChartAreas.Add(area);

            // Tambah Legend
            Legend legend = new Legend("legend1");
            legend.Docking = Docking.Bottom;
            chart1.Legends.Add(legend);

            // Judul
            chart1.Titles.Add("Hasil Pemilihan Ketua OSIS");
            chart1.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);
            chart1.Titles[0].ForeColor = Color.DarkBlue;

            // Buat Series
            Series series = new Series("Suara");
            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "area1";
            series.Legend = "legend1";
            series.IsValueShownAsLabel = true;
            series.Label = "#VAL suara\n(#PERCENT{P1})";
            series.LegendText = "#VALX";

            Color[] warna = {
        Color.FromArgb(52, 152, 219),
        Color.FromArgb(46, 204, 113),
        Color.FromArgb(231, 76, 60),
        Color.FromArgb(241, 196, 15),
        Color.FromArgb(155, 89, 182)
    };

            int totalSuara = 0;
            int index = 0;

            foreach (DataRow row in dt.Rows)
            {
                string label = $"{row["nama_ketua"]}";
                int suara = Convert.ToInt32(row["Jumlah_Suara"]);
                totalSuara += suara;

                int i = series.Points.AddXY(label, suara);
                series.Points[i].Color = warna[index % warna.Length];
                if (index == 0) series.Points[i]["Exploded"] = "true";
                index++;
            }

            chart1.Series.Add(series);

        }
        public DashAdmin()
        {
            InitializeComponent();
            foreach (Guna2Button btn in pnlside.Controls.OfType<Guna2Button>())
            {
                btn.MouseEnter += Button_MouseEnter;
                btn.MouseLeave += Button_MouseLeave;
            }
            panel3.Visible = false;

            
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn)
            {
                panel3.Top = btn.Top;
                panel3.Height = btn.Height;
                panel3.Visible = true;
                panel3.BackColor = Color.Blue;
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private List<Control> elemenBawaan = new List<Control>();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Data_Paslon dp = new Data_Paslon()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(dp, pnlkonten);
            labelheader.Text = "KANDIDAT PASLON";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (pnlside.Visible == true)
            {
                pnlside.Visible = false;
            }
            else
            {
                pnlside.Visible = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult setuju = MessageBox.Show("Apakah mau keluar?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (setuju == DialogResult.Yes)
            {
                Login F1 = new Login();
                F1.Visible = true;
                this.Hide();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Data_Ketua dk = new Data_Ketua()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(dk, pnlkonten);
            labelheader.Text = "KANDIDAT KETUA";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            
            pnlkonten.Controls.Clear(); 

            
            foreach (Control c in elemenBawaan)
                pnlkonten.Controls.Add(c);

            labelheader.Text = "DASHBOARD";
            btnAktif = null;

            
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Data_Wakil dw = new Data_Wakil()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(dw, pnlkonten);
            labelheader.Text = "KANDIDAT WAKIL";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Hasil_Suara hs = new Hasil_Suara()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(hs, pnlkonten);
            labelheader.Text = "REKAPITULASI SUARA";
        }

        private void guna2Button3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DashAdmin_Load(object sender, EventArgs e)
        {
            TampilkanChart();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            foreach (Control c in pnlside.Controls)
            {
                if (c is Guna2Button btn)
                {
                    SetHoverEffect(btn, Color.FromArgb(0, 0, 255), Color.FromArgb(13, 34, 64));
                }
            }

            foreach (Control c in pnlkonten.Controls)
                elemenBawaan.Add(c);

            lokX1 = 0;
            lokX2 = label4.Width;

            label4.Location = new Point(lokX1, label4.Location.Y);
            label4.Location = new Point(lokX2, label4.Location.Y); 
            label4.Text = label4.Text;

            DB.crud("SELECT SUM(jumlah_suara) AS jumlah_suara FROM calon_pasangan");
            if (DB.ds.Tables.Count > 0 && DB.ds.Tables[0].Rows.Count > 0)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];

                object hasil = baris["jumlah_suara"];
                int total = hasil != DBNull.Value ? Convert.ToInt32(hasil) : 0;

                lbltotal.Text = total.ToString();
            }
            else
            {
                lbltotal.Text = "0";

            }

            DB.crud("SELECT (SELECT COUNT(*) FROM panitia) - (SELECT SUM(Jumlah_Suara) FROM calon_pasangan) AS sisa_pemilih;");
            if (DB.ds.Tables.Count > 0 && DB.ds.Tables[0].Rows.Count > 0)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];

                object hasil = baris["sisa_pemilih"];
                int total = hasil != DBNull.Value ? Convert.ToInt32(hasil) : 0;

                lblsisa.Text = total.ToString();
            }
            else
            {
                lblsisa.Text = "0";

            }

            DB.crud("SELECT ROUND((SELECT COALESCE(SUM(Jumlah_Suara),0) FROM calon_pasangan) / (SELECT COUNT(*) FROM panitia WHERE Hak = 'Pemilih') * 100, 2) AS persentase_suara");
            if (DB.ds.Tables.Count > 0 && DB.ds.Tables[0].Rows.Count > 0)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];

                object hasil = baris["persentase_suara"];
                double total = hasil != DBNull.Value ? Convert.ToDouble(hasil) : 1;

                persentotal.Text = total.ToString() + "%";
            }
            else
            {
                persentotal.Text = "0";

            }

            DB.crud("SELECT ROUND(( (SELECT COUNT(*) FROM panitia where hak = 'Pemilih') - (SELECT COALESCE(SUM(Jumlah_Suara),0) FROM calon_pasangan)) / (SELECT COUNT(*) FROM panitia where hak = 'Pemilih') * 100, 2) AS persentase_sisa");
            if (DB.ds.Tables.Count > 0 && DB.ds.Tables[0].Rows.Count > 0)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];

                object hasil = baris["persentase_sisa"];
                double total = hasil != DBNull.Value ? Convert.ToDouble(hasil) : 1;

                persensisa.Text = total.ToString() + "%";
            }
            else
            {
                persensisa.Text = "0";

            }

            dataGridView1.Rows.Clear();
            DB.crud("SELECT calon_pasangan.ID_Pasangan, calon_ketua.Nama_Ketua, calon_wakil.Nama_Wakil, calon_pasangan.Jumlah_Suara FROM `calon_pasangan` INNER JOIN calon_ketua ON calon_pasangan.ID_Pasangan = calon_ketua.ID_Pasangan INNER JOIN calon_wakil ON calon_pasangan.ID_Pasangan = calon_wakil.ID_Pasangan ORDER BY Jumlah_Suara DESC");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string no = "" + baris["ID_Pasangan"];
                string kt = "" + baris["nama_ketua"];
                string wk = "" + baris["nama_wakil"];
                string total = "" + baris["jumlah_suara"];
                dataGridView1.Rows.Add(no, kt, wk, total);
            }
        }
        private Guna2Button btnAktif = null;
        private void SetHoverEffect(Guna2Button btn, Color hover, Color normal)
        {
            btn.FillColor = normal;

            btn.MouseEnter += (s, e) => btn.FillColor = hover;

            btn.MouseLeave += (s, e) =>
            {
                if (btn != btnAktif)
                    btn.FillColor = normal;
            };

            btn.Click += (s, e) =>
            {
                if (btnAktif != null)
                    btnAktif.FillColor = normal;

                btnAktif = btn;
                btn.FillColor = hover;
            };
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Data_Ketua dk = new Data_Ketua()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(dk, pnlkonten);
            labelheader.Text = "KANDIDAT KETUA";
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Data_Wakil dw = new Data_Wakil()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(dw, pnlkonten);
            labelheader.Text = "KANDIDAT WAKIL";
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Hasil_Suara hs = new Hasil_Suara()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(hs, pnlkonten);
            labelheader.Text = "REKAPITULASI SUARA";
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private int lokX1, lokX2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lokX1 -= 2; // gerak ke kiri
            lokX2 -= 2;

            // Jika label sudah keluar layar kiri, pindah ke belakang label lainnya
            if (lokX1 < -label3.Width)
                lokX1 = lokX2 + label4.Width;

            if (lokX2 < -label4.Width)
                lokX2 = lokX1 + label4.Width;

            label3.Location = new Point(lokX1, label3.Location.Y);
            label4.Location = new Point(lokX2, label4.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
        
        private void lbltotal_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            DataUser du = new DataUser()
            {
                TopLevel = false,
                TopMost = true
            };
            KF.untukform(du, pnlkonten);
            labelheader.Text = "DATA USER";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlkonten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void persensisa_Click(object sender, EventArgs e)
        {

        }

        private void persentotal_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
