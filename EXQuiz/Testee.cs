using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EXQuiz
{
    internal class Testee : User
    {
        public string name;
        public DateOnly birthDay;

        public string pathToResultFile;

        public Testee(string login, string password, string name, DateOnly birthDay) : base(login, password)
        {
            this.name = name;
            this.birthDay = birthDay;
        }



        public void StartNewQuiz()
        {
            QuizMenu quizMenu = new QuizMenu(); // отображение меню с викторинами
            quizMenu.DisplayMenu(ConsoleColor.Green, "СТАРТ НОВОЙ ВИКТОРИНЫ");
            string quizName = quizMenu.GetSelectedQuiz; // получение выбранной викторины
            if (quizName == null)
            {
                return;
            }

            StreamReader streamReader = new StreamReader(PATHTO.QUIZZES + quizName + ".txt");
            StreamWriter streamWriter = new StreamWriter(PATHTO.USERS + this.login + @"\QuizzesResults\" + quizName + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + " " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt"); // создание файла с результатами
            streamWriter.WriteLine(quizName + "\n");

            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{quizName}]"); Console.ResetColor();

            List<string> listOfAnswer = new List<string>(5) { "" };
            string answer;
            string question;
            byte counterCorrectAnswer = 0;

            streamReader.ReadLine(); // считывание в пустоту (название викторины)
            streamReader.ReadLine(); // считывание в пустоту (описание викторины)
            streamReader.ReadLine(); // считывание в пустоту (пробел)

            while (streamReader.Peek() != -1)
            {
                question = streamReader.ReadLine(); // считывание вопроса из файла
                listOfAnswer[0] = streamReader.ReadLine(); // считывание ответа из файла

                Console.WriteLine(question); // вывод вопроса пользователю
                Console.Write("Ваш ответ: "); answer = Console.ReadLine(); // получение ответа от пользователя

                streamWriter.WriteLine(question); // добавление вопроса в файл с результатами
                streamWriter.WriteLine($"Правильный ответ: {listOfAnswer[0]}"); // добавление правильного ответа в файл с результатами
                streamWriter.WriteLine($"Пользовательский ответ: {answer}\n"); // добавление пользовательского ответа в файл с результатами

                if (listOfAnswer[0] == answer)
                {
                    counterCorrectAnswer++;
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nВы ответили правильно!"); Console.ResetColor();
                    Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\nВы ответили неправильно, правильный ответ: {listOfAnswer[0]}"); Console.ResetColor();
                    Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
                }

                Console.WriteLine("\n");
            }

            streamWriter.Write($"Правильных ответов {counterCorrectAnswer} из 5"); // добавление итога в файл с результатами

            streamWriter.Close(); // закрытие потоков
            streamReader.Close();

            Quiz.CreateTopTestees(quizName); // так как был пройден тест, то топ создаётся заново

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\nВы прошли викторину с результатом {counterCorrectAnswer} из 5 правильных ответов."); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void ShowQuizzesResult()
        {
            ResultMenu resultMenu = new ResultMenu(PATHTO.USERS + this.login + @"\QuizzesResults\"); // отображение меню с результатами викторин
            string resultName = resultMenu.GetSelectedResult; // получение выбранного результата
            if (resultName == null)
            {
                return;
            }

            StreamReader streamReader = new StreamReader(PATHTO.USERS + this.login + @"\QuizzesResults\" + resultName + ".txt");

            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{resultName}]"); Console.ResetColor();

            streamReader.ReadLine(); // считывание в пустоту
            streamReader.ReadLine(); // считывание в пустоту

            while (streamReader.Peek() != -1)
            {
                Console.WriteLine(streamReader.ReadLine());
            }

            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }




        public void ChangeName()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ИМЕНИ]\n"); Console.ResetColor();

            Console.WriteLine($"Ваше текущее имя: {this.name}");
            Console.Write("Введите новое имя: "); string newName = Console.ReadLine().Trim();

            while (newName == null)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённое имя некорректно, попробуйте ещё раз: "); Console.ResetColor(); newName = Console.ReadLine().Trim();
            }
            this.name = newName;

            StreamWriterReader.WriteToFile(this);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nИмя упешно изменено!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }

        public void ChangePassword()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ПАРОЛЯ]\n"); Console.ResetColor();

            Console.WriteLine($"Ваш текущий пароль: {this.password}");
            Console.Write("Введите новый пароль: "); string newPassword = Console.ReadLine().Trim();

            while (Is.PasswordSimple(newPassword, this.password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль равен старому или слишком простой: должен содержать хотя бы одну прописную букву, строчную букву и цифру, попробуйте ещё раз: "); Console.ResetColor(); newPassword = Console.ReadLine().Trim();
            }
            this.password = newPassword;

            StreamWriterReader.WriteToFile(this);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПароль упешно изменён!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }

        public void ChangeBirthDay()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ДАТЫ РОЖДЕНИЯ]\n"); Console.ResetColor();

            Console.WriteLine($"Ваша текущая дата рождения: {this.birthDay}");
            Console.Write("Введите новую дату рождения в формате 30.04.2023: "); string input = Console.ReadLine().Trim(); DateOnly birthDay;

            while (!DateOnly.TryParseExact(input, "dd.MM.yyyy", out birthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine().Trim();
            }
            this.birthDay = birthDay;

            StreamWriterReader.WriteToFile(this);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nДата рождения упешно изменена!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public override string ToString()
        {
            return name;
        }
    }
}
