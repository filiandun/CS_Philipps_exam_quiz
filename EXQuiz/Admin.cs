using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class Admin : User
    {
        public Admin(string login, string password) : base(login, password) { }

        public void CreateUser()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[РЕГИСТРАЦИЯ ПОЛЬЗОВАТЕЛЯ]\n"); Console.ResetColor();

            Console.Write("Придумайте логин пользователю: "); string login = Console.ReadLine();
            while (Is.LoginExist(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин уже занят, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Придумайте пароль пользователю: "); string password = Console.ReadLine();
            while (Is.PasswordSimple(login, password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Ввведённый пароль слишком простой, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Введите имя пользователя: "); string name = Console.ReadLine();
            Console.Write("Введите дату рождения пользователя в формате 30.04.2023: "); string input = Console.ReadLine(); DateOnly birthDay;

            while (!DateOnly.TryParseExact(input, "dd.MM.yyyy", out birthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine();
            }

            StreamWriterReader.WriteToFile(new Testee(login, password, name, birthDay));

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПользователь успешно зарегистрирован!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }

        public void EditUser()
        {

        }

        public void DeleteUser()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ]\n"); Console.ResetColor();

            Console.Write("Введите логин пользователя: "); string login = Console.ReadLine();
            while (Is.LoginExist(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин не соответсвует ни одному пользователю, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Directory.Delete(Paths.pathToUsers + login, true);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПользователь успешно удалён!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void CreateQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[СОЗДАНИЕ ВИКТОРИНЫ]\n"); Console.ResetColor();

            Console.Write("Введите название новой викторины: "); string quizName = Console.ReadLine();
            while (Is.QuizExist(quizName))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённое название уже занято, попробуйте ещё раз: "); Console.ResetColor(); quizName = Console.ReadLine();
            }
            StreamWriter streamWriter = new StreamWriter(Paths.pathToQuizzes + quizName + ".txt"); // открытие потока
            streamWriter.WriteLine(quizName);

            Console.Write("Введите описание новой викторины: "); string quizDescription = Console.ReadLine();
            while (quizDescription == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Описание некорректно, попробуйте ещё раз: "); Console.ResetColor(); quizDescription = Console.ReadLine();
            }
            streamWriter.WriteLine(quizDescription + "\n");

            string question;
            string answer;
            for (int i = 1; i <= 5; ++i)
            {
                Console.Write($"\nВведите вопрос номер {i}: "); question = Console.ReadLine();
                while (question == "\n" || question == "" || question == " ")
                {
                    Console.Write("Вопрос некорректен, попробуйте ещё раз: "); Console.ResetColor(); question = Console.ReadLine();
                }
                streamWriter.WriteLine($"{i}. {question}");

                Console.Write($"Введите ответ на этот вопрос: "); answer = Console.ReadLine();
                while (answer == "\n" || answer == "" || answer == " ")
                {
                    Console.Write("Вопрос некорректен, попробуйте ещё раз: "); Console.ResetColor(); answer = Console.ReadLine();
                }
                streamWriter.Write(answer); if (i < 5) { streamWriter.WriteLine(); } // условие - чтобы лишний перенос строки не добавился на последнем ответе
            }

            streamWriter.Close();

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nВикторина успешно создана!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }

        public void EditQuiz()
        {

        }

        public void DeleteQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[УДАЛЕНИЕ ВИКТОРИНЫ]\n"); Console.ResetColor();

            QuizMenu quizMenu = new QuizMenu(); // отображение меню с викторинами
            quizMenu.DisplayMenu(ConsoleColor.Red, "УДАЛЕНИЕ ВИКТОРИНЫ");

            string quizName = quizMenu.GetSelectedQuiz; // получение выбранной викторины
            if (quizName == null) { return; } // значит был нажат escape в меню

            if (!Is.QuizExist(quizName))
            {
                File.Delete(Paths.pathToQuizzes + quizName + ".txt");

                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nВикторина успешно удалена!"); Console.ResetColor();
                Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nОшибка, викторина не была удалена!"); Console.ResetColor();
                Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
            }

        }
    }
}
