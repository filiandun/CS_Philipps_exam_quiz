using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class Admin : User
    {
        private string path = @"C:\SDMQuiz\"; // TEMP


        public Admin(string login, string password) : base(login, password) { }

        public void CreateUser()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[РЕГИСТРАЦИЯ ПОЛЬЗОВАТЕЛЯ]"); Console.ResetColor();

            Console.Write("Придумайте логин пользователю: "); string login = Console.ReadLine();
            while (false/*this.isLoginExist(login)*/)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин уже занят, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Придумайте пароль пользователю: "); string password = Console.ReadLine();
            while (false/*this.isPasswordSimple(login, password)*/)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Ввведённый пароль слишком простой, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Введите имя пользователя: "); string name = Console.ReadLine();
            Console.Write("Введите дату рождения пользователя: ПОКА СТАТИЧЕСКИ"); DateOnly birthDay = new DateOnly(2004, 06, 24);

            // this.WriteToFile(login, password, name, birthDay);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПользователь успешно зарегистрирован!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }

        public void EditUser()
        {

        }

        public void DeleteUser()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ]"); Console.ResetColor();

            Console.Write("Введите логин пользователя: "); string login = Console.ReadLine();
            while (false/*this.isLoginExist(login)*/)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин не соответсвует ни одному пользователю, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            // Directory.Delete(this.path + @"Users\" + login);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПользователь успешно удалён!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void CreateQuiz()
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[СОЗДАНИЕ ВИКТОРИНЫ]"); Console.ResetColor();

            Console.Write("Введите название новой викторины: "); string quizName = Console.ReadLine();
            while (File.Exists(this.path + @"Quizzes\" + quizName + ".txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённое название уже занято, попробуйте ещё раз: "); Console.ResetColor(); quizName = Console.ReadLine();
            }
            StreamWriter streamWriter = new StreamWriter(this.path + @"Quizzes\" + quizName + ".txt");
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
                streamWriter.Write(answer); if (i < 5) { streamWriter.WriteLine(); } // чтобы лишний перенос строки не добавился на последнем ответе
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
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("[УДАЛЕНИЕ ВИКТОРИНЫ]"); Console.ResetColor();

            // ЭТОТ БЛОК НУЖНО БЫ ПЕРЕНЕСТИ В QuizMenu
            StreamReader streamReader = null;
            Dictionary<string, string> quizzes = new Dictionary<string, string>(); // создание словаря, где будет хранится имя и описание каждой викторины
            DirectoryInfo directoryInfo = new DirectoryInfo(this.path + "Quizzes"); // открытие директории Quizzes
            string quizName2;
            string quizDescription;
            foreach (FileInfo file in directoryInfo.GetFiles()) // получение каждого файла оттуда
            {
                streamReader = new StreamReader(file.FullName);

                quizName2 = streamReader.ReadLine();
                quizDescription = streamReader.ReadLine();

                if (quizName2 != null && quizDescription != null) // ТУТ ПУНКТ 4 ПОФИКШЕН
                {
                    quizzes.Add(quizName2, quizDescription);
                }
            }
            //

            QuizMenu quizMenu = new QuizMenu(0, (byte)(quizzes.Count() - 1), quizzes);
            string quizName = quizMenu.Choice();

            File.Delete(this.path + @"Quizzes\" + quizName + ".txt");

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nВикторина успешно удалена!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }
    }
}
