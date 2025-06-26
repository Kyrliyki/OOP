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
    public partial class Студент : Form
    {
        public int Id_user;
        public Студент(int ID_user)
        {
            InitializeComponent();
            Id_user = ID_user;


        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ПрохождениеТеста abab = new ПрохождениеТеста(Id_user);
            abab.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Результаты результаты = new Результаты(Id_user);
            результаты.Show();
        }
    }
}
