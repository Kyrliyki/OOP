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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = Login.Text;
            String status = Status.Text;
            String paswordUser = Pasword.Text;
            if (status == "")
            {
                MessageBox.Show("Выберите статус учётной записи");
            }
            else
            {
                Database database = new Database();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pasword`, `statys`) VALUES (@login, @pasword, @status)",database.GetConnection());
                command.Parameters.Add("@login",MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@pasword", MySqlDbType.VarChar).Value = paswordUser;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

                database.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Регистрация успешна");
                else
                    MessageBox.Show("Ошибка регистрации");
                database.closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Администратор администратор = new Администратор();
            администратор.Show();
        }
    }
}
