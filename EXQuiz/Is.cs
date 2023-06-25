using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal static class Is
    {
        public static bool LoginExist(string login)
        {
            if (login == null)
            {
                return false;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(PATHTO.USERS); // открытие директории Users

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories()) // получение каждой папки оттуда
            {
                if (directory.Name == login) // сравнение имени папки с логином
                {
                    return true;
                }
            }

            return false;
        }


        public static bool LoginCorrect(string login)
        {
            if (LoginExist(login))
            {
                return false;
            }

            if (login == null)
            {
                return false;
            }

            if (login == "admin")
            {
                return false;
            }

            return Regex.IsMatch(login, @"^[a-zA-Z0-9]{4,16}$");
        }


        public static bool PasswordCorrect(string login, string password)
        {
            if (password == null)
            {
                return false;
            }

            using (StreamReader streamReader = new StreamReader(PATHTO.USERS + login + @"\" + login + ".txt"))
            {
                streamReader.ReadLine(); // считывание в пустоту
                if (password == streamReader.ReadLine())
                {
                    return true;
                }
                return false;
            }
        }

        public static bool PasswordSimple(string password)
        {
            if (password == null)
            {
                return false;
            }

            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
            {
                return false;
            }
            return true;
        }

        public static bool PasswordSimple(string newPassword, string oldPassword)
        {
            if (newPassword == oldPassword)
            {
                return true;
            }

            if (newPassword == null)
            {
                return true;
            }

            return !Regex.IsMatch(newPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$");
        }

        public static bool QuizExist(string quizName)
        {
            return File.Exists(PATHTO.QUIZZES + quizName + ".txt");
        }
    }
}
