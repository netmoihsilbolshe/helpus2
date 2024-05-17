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
using System.ComponentModel.Design;

namespace rinok
{
    public partial class Form4 : Form
    {
        public static Form3 Form3 { get; set; }
        private string login;
        public Form4(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            using (RinokContext  db= new RinokContext())
            {
                foreach (Rinok rinok in db.Rinoks)
                {
                    if(login == rinok.Login)
                    {
                        textBox1.Text=rinok.Login;
                        textBox2.Text = rinok.Surname;
                        textBox3.Text = rinok.Name;
                        textBox4.Text = rinok.Patronym;
                        textBox5.Text = rinok.Phone;
                        textBox6.Text = rinok.DataOfBirth;
                        textBox7.Text = rinok.Pavilion;
                        textBox8.Text = rinok.Email;

                    }
                }
                db.SaveChanges();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
