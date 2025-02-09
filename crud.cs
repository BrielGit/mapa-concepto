using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CRUDExample
{
    public partial class MainForm : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataTable dt;

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase()
        {
            conn = new SQLiteConnection("Data Source=users.db;Version=3;");
            conn.Open();

            string tableCmd = "CREATE TABLE IF NOT EXISTS Users (ID INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT, Correo TEXT, Edad INTEGER)";
            cmd = new SQLiteCommand(tableCmd, conn);
            cmd.ExecuteNonQuery();
        }

        private void LoadData()
        {
            adapter = new SQLiteDataAdapter("SELECT * FROM Users", conn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            int edad = int.Parse(txtEdad.Text);

            string insertCmd = "INSERT INTO Users (Nombre, Correo, Edad) VALUES (@Nombre, @Correo, @Edad)";
            cmd = new SQLiteCommand(insertCmd, conn);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Correo", correo);
            cmd.Parameters.AddWithValue("@Edad", edad);
            cmd.ExecuteNonQuery();

            ClearFields();
            LoadData();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                int edad = int.Parse(txtEdad.Text);

                string updateCmd = "UPDATE Users SET Nombre = @Nombre, Correo = @Correo, Edad = @Edad WHERE ID = @ID";
                cmd = new SQLiteCommand(updateCmd, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Edad", edad);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                string deleteCmd = "DELETE FROM Users WHERE ID = @ID";
                cmd = new SQLiteCommand(deleteCmd, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para eliminar.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                txtEdad.Text = row.Cells["Edad"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtEdad.Clear();
        }
    }
}