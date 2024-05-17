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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RinokContext db=new RinokContext())
            {
                foreach (Rinok rinok in db.Rinoks)
                {
                    if (textBox1.Text == rinok.Login && this.GetHashString(textBox2.Text) == rinok.Password)
                    {
                        MessageBox.Show("Вы успешно вошли!");
                        Form4 form4 = new Form4(textBox1.Text);
                        this.Hide();
                        MessageBox.Show(rinok.Login + ", добро пожаловать!");
                        form4.Show();
                        return;
                    }
                }
                MessageBox.Show("Не удалось войти. Логин или пароль указан неверно!");
            }
        }
    }
}
