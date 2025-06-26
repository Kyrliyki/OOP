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
    public partial class Администратор : Form, ITestAction
    {
        public Администратор()
        {
            InitializeComponent();
        }
        // Реализация метода CreateTest из интерфейса ITestAction
        public void CreateTest()
        {
            this.Hide();
            СозданиеТеста созданиеТеста = new СозданиеТеста();
            созданиеТеста.Show();
        }

        // Реализация метода DeleteTest из интерфейса ITestAction
        public void DeleteTest()
        {
            this.Hide();
            УдалениеТеста удалениеТеста = new УдалениеТеста();
            удалениеТеста.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Регистрация регистрация = new Регистрация();
            регистрация.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateTest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteTest();
        }
    }
}
