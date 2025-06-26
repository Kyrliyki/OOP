using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class Результаты : Form
    {
        public static int userId;
        public Результаты(int ID_user)
        {
            InitializeComponent();
            userId = ID_user;
        }
        private void Результаты_Load(object sender, EventArgs e)
        {
            LoadDataIntoListBox();
        }
        private void LoadDataIntoListBox()
        {
            Database database = new Database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT t.name_test, r.grade  FROM rez r INNER JOIN tests t ON r.id_test = t.id_test WHERE r.ID_user = @userId", database.GetConnection());
            command.Parameters.Add("@userId", MySqlDbType.VarChar).Value = userId;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            database.openConnection();
            dataGridView1.DataSource= dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Студент студент = new Студент(userId);
            студент.Show();
        }
    }
}
