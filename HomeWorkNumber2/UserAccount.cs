using System.IO;

namespace HomeWorkNumber2
{
    public class UserAccount
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public UserAccount(string filePath)
        {
            if (File.Exists(filePath))
            {
                var loginAndPassword = File.ReadAllLines(filePath);
                Login = loginAndPassword[0];
                Password = loginAndPassword[1];
            }
            else
            {
                throw new FileNotFoundException($"file {filePath} doesn't exist");
            }
        }
    }
}
