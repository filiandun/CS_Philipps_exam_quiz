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
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]"); Console.ResetColor();
                    Console.WriteLine("> вход");
                    Console.WriteLine("  регистрация\n");

                    Console.WriteLine("  выход");
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]"); Console.ResetColor();
                    Console.WriteLine("  вход");
                    Console.WriteLine("> регистрация\n");

                    Console.WriteLine("  выход");
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[SUPER DUPER MEGA QUIZ]"); Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК,  , ВЫ В SDMQ]"); Console.ResetColor();
                    Console.WriteLine("> начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК,  , ВЫ В SDMQ]"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("> посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("> посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("> изменить пароль");
                    Console.WriteLine("  изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]"); Console.ResetColor();
                    Console.WriteLine("  начать новую викторину\n");

                    Console.WriteLine("  посмотреть свои результаты прошлых викторин");
                    Console.WriteLine("  посмотреть ТОП-5 по конкретной викторине\n");

                    Console.WriteLine("  изменить пароль");
                    Console.WriteLine("> изменить дату рождения\n");

                    Console.WriteLine("  выйти");

                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ДОБРОГО ВРЕМЕНИ СУТОК, , ВЫ В SDMQ]"); Console.ResetColor();
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
        private byte currentPosition;
        private byte minPosition;
        private byte maxPosition;
        Dictionary<string, string> dictionary;
        public string currentKey;

        public QuizMenu(byte minPosition, byte maxPosition, Dictionary<string, string> dictionary)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
            this.dictionary = dictionary;
        }

        public void Menu()
        {
            byte i = 0;

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[СТАРТ НОВОЙ ВИКТОРИНЫ]"); Console.ResetColor();
            Console.WriteLine("Список викторин и их небольшое описание: ");
            foreach (var obj in this.dictionary)
            {
                if (i == this.currentPosition)
                {
                    Console.WriteLine($"> {i + 1}. {obj.Key} - \"{obj.Value}\"");
                    this.currentKey = obj.Key;
                }
                else
                {
                    Console.WriteLine($"  {i + 1}. {obj.Key} - \"{obj.Value}\"");
                }
                ++i;
            }
        }

        public string Choice()
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

                    case ConsoleKey.Enter: return this.currentKey;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }
    }




    public class ResultMenu
    {
        private byte currentPosition;
        private byte minPosition;
        private byte maxPosition;
        public string currentResult;
        List<string> list;

        public ResultMenu(byte minPosition, byte maxPosition, List<string> list)
        {
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
            this.list = list;
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[СТАРТ НОВОЙ ВИКТОРИНЫ]"); Console.ResetColor();
            Console.WriteLine("Список результатов викторин: ");
            for (int i = 0; i < this.list.Count(); ++i)
            {
                if (i == this.currentPosition)
                {
                    Console.WriteLine($"> {i + 1}. {this.list[i]}");
                    this.currentResult = this.list[i];
                }
                else
                {
                    Console.WriteLine($"  {i + 1}. {this.list[i]}");
                }
            }
        }

        public string Choice()
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

                    case ConsoleKey.Enter: return this.currentResult;

                    default: Console.Clear(); this.Menu(); break;
                }
            }
            while (true);
        }
    }
}
