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
    public partial class Info_Pemilihan : Form
    {
        public Info_Pemilihan()
        {
            InitializeComponent();
        }
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
            series.ChartType = SeriesChartType.Column;
            series.ChartArea = "area1";
            series.Legend = "legend1";
            series.IsValueShownAsLabel = true;
            series.Label = "#VAL suara\n(#PERCENT{P1})";
            series.LegendText = " ";

            Color[] warna = {
        Color.FromArgb(52, 152, 219),
        Color.FromArgb(46, 204, 113),
        Color.FromArgb(231, 76, 60),
        Color.FromArgb(241, 196, 15),
        Color.FromArgb(155, 89, 182)
    };

            int totalPemilih = 0;
            DataTable dtPanitia = DB.chart("SELECT COUNT(*) FROM panitia");
            if (dtPanitia.Rows.Count > 0 && dtPanitia.Rows[0][0] != DBNull.Value)
            {
                totalPemilih = Convert.ToInt32(dtPanitia.Rows[0][0]);
            }

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

        public void info()
        {
            DB.crud("select * from calon_ketua inner join calon_pasangan on calon_ketua.id_pasangan = calon_pasangan.id_pasangan");
            DataTable dt = DB.ds.Tables[0];

            // Hitung total suara semua paslon
            int totalSuara = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalSuara += Convert.ToInt32(row["Jumlah_Suara"]);
            }

            if (dt.Rows.Count > 0)
            {
                int suara1 = Convert.ToInt32(dt.Rows[0]["Jumlah_Suara"]);
                double prs1 = totalSuara > 0 ? (double)suara1 / totalSuara * 100 : 0;
                paslon1.Text = dt.Rows[0]["Nama_Ketua"].ToString();
                totalsuara1.Text = suara1.ToString();
                persen1.Text = prs1.ToString("F1") + "%";
            }

            if (dt.Rows.Count > 1)
            {
                int suara2 = Convert.ToInt32(dt.Rows[1]["Jumlah_Suara"]);
                double prs2 = totalSuara > 0 ? (double)suara2 / totalSuara * 100 : 0;
                paslon2.Text = dt.Rows[1]["Nama_Ketua"].ToString();
                totalsuara2.Text = suara2.ToString();
                persen2.Text = prs2.ToString("F1") + "%";
            }

            if (dt.Rows.Count > 2)
            {
                int suara3 = Convert.ToInt32(dt.Rows[2]["Jumlah_Suara"]);
                double prs3 = totalSuara > 0 ? (double)suara3 / totalSuara * 100 : 0;
                paslon3.Text = dt.Rows[2]["Nama_Ketua"].ToString();
                totalsuara3.Text = suara3.ToString();
                persen3.Text = prs3.ToString("F1") + "%";
            }

            if (dt.Rows.Count > 3)
            {
                int suara4 = Convert.ToInt32(dt.Rows[3]["Jumlah_Suara"]);
                double prs4 = totalSuara > 0 ? (double)suara4 / totalSuara * 100 : 0;
                paslon4.Text = dt.Rows[3]["Nama_Ketua"].ToString();
                totalsuara4.Text = suara4.ToString();
                persen4.Text = prs4.ToString("F1") + "%";
            }
        }

        private void Info_Pemilihan_Load(object sender, EventArgs e)
        {
            TampilkanChart();
            info();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Visible = true;
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
