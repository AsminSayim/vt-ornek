using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace vt_ornek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;Database=film_arsiv;Uid=root;Pwd='';";

        void VeriGoster()
        {
            using (MySqlConnection baglanti = new MySqlConnection(connectionString))
            {
                string sorgu = "SELECT * FROM filmler";

                baglanti.Open();

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

                MySqlDataAdapter adapter = new MySqlDataAdapter(komut);

                DataTable tablo = new DataTable();

                adapter.Fill(tablo);

                dgvFilmler.DataSource = tablo;

                dgvFilmler.Invalidate();
                dgvFilmler.Refresh();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGoster();

        }

        private void dgvFilmler_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtFilmAd.Text = dgvFilmler.CurrentRow.Cells[1].Value.ToString();
            txtYonetmen.Text = dgvFilmler.CurrentRow.Cells[2].Value.ToString();
            txtYil.Text = dgvFilmler.CurrentRow.Cells[3].Value.ToString();
            txtTür.Text = dgvFilmler.CurrentRow.Cells[4].Value.ToString();
            txtSüre.Text = dgvFilmler.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
