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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class СозданиеТеста : Form
    {
        public СозданиеТеста()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String test_name = textBox1.Text;
            Database database = new Database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `tests` (`name_test`) VALUES (@test)", database.GetConnection());
            command.Parameters.Add("@test", MySqlDbType.VarChar).Value = test_name;

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Тест успешно добавлен");
            else
                MessageBox.Show("Ошибка добавления теста");
            database.closeConnection();

            MySqlCommand command2 = new MySqlCommand("SELECT `id_test` FROM `tests` WHERE `name_test` = @test", database.GetConnection());
            command2.Parameters.Add("@test", MySqlDbType.VarChar).Value = test_name;
            adapter.SelectCommand = command2;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                String Id = dr["id_test"].ToString();
               // MessageBox.Show(Id); Проверка id
                Int64 count = 0;
                Int64 count2 = 0;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string questionText = listBox1.Items[i].ToString();
                    string answerText = listBox2.Items[i].ToString();
                    MySqlCommand command3 = new MySqlCommand("INSERT INTO `question` (`id_tests`, `text_question`, `answer_question`, `question_number`) VALUES (@id, @questionText, @answerText, @number)", database.GetConnection());
                    command3.Parameters.Add("@id", MySqlDbType.VarChar).Value = Id;
                    command3.Parameters.Add("@questionText", MySqlDbType.VarChar).Value = questionText;
                    command3.Parameters.Add("@answerText", MySqlDbType.VarChar).Value = answerText;
                    command3.Parameters.Add("@number", MySqlDbType.VarChar).Value = i+1;
                    count++;
                    database.openConnection();
                    if (command3.ExecuteNonQuery() == 1)
                        count2++;
                    database.closeConnection();
                }
                if (count == count2)
                {
                    MessageBox.Show("Тест успешно записан");

                }
            }
            else
                MessageBox.Show("ошибка");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            listBox2.Items.Add(textBox3.Text);
        }
    }
}
