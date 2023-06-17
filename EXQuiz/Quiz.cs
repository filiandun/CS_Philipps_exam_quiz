using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class Quiz
    {
        DirectoryInfo directoryInfo; // для работы с папками (под сомнением её надобность)
        StreamReader streamReader;
        StreamWriter stremWriter;

        private string path;

        User user;

        public Quiz(string path)
        {
            this.path = path;
            if (!Directory.Exists(this.path)) // если пути не существует (т.е. программа в первый раз открывается)
            {
                Directory.CreateDirectory(this.path); // создание основной директории
                Directory.CreateDirectory(this.path + "Tests"); // создание директории с тестами
                Directory.CreateDirectory(this.path + "Users"); // создание директории с пользователями

                Console.WriteLine("ЗДРАВСТВУЙТЕ, ВЫ БЕРЁТЕ НА СЕБЯ РОЛЬ АДМИНИСТРАТОРА");
                Console.WriteLine("Ваш логин задан автоматически: admin");
                Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine();

                this.WriteToFile("admin", password);
            }
        }


        private void WriteToFile(string login, string password, string name = null, DateOnly birthDay = new DateOnly())
        {
            Directory.CreateDirectory(this.path + @"Users\" + login); // создание директории с пользователем

            this.stremWriter = new StreamWriter(this.path + @"Users\" + login + @"\" + login + ".txt"); // открытие потока для записи       

            this.stremWriter.WriteLine(login); // запись логина
            this.stremWriter.Write(password); // запись пароля

            if (name != null) // у админа нет имени и дня рождения, поэтому нужна проверка
            {
                this.stremWriter.WriteLine("\n" + name);
                this.stremWriter.Write(birthDay);
            }

            this.stremWriter.Close(); // закрытие потока // интересно, что пока этой строки не было, файл создавался, но в него ничего не записывалось
        }

        private void ReadFromFile(string login)
        {
            this.streamReader = new StreamReader(this.path + @"Users\" + login + @"\" + login + ".txt"); // открытие потока для чтения

            string buf = this.streamReader.ReadLine();
            string password = this.streamReader.ReadLine();

            if (login != "admin") // повторюсь, у админа нет имени и дня рождения, поэтому нужна проверка
            {
                string name = this.streamReader.ReadLine();
                DateOnly birthDay = new DateOnly(2004, 06, 24); //this.streamReader.ReadLine();

                this.user = new Testee(login, password, name, birthDay);
                return;
            }

            this.user = new Admin(login, password);
        }


        public void SignIn()
        {
            Console.WriteLine("ВХОД");

            //
            Console.Write("Введите ваш логин: "); string login = Console.ReadLine();
            while (true)
            {
                if (this.isLoginExist(login))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Введённый логин не существует, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            //
            Console.Write("Введите ваш пароль: "); string password = Console.ReadLine();

            ReadFromFile(login);
        }

        public void SignUp()
        {
            Console.WriteLine("РЕГИСТРАЦИЯ");
            Console.Write("Придумайте ваш логин: "); string login = Console.ReadLine();
            Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine();

            Console.Write("Введите своё имя: "); string name = Console.ReadLine();
            Console.Write("Введите свою дату рождения: ПОКА СТАТИЧЕСКИ"); DateOnly birthDay = new DateOnly(2004, 06, 24);

            this.WriteToFile(login, password, name, birthDay);
            this.user = new Testee(login, password, name, birthDay);
        }


        private bool isLoginExist(string login)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(this.path + "Users"); // октрытие директории Users
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories()) // получение каждой папки оттуда
            {
                if (directory.Name == login) // сравнение имени папки с логином
                {
                    return true;
                }
            }
            return false;
        }

        private bool isPasswordCorrect(string login)
        {
            this.streamReader = new StreamReader(this.path + @"Users\" + login + @"\" + login + ".txt");
            return false;
        }

        private  bool isPasswordSimple()
        {
            return false;
        }
    }
}
