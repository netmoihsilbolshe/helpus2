using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace rinok
{
    public partial class Form5 : Form
    {
        public Form5()
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
        private string GeneratePass()
        {
            string iPass = "";
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z', 'A', 'E', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y' };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {

                iPass = iPass + arr[rnd.Next(0, 57)].ToString();
            }
            return iPass;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress("aaaaa-jenshina@mail.ru", "Arina");
                MailAddress to = new MailAddress(textBox1.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                using (RinokContext db = new RinokContext())
                {
                    foreach (Rinok designer in db.Rinoks)
                    {
                        if (textBox1.Text == designer.Email)
                        {
                            string newPassword = GeneratePass();

                            m.Body = "<h1>Пароль: " + newPassword + "</h1>";
                            designer.Password = GetHashString(newPassword);
                            MessageBox.Show("Пароль отправлен на почту");
                        }
                    }
                    db.SaveChanges();
                }
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                m.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential("aaaaa-jenshina@mail.ru", "FknteJiX52citA1ptmz8");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("ПОШЛИ НАХУЙ!!!!!!!!!!!!!!");
            }
        }
    }
}
