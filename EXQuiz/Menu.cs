using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace EXQuiz
{
    internal static class MainMenu
    {
        private static byte currentPosition;

        private const byte minPosition = 0;
        private const byte maxPosition = 2;


        public static void DisplayMenu()
        {
            currentPosition = 0;
            do
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]\n"); Console.ResetColor();

                Console.WriteLine(currentPosition == 0 ? "> вход" : "  вход");
                Console.WriteLine(currentPosition == 1 ? "> регистрация\n" : "  регистрация\n");

                Console.WriteLine(currentPosition == 2 ? "> выход" : "  выход");

            }
            while (HandleInput());
        }


        private static bool HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(); // считывание значения нажатой клавиши

            switch (key.Key)
            {
                case ConsoleKey.UpArrow: if (currentPosition > minPosition) { --currentPosition; } break; // нажата клавиша вверх
                case ConsoleKey.DownArrow: if (currentPosition < maxPosition) { ++currentPosition; } break; // нажата клавиша вниз

                case ConsoleKey.Enter: return false;

                default: break;
            }
            return true;
        }


        public static byte GetCurrentPosition
        {
            get { return currentPosition; }
        }
    }



    public static class TesteeMenu
    {
        private static byte currentPosition = 0;

        private const byte minPosition = 0;
        private const byte maxPosition = 6;

        public static void DisplayMenu(string testeeName)
        {
            currentPosition = 0;
            testeeName = testeeName.ToUpper();
            do
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, {testeeName}, ВЫ В SDMQ]\n"); Console.ResetColor();

                Console.WriteLine(currentPosition == 0 ? "> начать новую викторину\n" : "  начать новую викторину\n");

                Console.WriteLine(currentPosition == 1 ? "> посмотреть свои результаты прошлых викторин" : "  посмотреть свои результаты прошлых викторин");
                Console.WriteLine(currentPosition == 2 ? "> посмотреть ТОП-5 по конкретной викторине\n" : "  посмотреть ТОП-5 по конкретной викторине\n");

                Console.WriteLine(currentPosition == 3 ? "> изменить пароль" : "  изменить пароль");
                Console.WriteLine(currentPosition == 4 ? "> изменить имя" : "  изменить имя");
                Console.WriteLine(currentPosition == 5 ? "> изменить дату рождения\n" : "  изменить дату рождения\n");

                Console.WriteLine(currentPosition == 6 ? "> выйти" : "  выйти");
            }
            while (HandleInput());
        }


        private static bool HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(); // считывание значения нажатой клавиши

            switch (key.Key)
            {
                case ConsoleKey.UpArrow: if (currentPosition > minPosition) { --currentPosition; } break; // нажата клавиша вверх
                case ConsoleKey.DownArrow: if (currentPosition < maxPosition) { ++currentPosition; } break; // нажата клавиша вниз

                case ConsoleKey.Enter: return false;

                default: break;
            }
            return true;
        }


        public static byte GetCurrentPosition
        {
            get { return currentPosition; }
        }
    }




    public static class AdminMenu
    {
        private static byte currentPosition;

        private const byte minPosition = 0;
        private const byte maxPosition = 6;


        public static void DisplayMenu()
        {
            currentPosition = 0;
            do
            {
                Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, АДМИНИСТРАТОР]\n"); Console.ResetColor();

                Console.WriteLine(currentPosition == 0 ? "> зарегистрировать пользователя" : "  зарегистрировать пользователя");
                Console.WriteLine(currentPosition == 1 ? "> изменить пользователя" : "  изменить пользователя");
                Console.WriteLine(currentPosition == 2 ? "> удалить пользователя\n" : "  удалить пользователя\n");

                Console.WriteLine(currentPosition == 3 ? "> создать викторину" : "  создать викторину");
                Console.WriteLine(currentPosition == 4 ? "> изменить викторину" : "  изменить викторину");
                Console.WriteLine(currentPosition == 5 ? "> удалить викторину\n" : "  удалить викторину\n");

                Console.WriteLine(currentPosition == 6 ? "> выйти" : "  выйти");
            } 
            while (HandleInput());
        }


        private static bool HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(); // считывание значения нажатой клавиши

            switch (key.Key)
            {
                case ConsoleKey.UpArrow: Console.Clear(); if (currentPosition > minPosition) { --currentPosition; } break; // нажата клавиша вверх
                case ConsoleKey.DownArrow: Console.Clear(); if (currentPosition < maxPosition) { ++currentPosition; } break; // нажата клавиша вниз

                case ConsoleKey.Enter: return false;

                default: Console.Clear(); break;
            }
            return true;
        }

        public static byte GetCurrentPosition
        {
            get { return currentPosition; }
        }
    }





    public class QuizMenu
    {
        private byte currentPosition;

        private byte minPosition;
        private byte maxPosition;

        Dictionary<string, string> quizzesDictionary;

        public string selectedQuiz;

        public QuizMenu()
        {
            string quizName;
            string quizDescription;
            StreamReader streamReader; 

            this.quizzesDictionary = new Dictionary<string, string>(); // инициализация словаря, где будет хранится имя и описание каждой викторины

            DirectoryInfo directoryInfo = new DirectoryInfo(Paths.pathToQuizzes); // открытие директории с викторинами
            foreach (FileInfo file in directoryInfo.GetFiles()) // получение каждого файла оттуда
            {
                streamReader = new StreamReader(file.FullName);
                streamReader.ReadLine(); // считывание в пустоту

                quizName = file.Name.Remove(file.Name.LastIndexOf('.')); // этот весь огород нужен для того, чтобы отсечь ".txt"(возвращается последний индекс вхождения точки(.) c помощью LastIndexOf, а Remove отсекает часть строки после этого индекса)
                quizDescription = streamReader.ReadLine();

                if (quizName != null && quizDescription != null && !this.quizzesDictionary.ContainsKey(quizName)) // ТУТ ПУНКТ 4 ПОФИКШЕН
                {
                    this.quizzesDictionary.Add(quizName, quizDescription);
                }

                streamReader.Close();
            }

            this.minPosition = 1;
            this.maxPosition = (byte)(this.quizzesDictionary.Count);
            this.currentPosition = minPosition;
        }

        public void DisplayMenu(ConsoleColor consoleColor, string text)
        {
            byte i = 1;
            do
            {
                i = 1;
                Console.Clear(); Console.ForegroundColor = consoleColor; Console.WriteLine($"[{text}]"); Console.ResetColor();
                Console.WriteLine("\nСписок викторин и их небольшое описание:\n");
                foreach (var obj in this.quizzesDictionary)
                {
                    if (i == this.currentPosition)
                    {
                        Console.WriteLine($"> {obj.Key} - \"{obj.Value}\"");
                        this.selectedQuiz = obj.Key;
                    }
                    else
                    {
                        Console.WriteLine($"  {obj.Key} - \"{obj.Value}\"");
                    }
                    ++i;
                }
                Console.Write("\nESC - назад");
            }
            while (HandleInput());
        }

        private bool HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(); // считывание значения нажатой клавиши

            switch (key.Key)
            {
                case ConsoleKey.UpArrow: Console.Clear(); if (currentPosition > minPosition) { --currentPosition; } break; // нажата клавиша вверх
                case ConsoleKey.DownArrow: Console.Clear(); if (currentPosition < maxPosition) { ++currentPosition; } break; // нажата клавиша вниз

                case ConsoleKey.Enter: return false;
                case ConsoleKey.Escape: this.selectedQuiz = null; return false;

                default: Console.Clear(); break;
            }
            return true;
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

        public void DisplayMenu()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[СТАРТ НОВОЙ ВИКТОРИНЫ]"); Console.ResetColor();
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

            this.DisplayMenu();
            do
            {
                key = Console.ReadKey(); // считывание значения нажатой клавиши

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: Console.Clear(); if (this.currentPosition > minPosition) { --this.currentPosition; } this.DisplayMenu(); break; // нажата клавиша вверх
                    case ConsoleKey.DownArrow: Console.Clear(); if (this.currentPosition < maxPosition) { ++this.currentPosition; } this.DisplayMenu(); break; // нажата клавиша вниз

                    case ConsoleKey.Enter: return;
                    case ConsoleKey.Escape: this.selectedResult = null; return;

                    default: Console.Clear(); this.DisplayMenu(); break;
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
