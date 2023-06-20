using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class MainMenu
    {
        private byte currentPosition;
        private byte minPosition;
        private byte maxPosition;

        public MainMenu(byte minPosition, byte maxPosition)
        {
            this.currentPosition = 0;
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }

        private void Menu()
        {
            this.minPosition = 0;
            this.maxPosition = 2;

            switch (this.currentPosition)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]\n"); Console.ResetColor();
                    Console.WriteLine("> вход");
                    Console.WriteLine("  регистрация\n");

                    Console.WriteLine("  выход");
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]\n"); Console.ResetColor();
                    Console.WriteLine("  вход");
                    Console.WriteLine("> регистрация\n");

                    Console.WriteLine("  выход");
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]\n"); Console.ResetColor();
                    Console.WriteLine("  вход");
                    Console.WriteLine("  регистрация\n");

                    Console.WriteLine("> выход");
                    break;
            }
        }

        public byte Choice()
        {
            ConsoleKeyInfo key;

            this.Menu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.Menu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.Menu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return this.currentPosition;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }
    }

    public class TesteeMenu
    {
        private byte currentPosition;
        private byte minPosition;
        private byte maxPosition;

        public TesteeMenu(byte minPosition, byte maxPosition)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }

        public void Menu()
        {
            switch (this.currentPosition)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК,  , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("> начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК,  , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("> посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("> посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("> изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("> изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]\n"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("> выйти");

                    break;

            }
        }

        public byte Choice()
        {
            ConsoleKeyInfo key;

            this.Menu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.Menu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.Menu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return this.currentPosition;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }
    }

    public class AdminMenu
    {
        private byte currentPosition;
        private byte minPosition;
        private byte maxPosition;

        public AdminMenu(byte minPosition, byte maxPosition)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }

        public void Menu()
        {
            switch (this.currentPosition)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("> зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("> изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("> удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("> создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("> изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("> удалить викторину\n");

                    Console.WriteLine("  выйти");

                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]"); Console.ResetColor();
                    Console.WriteLine("  зарегистрировать пользователя");
                    Console.WriteLine("  изменить пользователя");
                    Console.WriteLine("  удалить пользователя\n");

                    Console.WriteLine("  создать викторину");
                    Console.WriteLine("  изменить викторину");
                    Console.WriteLine("  удалить викторину\n");

                    Console.WriteLine("> выйти");

                    break;
            }
        }

        public byte Choice()
        {
            ConsoleKeyInfo key;

            this.Menu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.Menu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.Menu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return this.currentPosition;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }
    }





    public class QuizMenu
    {
        private byte minPosition;
        private byte maxPosition;
        private byte currentPosition;

        Dictionary<string, string> quizzesDictionary;

        public string selectedQuiz;

        public QuizMenu(string path)
        {
            string quizName;
            string quizDescription;
            StreamReader streamReader; // ВОПРОС: как лучше, перезаписывать переменную в цикле (как сейчас) или создавать её заново?

            this.quizzesDictionary = new Dictionary<string, string>(); // инициализация словаря, где будет хранится имя и описание каждой викторины

            DirectoryInfo directoryInfo = new DirectoryInfo(path); // открытие директории с викторинами
            foreach (FileInfo file in directoryInfo.GetFiles()) // получение каждого файла оттуда
            {
                streamReader = new StreamReader(file.FullName);

                quizName = streamReader.ReadLine();
                quizDescription = streamReader.ReadLine();

                if (quizName != null && quizDescription != null) // ТУТ ПУНКТ 4 ПОФИКШЕН
                {
                    this.quizzesDictionary.Add(quizName, quizDescription);
                }

                streamReader.Close();
            }

            this.minPosition = 1;
            this.maxPosition = (byte)(this.quizzesDictionary.Count);
            this.currentPosition = minPosition;

            this.Choice(); // вызов меню
        }

        private void Menu()
        {
            byte i = 1;

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[СТАРТ НОВОЙ ВИКТОРИНЫ]"); Console.ResetColor();
            Console.WriteLine("\nСписок викторин и их небольшое описание:\n");
            foreach (var obj in this.quizzesDictionary)
            {
                if (i == this.currentPosition)
                {
                    Console.WriteLine($"> {i}. {obj.Key} - \"{obj.Value}\"");
                    this.selectedQuiz = obj.Key;
                }
                else
                {
                    Console.WriteLine($"  {i}. {obj.Key} - \"{obj.Value}\"");
                }
                ++i;
            }
            Console.Write("\nESC - назад");
        }

        private void Choice()
        {
            ConsoleKeyInfo key;

            this.Menu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.Menu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.Menu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return;
                    case ConsoleKey.Escape: this.selectedQuiz = null; return;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }

        public string GetSelectedQuiz
        {
            get
            {
                return this.selectedQuiz;
            }
        }
    }





    public class ResultMenu
    {
        private byte minPosition;
        private byte maxPosition;
        private byte currentPosition;

        List<string> resultsList;

        public string selectedResult;

        public ResultMenu(string path)
        {
            this.resultsList = new List<string>(); // инициализация списка, где будет хранится имя каждого файла-результата викторины

            DirectoryInfo directoryInfo = new DirectoryInfo(path); // открытие директории с файлами-результатами викторины
            foreach (FileInfo file in directoryInfo.GetFiles()) // получение каждого файла оттуда
            {
                this.resultsList.Add(file.Name.Remove(file.Name.LastIndexOf('.'))); // этот весь огород нужен для того, чтобы отсечь ".txt" (возвращается последний индекс вхождения точки (.) c помощью LastIndexOf, а Remove отсекает часть строки после этого индекса)
            }

            this.minPosition = 0;
            this.maxPosition = (byte) (this.resultsList.Count - 1);
            this.currentPosition = minPosition;

            this.Choice();
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[СТАРТ НОВОЙ ВИКТОРИНЫ]"); Console.ResetColor();
            Console.WriteLine("\nСписок результатов викторин:\n");
            for (int i = 0; i < this.resultsList.Count; ++i)
            {
                if (i == this.currentPosition)
                {
                    Console.WriteLine($"> {i + 1}. {this.resultsList[i]}");
                    this.selectedResult = this.resultsList[i];
                }
                else
                {
                    Console.WriteLine($"  {i + 1}. {this.resultsList[i]}");
                }
            }
            Console.Write("\nESC - назад");
        }

        public void Choice()
        {
            ConsoleKeyInfo key;

            this.Menu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.Menu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.Menu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return;
                    case ConsoleKey.Escape: this.selectedResult = null; return;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }

        public string GetSelectedResult
        {
            get
            {
                return this.selectedResult;
            }
        }
    }
}
