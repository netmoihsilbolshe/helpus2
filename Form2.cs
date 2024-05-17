using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rinok
{
    public partial class Form2 : Form
    {
        public static Form1 form1 {  get; set; }
        public Form2()
        {
            InitializeComponent();
            textBox7.KeyPress += textBox7_KeyPress;
        }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar != (char)Keys.Back)
            {
                e.Handled= true;
                MessageBox.Show("Пожалуйста, вводите только цифры!");
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&& e.KeyChar !=(char) Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
                MessageBox.Show("Пожалуйста введите дату рождения в формате гг-мм-дд");
            }
        }
      
        private void linkLabel_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (RinokContext db = new RinokContext())
            {
                Rinok rinok = new Rinok(textBox1.Text, this.GetHashString(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
                if (string.IsNullOrEmpty(textBox1.Text) ||
                   string.IsNullOrEmpty(textBox2.Text) ||
                   string.IsNullOrEmpty(textBox3.Text) ||
                   string.IsNullOrEmpty(textBox4.Text) ||
                   string.IsNullOrEmpty(textBox5.Text) ||
                   string.IsNullOrEmpty(textBox6.Text) ||
                   string.IsNullOrEmpty(textBox7.Text) ||
                   string.IsNullOrEmpty(textBox8.Text) ||
                   string.IsNullOrEmpty(textBox9.Text))
                {
                    MessageBox.Show("Вы заполнили не все поля!");
                }
                MessageBox.Show("Пользователь" + " " + textBox1.Text + " " + "успешно зарегистрирован!");
                db.Rinoks.Add(rinok);
                db.SaveChanges();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
        }
    }
}
