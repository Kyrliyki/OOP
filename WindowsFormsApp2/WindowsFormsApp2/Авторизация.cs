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
    public partial class Авторизация : Form
    {
        protected int ID_user;
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = login.Text;
            String paswordUser = pasword.Text;
            
            Database database = new Database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login AND `pasword`= @pasword", database.GetConnection());
            command.Parameters.Add("@login",MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pasword", MySqlDbType.VarChar).Value = paswordUser;

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            database.openConnection();

            if (dt.Rows.Count > 0)
            {
                
                ID_user =int.Parse( dt.Rows[0][0].ToString());
                object value = dt.Rows[0][3];
               // MessageBox.Show(value.ToString());
                if (value.ToString() == "admin")
                {
                    this.Hide();
                    Администратор администратор = new Администратор();
                    администратор.Show();
                }
                if (value.ToString() == "student")
                {
                    this.Hide();
                    Студент студент = new Студент(ID_user);
                    студент.Show();
                }
                if (value.ToString() == "teacher")
                {
                    this.Hide();
                    Учитель учитель = new Учитель();
                    учитель.Show();
                }
            }
            else
                MessageBox.Show("Неправильный логин или пароль");

            database.closeConnection();
        }

        
    }
}
