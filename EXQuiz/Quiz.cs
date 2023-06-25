using System.Text.RegularExpressions;

namespace EXQuiz
{
    internal class Quiz
    {
        User user;

        public Quiz()
        {
            if (!Directory.Exists(PATHTO.SDMQ)) // если пути не существует (т.е. программа в первый раз открывается)
            {
                Directory.CreateDirectory(PATHTO.SDMQ); // создание основной директории
                Directory.CreateDirectory(PATHTO.TOP); // создание директории с ТОПом
                Directory.CreateDirectory(PATHTO.QUIZZES); // создание директории с викторинами
                Directory.CreateDirectory(PATHTO.USERS); // создание директории с пользователями

                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("ЗДРАВСТВУЙТЕ, ВЫ БЕРЁТЕ НА СЕБЯ РОЛЬ АДМИНИСТРАТОРА"); Console.ResetColor();
                Console.WriteLine("Ваш логин задан автоматически: admin");
                Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine().Trim();
                while (Is.PasswordSimple(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль должен содержать хотя бы одну прописную букву, строчную букву и цифру, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine().Trim();
                }

                StreamWriterReader.WriteToFile(new Admin("admin", password));
            }
            else // на всякий случай, вдруг какой-то умник решит удалить всё
            {
                if (!Directory.Exists(PATHTO.TOP))
                {
                    Directory.CreateDirectory(PATHTO.TOP); // создание директории с ТОПом
                }

                if (!Directory.Exists(PATHTO.QUIZZES)) 
                {
                    Directory.CreateDirectory(PATHTO.QUIZZES); // создание директории с викторинами
                }

                if (!Directory.Exists(PATHTO.USERS))
                {
                    Directory.CreateDirectory(PATHTO.USERS); // создание директории с пользователями
                }

                if (!Directory.Exists(PATHTO.USERS + "admin") || !File.Exists(PATHTO.USERS + @"admin\admin.txt") || new FileInfo(PATHTO.USERS + @"admin\admin.txt").Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("ЗДРАВСТВУЙТЕ, ВЫ БЕРЁТЕ НА СЕБЯ РОЛЬ АДМИНИСТРАТОРА"); Console.ResetColor();
                    Console.WriteLine("Ваш логин задан автоматически: admin");
                    Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine().Trim();
                    while (Is.PasswordSimple(password))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль должен содержать хотя бы одну прописную букву, строчную букву и цифру, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine().Trim();
                    }

                    StreamWriterReader.WriteToFile(new Admin("admin", password));
                }
            }
        }


        public void SignIn()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[ВХОД В СУЩЕСТВУЮЩИЙ АККАУНТ]"); Console.ResetColor();

            Console.Write("\nВведите ваш логин: "); string login = Console.ReadLine().Trim();
            while (!Is.LoginExist(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин не существует, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine().Trim();
            }

            Console.Write("Введите ваш пароль: "); string password = Console.ReadLine().Trim();
            while (!Is.PasswordCorrect(login, password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль неверный, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine().Trim();
            }

            this.user = StreamWriterReader.ReadFromFile(login);
        }

        public void SignUp()
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("[РЕГИСТРАЦИЯ НОВОГО АККАУНТА]"); Console.ResetColor();

            Console.Write("\nПридумайте ваш логин: "); string login = Console.ReadLine().Trim();
            while (!Is.LoginCorrect(login))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый логин уже занят, попробуйте ещё раз: "); Console.ResetColor(); login = Console.ReadLine().Trim();
            }

            Console.Write("Придумайте ваш пароль: "); string password = Console.ReadLine().Trim();
            while (Is.PasswordSimple(password))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённый пароль должен содержать хотя бы одну прописную букву, строчную букву и цифру, попробуйте ещё раз: "); Console.ResetColor(); password = Console.ReadLine().Trim();
            }

            Console.Write("\nВведите своё имя: "); string name = Console.ReadLine().Trim();

