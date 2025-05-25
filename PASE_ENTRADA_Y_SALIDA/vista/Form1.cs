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

namespace PASE_ENTRADA_Y_SALIDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Conexion.Conectar();
            MessageBox.Show("conexion exitosa");

            MostrarDatosArticulos.DataSource=llenar_grid();
            */
        }
        /*
        public DataTable llenar_grid()
        {
            
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM articulos";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
            
        }

        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void folio_TextChanged(object sender, EventArgs e)
        {
             for (int i = 0; i <= 10; i++)
            {
                var guid = Guid.NewGuid();
                var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
                var seed = int.Parse(justNumbers.Substring(0, 4));

                var random = new Random(seed);
                var value = random.Next(0, 5);

                Console.WriteLine(value);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TIPODEVISITNTE_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonHeader1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
