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

namespace WindowsFormsApp2
{
    public partial class УдалениеТеста : Form
    {
        public УдалениеТеста()
        {
            InitializeComponent();
        }
        private void УдалениеТеста_Load(object sender, EventArgs e)
        {
            LoadDataIntoListBox();
        }
        private void LoadDataIntoListBox()
        {
            Database database = new Database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT `name_test` FROM `tests`", database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            database.openConnection();
            listBox1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                listBox1.Items.Add(dr["name_test"].ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Database database = new Database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT `name_test` FROM `tests`", database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            database.openConnection();
            foreach (DataRow dr in dt.Rows)
            {

                listBox1.Items.Add(dr["name_test"].ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Администратор администратор = new Администратор();
            администратор.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedItem != null)
            {
                String name = listBox1.SelectedItem.ToString();
                Database database = new Database();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `id_test` FROM `tests` WHERE `name_test` = @test", database.GetConnection());
                command.Parameters.Add("@test", MySqlDbType.VarChar).Value = name;
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    String Id = dr["id_test"].ToString();
                    MessageBox.Show(Id);
                    MySqlCommand command2 = new MySqlCommand("DELETE FROM tests WHERE `tests`.`name_test` = @name", database.GetConnection());
                    command2.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    database.openConnection();
                    if (command2.ExecuteNonQuery() == 1)
                        MessageBox.Show("Тест удалён");
                    else
                        MessageBox.Show("Ошибка");

                    database.closeConnection();

                    MySqlCommand command3 = new MySqlCommand("DELETE FROM question WHERE `question`.`id_tests` = @id", database.GetConnection());
                    command3.Parameters.Add("@id", MySqlDbType.Int64).Value = Id;
                    database.openConnection();
                    if (command3.ExecuteNonQuery() == 1)
                        MessageBox.Show("Вопросы удалены");
                    else
                        MessageBox.Show("Ошибка");
                    database.closeConnection();
                }
            }
            LoadDataIntoListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
