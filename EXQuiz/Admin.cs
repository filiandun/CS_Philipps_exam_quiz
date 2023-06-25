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

            Console.Write("Придумайте логин пользователю: "); string login = Console.ReadLine().Trim();
            while (!Is.LoginCorrect(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин уже занят или некоррекен: должен быть от 4 до 16 символов и должен содержать только ангийские буквы и цифры, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine().Trim();
            }

            Console.Write("Придумайте пароль пользователю: "); string password = Console.ReadLine().Trim();
            while (Is.PasswordSimple(password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль должен содержать хотя бы одну прописную букву, строчную букву и цифру, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine().Trim();
            }

            Console.Write("Введите имя пользователя: "); string name = Console.ReadLine().Trim();
            Console.Write("Введите дату рождения пользователя в формате 30.04.2023: "); string input = Console.ReadLine().Trim(); DateOnly birthDay;

            while (!DateOnly.TryParseExact(input, "dd.MM.yyyy", out birthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine().Trim();
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

            Console.Write("Введите логин пользователя: "); string login = Console.ReadLine().Trim();
            while (!Is.LoginExist(login) || login == "admin")
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин не соответствует ни одному пользователю, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine().Trim(); ;
            }

            Directory.Delete(PATHTO.USERS + login, true);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПользователь успешно удалён!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void CreateQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[СОЗДАНИЕ ВИКТОРИНЫ]\n"); Console.ResetColor();

            Console.Write("Введите название новой викторины: "); string quizName = Console.ReadLine().Trim();
            while (Is.QuizExist(quizName) || quizName == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённое название уже занято или оно некорректно, попробуйте ещё раз: "); Console.ResetColor(); quizName = Console.ReadLine().Trim();
            }
            StreamWriter streamWriter = new StreamWriter(PATHTO.QUIZZES + quizName + ".txt"); // открытие потока
            streamWriter.WriteLine(quizName);

            Console.Write("Введите описание новой викторины: "); string quizDescription = Console.ReadLine().Trim();
            while (quizDescription == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Описание некорректно, попробуйте ещё раз: "); Console.ResetColor(); quizDescription = Console.ReadLine().Trim();
            }
            streamWriter.WriteLine(quizDescription + "\n");

            string question;
            string answer;
            for (int i = 1; i <= 5; ++i)
            {
                Console.Write($"\nВведите вопрос номер {i}: "); question = Console.ReadLine().Trim();
                while (question == "\n" || question == "" || question == " ")
                {
                    Console.Write("Вопрос некорректен, попробуйте ещё раз: "); Console.ResetColor(); question = Console.ReadLine().Trim();
                }
                streamWriter.WriteLine($"{i}. {question}");

                Console.Write($"Введите ответ на этот вопрос: "); answer = Console.ReadLine().Trim();
                while (answer == "\n" || answer == "" || answer == " ")
                {
                    Console.Write("Вопрос некорректен, попробуйте ещё раз: "); Console.ResetColor(); answer = Console.ReadLine().Trim();
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

            if (Is.QuizExist(quizName))
            {
                File.Delete(PATHTO.QUIZZES + quizName + ".txt");

                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\nВикторина успешно удалена!"); Console.ResetColor();
                Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\nОшибка, викторина не была удалена!"); Console.ResetColor();
                Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
            }

        }
    }
}
