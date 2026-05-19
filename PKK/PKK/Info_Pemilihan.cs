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
        private void TampilkanPieChart()
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
            chart1.Titles.Add("Hasil Sementara Pemilihan Ketua OSIS");
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
        public void tampildata()
        {
            DB.crud("SELECT calon_pasangan.id_pasangan,calon_ketua.Nama_Ketua AS nama_ketua,calon_wakil.Nama_Wakil AS nama_wakil,calon_pasangan.Jumlah_Suara FROM calon_pasangan INNER JOIN calon_ketua ON calon_pasangan.ID_Ketua = calon_ketua.ID_Ketua INNER JOIN calon_wakil ON calon_pasangan.ID_Wakil = calon_wakil.ID_Wakil ORDER BY calon_pasangan.Jumlah_Suara DESC");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idp = "" + baris["ID_Pasangan"];
                string kt = "" + baris["Nama_Ketua"];
                string wk = "" + baris["Nama_Wakil"];
                string js = "" + baris["Jumlah_suara"];
                dataGridView1.Rows.Add(idp, kt, wk, js);
            }
        }
        private void Info_Pemilihan_Load(object sender, EventArgs e)
        {
            TampilkanPieChart();
            tampildata();
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
