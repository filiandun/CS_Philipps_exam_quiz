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

            DirectoryInfo directoryInfo = new DirectoryInfo(Paths.pathToUsers); // открытие директории Users

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories()) // получение каждой папки оттуда
            {
                if (directory.Name == login) // сравнение имени папки с логином
                {
                    return true;
                }
            }

            return false;
        }

        public static bool PasswordCorrect(string login, string password)
        {
            if (password == null)
            {
                return false;
            }

            using (StreamReader streamReader = new StreamReader(Paths.pathToUsers + login + @"\" + login + ".txt"))
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

        public static bool QuizExist(string quizName)
        {
            return File.Exists(Paths.pathToQuizzes + quizName + ".txt");
        }
    }
}
