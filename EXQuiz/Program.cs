namespace EXQuiz
{
    internal class Program
    {
        static void Main()
        {
            Quiz quiz = new Quiz(@"C:\SDMQuiz\");
            quiz.SignUp();
        }
    }
}