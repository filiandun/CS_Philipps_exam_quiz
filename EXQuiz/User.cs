using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal abstract class User
    {
        public string login;
        public string password;

        public string pathToMainFile;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
