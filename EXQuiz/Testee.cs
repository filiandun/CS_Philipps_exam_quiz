using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class Testee : User
    {
        public string name;
        public DateOnly birthDay;

        public string pathToResultFile;

        public Testee(string login, string password, string name, DateOnly birthDay) : base(login, password)
        {
            this.name = name;
            this.birthDay = birthDay;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
