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
    public partial class Учитель : Form, ITestAction
    {
        public Учитель()
        {
            InitializeComponent();
        }

        public void CreateTest()
        {
            this.Hide();
            СозданиеТеста созданиеТеста = new СозданиеТеста();
            созданиеТеста.Show();
        }

        // Реализация метода DeleteTest (учитель не может удалять тесты)
        public void DeleteTest()
        {
            this.Hide();
            УдалениеТеста удалениеТеста = new УдалениеТеста();
            удалениеТеста.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteTest();
        }
    }
}