            Console.Write("Введите свою дату рождения в формате 30.04.2023: "); string input = Console.ReadLine().Trim(); DateOnly birthDay;
            while (!DateOnly.TryParseExact(input, "dd.MM.yyyy", out birthDay))
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("Введённая дата некорректна, попробуйте ещё раз: "); Console.ResetColor(); input = Console.ReadLine().Trim();
            }

            this.user = new Testee(login, password, name, birthDay);
            StreamWriterReader.WriteToFile(this.user);
        }



        public void RunQuiz()
        {
            Console.Clear();
            
            MainMenu.DisplayMenu();

            Console.Clear();
            switch (MainMenu.GetCurrentPosition)
            {
                case 0: this.SignIn(); break;
                case 1: this.SignUp(); break;

                case 2: return;
            }

            if (this.user is Admin admin)
            {
                do
                {
                    AdminMenu.DisplayMenu();

                    Console.Clear();
                    switch (AdminMenu.GetCurrentPosition)
                    {
                        case 0: admin.CreateUser(); break;
                        case 1: admin.EditUser(); break;
                        case 2: admin.DeleteUser(); break;

                        case 3: admin.CreateQuiz(); break;
                        case 4: admin.EditQuiz(); break;
                        case 5: admin.DeleteQuiz(); break;

                        case 6: this.RunQuiz(); break;
                    }
                }
                while (true);
            }
            else if (this.user is Testee testee)
            {
                do
                {
                    TesteeMenu.DisplayMenu(testee.name);

                    Console.Clear();
                    switch (TesteeMenu.GetCurrentPosition)
                    {
                        case 0: testee.StartNewQuiz(); break;

                        case 1: testee.ShowQuizzesResult(); break;
                        case 2: this.ShowTopTestees(); break;

                        case 3: testee.ChangePassword(); break;
                        case 4: testee.ChangeName(); break;
                        case 5: testee.ChangeBirthDay(); break;

                        case 6: this.RunQuiz(); break;
                    }
                }
                while (true);
            }
        }


        public void ShowTopTestees()
        {
            QuizMenu quizMenu = new QuizMenu();
            quizMenu.DisplayMenu(ConsoleColor.Green, "ТОП УЧАСТНИКОВ ПО КОНКРЕТНОЙ ВИКТОРИНЕ");

            string quizName = quizMenu.GetSelectedQuiz; // получение выбранной викторины
            if (quizName == null) { return; } // костыль: если было возвращено null, значит пользователь нажал ESCAPE
            
            using StreamReader streamReader = new StreamReader(PATHTO.TOP + $"TOP {quizName.ToUpper()}.txt");

            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{streamReader.ReadLine()}]\n"); Console.ResetColor();
            streamReader.ReadLine(); // считывание в пустоту

            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(streamReader.ReadLine()); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine(streamReader.ReadLine()); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine(streamReader.ReadLine()); Console.ResetColor();

            while (streamReader.Peek() != -1) 
            {
                Console.WriteLine(streamReader.ReadLine());
            }

            Console.Write("\nДля продолжения нажмите любую кнопку.."); Console.ReadKey();
        }


        public static void CreateTopTestees(string quizName)
        {
            Dictionary<string, int> dictionaryWithUsersResults = new Dictionary<string, int>();

            DirectoryInfo directoryWithUsers = new DirectoryInfo(PATHTO.USERS); // открытие директории Users

            foreach (DirectoryInfo directoryWithUser in directoryWithUsers.GetDirectories()) // взятие папки каждого пользователя
            {
                if (Directory.Exists(directoryWithUser.FullName + @"\QuizzesResults"))
                {
                    DirectoryInfo directoryWithQuizzesResult = new DirectoryInfo(directoryWithUser.FullName + @"\QuizzesResults"); // открытие директории с результатами у каждого пользователя

                    foreach (FileInfo quizzesResult in directoryWithQuizzesResult.GetFiles()) // взятие каждого файла с результатами
                    {
                        if (quizzesResult.Name.StartsWith(quizName)) // так как все результаты хранятся вместе, то нужно сравнивать имя резульата (он содержит имя викторины) и выбранного пользователем результата
                        {
                            using StreamReader streamReader = new StreamReader(quizzesResult.FullName);

                            // ТУТ ДОЛЖНА БЫТЬ ПРОВЕРКА НА ТО, ЧТО ФАЙЛ ПУСТОЙ

                            streamReader.BaseStream.Seek(-8, SeekOrigin.End);
                            int result = (char)streamReader.Read() - 48;

                            if (dictionaryWithUsersResults.ContainsKey(directoryWithUser.Name)) // если пользователь уже есть в словаре (несколько раз проходил одну викторину)
                            {
                                if (result > dictionaryWithUsersResults[directoryWithUser.Name]) // если его новый результат лучше, то он добавляется в словарь
                                {
                                    dictionaryWithUsersResults[directoryWithUser.Name] = result;
                                }
                            }
                            else
                            {
                                dictionaryWithUsersResults.Add(directoryWithUser.Name, result);
                            }
                        }
                    }
                }
            }

            using StreamWriter streamWriter = new StreamWriter(PATHTO.TOP + $"TOP {quizName.ToUpper()}.txt");
            streamWriter.WriteLine($"ТОП ПО ВИКТОРИНЕ {quizName.ToUpper()}\n");

            List<KeyValuePair<string, int>> listyWithUsersResults = dictionaryWithUsersResults.OrderByDescending(x => x.Value).ToList();
            for (int i = 0; i < listyWithUsersResults.Count; i++)
            {
                streamWriter.WriteLine($"№{i + 1}. {listyWithUsersResults[i].Key} ответил верно на {listyWithUsersResults[i].Value} из 5 вопросов");
            }
        }
    }
}
