using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Ogren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string db;
        
        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                db = textBox1.Text;
                SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-EKQK6BH\SQLEXPRESS;Initial Catalog=" + db + ";Integrated Security=True");
                richTextBox1.Enabled = true;
                dataGridView1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                MessageBox.Show(db + " veritabanına bağlanıldı!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı veri tabanı ismi ");
                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-EKQK6BH\SQLEXPRESS;Initial Catalog=" + db + ";Integrated Security=True");

            bgl.Open();
            string bglkomut;
            bglkomut = richTextBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(bglkomut, bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Close();



        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-EKQK6BH\SQLEXPRESS;Initial Catalog=" + db + ";Integrated Security=True");

                bgl.Open();
                string bglkomut1;
                bglkomut1 = richTextBox1.Text;
                SqlCommand komut = new SqlCommand(bglkomut1, bgl);

                komut.ExecuteNonQuery();
                bgl.Close();
                MessageBox.Show("İşlem başarılı");

            }
            catch (Exception)
            {

                MessageBox.Show("KOD HATASI!");
            }
            


        }
    }
}
