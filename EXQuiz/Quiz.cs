﻿using System.Text.RegularExpressions;

namespace EXQuiz
{
    internal class Quiz
    {
        DirectoryInfo directoryInfo; // для работы с папками (под сомнением её надобность)
        StreamReader streamReader;
        StreamWriter streamWriter;

        private string pathToSDMQ;
        private string pathToQuizzes;
        private string pathToUsers;

        User user;

        public Quiz(string path)
        {
            this.pathToSDMQ = path; // основная директория
            this.pathToUsers = path + @"Users\"; // директория с пользователями
            this.pathToQuizzes = path + @"Quizzes\"; // директория с викторинами

            if (!Directory.Exists(this.pathToSDMQ)) // если пути не существует (т.е. программа в первый раз открывается)
            {
                Directory.CreateDirectory(this.pathToSDMQ); // создание основной директории
                Directory.CreateDirectory(this.pathToQuizzes); // создание директории с викторинами
                Directory.CreateDirectory(this.pathToUsers); // создание директории с пользователями

                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("ЗДРАВСТВУЙТЕ, ВЫ БЕРЁТЕ НА СЕБЯ РОЛЬ АДМИНИСТРАТОРА"); Console.ResetColor();
                Console.WriteLine("Ваш логин задан автоматически: admin");
                Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine();

                this.WriteToFile("admin", password);
            }
        }



