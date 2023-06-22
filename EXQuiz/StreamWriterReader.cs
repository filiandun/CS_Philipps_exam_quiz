using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal static class StreamWriterReader
    {
        public static void WriteToFile(User user)
        {
            Directory.CreateDirectory(Paths.pathToUsers + user.login); // создание директории с пользователем
            Directory.CreateDirectory(Paths.pathToUsers + user.login + @"\QuizzesResults"); // создание директории с результатами тестов

            using (StreamWriter streamWriter = new StreamWriter(Paths.pathToUsers + user.login + @"\" + user.login + ".txt")) // открытие потока для записи
            {
                streamWriter.WriteLine(user.login); // запись логина
                streamWriter.Write(user.password); // запись пароля

                if (user is Testee testee) // у админа нет имени и дня рождения, поэтому нужна проверка
                {
                    streamWriter.WriteLine("\n" + testee.name); // запись имени
                    streamWriter.Write(testee.birthDay); // запись дня рождения
                }
            }
        }


        public static User ReadFromFile(string login)
        {
            string pathToUser = Paths.pathToUsers + login + @"\" + login + ".txt";
            using (StreamReader streamReader = new StreamReader(pathToUser)) // открытие потока для чтения
            {
                streamReader.ReadLine(); // считывание в пустоту
                string password = streamReader.ReadLine();

                if (login != "admin") // у админа нет имени и дня рождения, поэтому нужна проверка
                {
                    string name = streamReader.ReadLine(); // чтение имени
                    DateOnly birthDay = DateOnly.Parse(streamReader.ReadLine()); // чтение дня рождения

                    return new Testee(login, password, name, birthDay);
                }
                else
                {

                    return new Admin(login, password);
                }
            }
        }
    }
}
