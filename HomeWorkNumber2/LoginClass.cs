using System;
using System.IO;

namespace HomeWorkNumber2
{
    public class LoginClass
    {
        private string[] loginAndPassword = File.ReadAllLines(@"C:\Users\zampir\source\repos\HomeWorkNumber2\HomeWorkNumber2\MailAndPassword\mandp.txt");
        private string Login { get; }
        private string Password { get; }
        public LoginClass(string typeOfUser)
        {
            if(typeOfUser == "user")
            {
                Login = loginAndPassword[0];
                Password = loginAndPassword[1];
            }
            if(typeOfUser == "admin")
            {
                Login = loginAndPassword[2];
                Password = loginAndPassword[3];
            }
        }
        public string GetLogin()
        {
            if (File.Exists(String.Join("", loginAndPassword)))
            {
                return Login;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public string GetPassword()
        {
            if (File.Exists(String.Join("", loginAndPassword)))
            {
                return Password;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
