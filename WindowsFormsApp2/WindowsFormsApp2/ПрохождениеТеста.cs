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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class ПрохождениеТеста : Form
    {
        public static String ID_Test;
        public static String Name_Test;
        public static DataTable dt = new DataTable();
        public static DataRow dr;
        public static String question;
        public static int trunumber=1;
        public static int truquest=0;
        public static int cauntquest=0;
        public static int ID_user;

        public ПрохождениеТеста(int Id_user)
        {
            InitializeComponent();
            ID_user = Id_user;
        }
        private void UpdateUI()
        {
            
            textBox1.Text = dr["text_question"].ToString();
            question = dr["answer_question"].ToString();
            String[]quests= question.Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string quest in quests)
            {
                char h = quest[0];
                if (h == '+')
                {
                    break;
                }
                else
                {
                    trunumber++;
                }
            }
            foreach (string quest in quests)
            { 
                checkedListBox1.Items.Add(quest.Replace("+","").Replace("-",""));
            }


        }
        private void Прохождение_Load(object sender, EventArgs e)
        {
            LoadDataIntoListBox();
        }
        private void LoadDataIntoListBox()
        {
            Database database = new Database();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT `name_test` FROM `tests`", database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            database.openConnection();
            listBox1.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {

                listBox1.Items.Add(dr["name_test"].ToString());

            }
            dt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Visible = false;
                button1.Visible = false;
                textBox1.Visible = true;
                label1.Visible = true;
                button2.Visible = true;
                checkedListBox1.Visible = true;
                button3.Visible = false;
                label2.Visible = false;
                Name_Test = listBox1.SelectedItem.ToString();
                Database database = new Database();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `id_test` FROM `tests` WHERE `name_test` = @test", database.GetConnection());
                command.Parameters.Add("@test", MySqlDbType.VarChar).Value = Name_Test;
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    dr = dt.Rows[0];
                    ID_Test = dr["id_test"].ToString();
                    dt.Clear();
                    MySqlCommand command2 = new MySqlCommand("SELECT * FROM question WHERE `id_tests` = @id", database.GetConnection());
                    command2.Parameters.Add("@id", MySqlDbType.Int64).Value = ID_Test;
                    adapter.SelectCommand = command2;
                    adapter.Fill(dt);
                    cauntquest = dt.Rows.Count;
                    dr = dt.Rows[0];
                    UpdateUI();
                    
                }
                
            }
            else
            {
                MessageBox.Show("Выберете тест");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dt.Rows.Count > 0)
            {
                if (checkedListBox1.GetItemChecked(trunumber-1))
                {
                    truquest++;
                }
                checkedListBox1.Items.Clear();
                trunumber = 1;
                dt.Rows.Remove(dr);
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    UpdateUI();
                }
                else 
                { 
                    MessageBox.Show($"Тест пройден.Правильных ответов: {truquest} из {cauntquest}");
                    string rez = $"{truquest} из {cauntquest}";
                    Database database = new Database();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `rez` (`id_user`, `id_test`, `grade`) VALUES (@id_user, @id_test, @grade)", database.GetConnection());
                    command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = ID_user;
                    command.Parameters.Add("@id_test", MySqlDbType.VarChar).Value = ID_Test;
                    command.Parameters.Add("@grade", MySqlDbType.VarChar).Value = rez;
                    database.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Результат успешно добавлен");
                    database.closeConnection();
                    truquest = 0;
                    
                    this.Hide();
                    Студент студент = new Студент(ID_user);
                    студент.Show();
                }
            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Студент студент = new Студент(ID_user);
            студент.Show();
        }
    }
}
