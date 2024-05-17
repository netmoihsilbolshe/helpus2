using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rinok
{
    public class Rinok
    {
        public int Id {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym {get; set; }
        public string DataOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pavilion {  get; set; }

        public Rinok() { }  
        public Rinok(string Login, string Password, string Name, string Surname, string Patronym, string DataOfBirth, string Email, string Phone, string Pavilion)
        {
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Surname = Surname;
            this.Patronym = Patronym;
            this.DataOfBirth = DataOfBirth;
            this.Email = Email;
            this.Phone = Phone;
            this.Pavilion= Pavilion;
        }

    }
}