        private void WriteToFile(string login, string password, string name = null, DateOnly birthDay = new DateOnly())
        {
            Directory.CreateDirectory(this.pathToUsers + login); // создание директории с пользователем
            Directory.CreateDirectory(this.pathToUsers + login + @"\QuizzesResults"); // создание директории с результатами тестов

            this.streamWriter = new StreamWriter(this.pathToUsers + login + @"\" + login + ".txt"); // открытие потока для записи
            // 
            this.streamWriter.WriteLine(login); // запись логина
            this.streamWriter.Write(password); // запись пароля

            if (name != null) // у админа нет имени и дня рождения, поэтому нужна проверка
            {
                this.streamWriter.WriteLine("\n" + name);
                this.streamWriter.Write(birthDay);

                this.user = new Testee(login, password, name, birthDay);
                this.streamWriter.Close(); // ВМЕСТО ЭТОГО ЛУЧШЕ ОБЕРНУТЬ В TRY FINALLY ИЛИ USING
                return;
            }

            this.user = new Admin(login, password);
            this.streamWriter.Close(); // закрытие потока // интересно, что пока этой строки не было, файл создавался, но в него ничего не записывалось
        }


        private void ReadFromFile(string login)
        {
            this.streamReader = new StreamReader(this.pathToUsers + login + @"\" + login + ".txt"); // открытие потока для чтения

            this.streamReader.ReadLine(); // считывание в пустоту
            string password = this.streamReader.ReadLine();

            if (login != "admin") // повторюсь, у админа нет имени и дня рождения, поэтому нужна проверка
            {
                string name = this.streamReader.ReadLine();
                DateOnly birthDay = new DateOnly(2004, 06, 24); //this.streamReader.ReadLine();

                this.user = new Testee(login, password, name, birthDay);
                this.streamReader.Close();
                return;
            }

            this.user = new Admin(login, password);
            this.streamReader.Close();
        }





        public void SignIn()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[ВХОД В СУЩЕСТВУЮЩИЙ АККАУНТ]"); Console.ResetColor();

            Console.Write("\nВведите ваш логин: "); string login = Console.ReadLine();
            while (!this.isLoginExist(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин не существует, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Введите ваш пароль: "); string password = Console.ReadLine();
            while (!this.isPasswordCorrect(login, password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль неверный, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine();
            }

            // ПОПРОБОВАТЬ СДЕЛАТЬ ТАК, ЧТОБЫ ПОТОК this.streamReader открывался тут, а дальше, не закрываясь и не открываясь повторно, использовался в isPasswordCorrect() и потом в ReadFromFile();

            this.ReadFromFile(login);
        }

        public void SignUp()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[РЕГИСТРАЦИЯ НОВОГО АККАУНТА]"); Console.ResetColor();

            Console.Write("\nПридумайте ваш логин: "); string login = Console.ReadLine();
            while (this.isLoginExist(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин уже занят, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine();
            while (this.isPasswordSimple(login, password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль слишком простой, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine();
            }

            Console.Write("\nВведите своё имя: "); string name = Console.ReadLine();
            Console.Write("Введите свою дату рождения в формате 30.04.2023: "); string input = Console.ReadLine(); DateOnly newBirthDay = new DateOnly();

            while (!this.isBirthDayCorrect(input, ref newBirthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine();
                break;
            }

            this.WriteToFile(login, password, name, newBirthDay);
        }





        private bool isLoginExist(string login)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(this.pathToUsers); // открытие директории Users

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories()) // получение каждой папки оттуда
            {
                if (directory.Name == login) // сравнение имени папки с логином
                {
                    return true;
                }
            }

            return false;
        }

        private bool isPasswordCorrect(string login, string password)
        {
            this.streamReader = new StreamReader(this.pathToUsers + login + @"\" + login + ".txt");

            this.streamReader.ReadLine(); // считывание в пустоту
            if (password == this.streamReader.ReadLine())
            {
                return true;
            }

            return false;
        }

        private bool isPasswordSimple(string login, string password)
        {
            // TO DO
            // ДУМАЮ, ПРОВЕРКУ НА QWERTY ИЛИ 1234 НЕ ДЕЛАТЬ, ПРОСТО ОБЯЗАТЬ ЧЕРЕЗ REGEX, ЧТОБЫ В ПАРОЛЕ БЫЛИ ЗАГЛАВНЫЕ, СТРОЧНЫЕ БУКВЫ И ЦИФРЫ
            return false;
        }

        private bool isBirthDayCorrect(string input, ref DateOnly birthDay)
        {
            List<int> date = new List<int>(3);
            string pattern = @"^[0-3]?[0-9].[0-1]?[0-9].[0-9]+$";
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                foreach (string str in input.Split('.'))
                {
                    date.Add(Convert.ToInt32(str));
                }

                try
                {         
                    birthDay = new DateOnly(date[2], date[1], date[0]);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }


        public void Start()
        {
            MainMenu menu = new MainMenu(0, 2);
            TesteeMenu testeeMenu = new TesteeMenu(0, 5);
            AdminMenu adminMenu = new AdminMenu(0, 6);

            switch (menu.Choice())
            {
                case 0: Console.Clear(); this.SignIn(); break;
                case 1: Console.Clear(); this.SignUp(); break;

                case 2: Environment.Exit(0); break;
            }

            if (this.user is Admin)
            {
                Admin admin = this.user as Admin;
                do
                {
                    Console.Clear();
                    switch (adminMenu.Choice())
                    {
                        case 0: Console.Clear(); admin.CreateUser(); break;
                        case 1: Console.Clear(); admin.EditUser(); break;
                        case 2: Console.Clear(); admin.DeleteUser(); break;

                        case 3: Console.Clear(); admin.CreateQuiz(); break;
                        case 4: Console.Clear(); admin.EditQuiz(); break;
                        case 5: Console.Clear(); admin.DeleteQuiz(); break;

                        case 6: Console.Clear(); this.Start(); break;
                    }
                }
                while (true);
            }
            else
            {
                do
                {
                    Console.Clear();
                    switch (testeeMenu.Choice())
                    {
                        case 0: Console.Clear(); this.StartNewQuiz(); break;

                        case 1: Console.Clear(); this.ShowQuizzesResult(); break;
                        case 2: Console.Clear(); break;

                        //case 2-3: Console.Clear(); this.ChangeName(); break;
                        case 3: Console.Clear(); this.ChangePassword(); break;
                        case 4: Console.Clear(); this.ChangeBirthDay(); break;

                        case 5: Console.Clear(); this.Start(); break;
                    }
                }
                while (true);
            }
        }



        public void StartNewQuiz()
        {
            QuizMenu quizMenu = new QuizMenu(this.pathToQuizzes); // отображение меню с викторинами
            string quizName = quizMenu.GetSelectedQuiz; // получение выбранной викторины
            if (quizName == null)
            {
                return;
            }

            StreamReader streamReader = new StreamReader(this.pathToQuizzes + quizName + ".txt");
            StreamWriter streamWriter = new StreamWriter(this.pathToUsers + this.user.login + @"\QuizzesResults\" + quizName + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + " " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt"); // создание файла с результатами
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

            streamWriter.WriteLine($"Правильных ответов {counterCorrectAnswer} из 5\n"); // добавление итога в файл с результатами

            streamWriter.Close(); // закрытие потоков
            streamReader.Close();

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\nВы прошли викторину с результатом {counterCorrectAnswer} из 5 правильных ответов."); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void ShowQuizzesResult()
        {
            ResultMenu resultMenu = new ResultMenu(this.pathToUsers + this.user.login + @"\QuizzesResults\"); // отображение меню с результатами викторин
            string resultName = resultMenu.GetSelectedResult; // получение выбранного результата
            if (resultName == null)
            {
                return;
            }

            StreamReader streamReader = new StreamReader(this.pathToUsers + this.user.login + @"\QuizzesResults\" + resultName + ".txt");

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
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ПАРОЛЯ]"); Console.ResetColor();

            Testee testee = this.user as Testee;

            Console.WriteLine($"Ваше текущее имя: {testee.birthDay}");
            Console.Write("Введите новое имя: "); string newName = Console.ReadLine();

            while (true)
            {
                break;
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённое имя некорректно, попробуйте ещё раз: "); Console.ResetColor(); newName = Console.ReadLine();
            }

            this.WriteToFile(testee.login, testee.password, newName, testee.birthDay);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nИмя упешно изменено!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }



        public void ChangePassword()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ПАРОЛЯ]"); Console.ResetColor();

            Console.WriteLine($"Ваш текущий пароль: {this.user.password}");
            Console.Write("Введите новый пароль: "); string newPassword = Console.ReadLine();

            while (this.user.password == newPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Новый пароль не должен совпадать со старым, попробуйте ещё раз: "); Console.ResetColor(); newPassword = Console.ReadLine();
            }

            Console.WriteLine(File.Exists(this.pathToUsers + this.user.login + @"\" + this.user.login + ".txt"));
            File.Delete(this.pathToUsers + this.user.login + @"\" + this.user.login + ".txt");

            if (this.user is Testee)
            {
                Testee testee = this.user as Testee;
                this.WriteToFile(testee.login, newPassword, testee.name, testee.birthDay);
            }
            if (this.user is Admin)
            {
                Admin admin = this.user as Admin;
                this.WriteToFile(admin.login, newPassword);
            }

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nПароль упешно изменён!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public void ChangeBirthDay()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[ИЗМЕНЕНИЕ ПАРОЛЯ]"); Console.ResetColor();

            Testee testee = this.user as Testee;

            Console.WriteLine($"Ваша текущая дата рождения: {testee.birthDay}");
            Console.Write("Введите новую дату рождения в формате 30.04.2023: "); string input = Console.ReadLine(); DateOnly newBirthDay = new DateOnly();

            while (this.isBirthDayCorrect(input, ref newBirthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine(); 
                break;
            }

            this.WriteToFile(testee.login, testee.password, testee.name, newBirthDay);

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nДата рождения упешно изменена!"); Console.ResetColor();
            Console.Write("Для продолжения нажмите любую кнопку.."); Console.ReadKey();
        }
    }
}
