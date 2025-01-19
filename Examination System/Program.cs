namespace Examination_System
{

    internal class Program
    {
        public static byte ShowMode()
        {
            byte userInput = 0;

            do
            {
                Console.WriteLine($"1-{enTypeMode.Doctor}");
                Console.WriteLine($"2-{enTypeMode.Student}");
                Console.WriteLine($"3-{enTypeMode.Exit}");
                try
                {
                    userInput = Convert.ToByte(Console.ReadLine());

                }
                catch (Exception )
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    continue;
                }
            } while (userInput > 3 || userInput <= 0);
            return userInput;
        }


         
        public static enTypeMode SelectMode(byte userInput)
        {
            enTypeMode mode = new enTypeMode();
            switch (userInput)
            {
                case 1:
                    mode = (enTypeMode)userInput;
                    // Console.WriteLine("You Entered The Doctor Mode");
                    break;
                case 2:
                    mode = (enTypeMode)userInput;
                    // Console.WriteLine("You Entered The Student Mode");
                    break;
                case 3:
                    mode = (enTypeMode)userInput;
                    break;
                default:
                    break;

            }
            return mode;
        }

        static void Main(string[] args)
        {
            StartProgram();
        }

        private static void StartProgram()
        {
            enTypeMode mode;
            do
            {
                mode = SelectMode(ShowMode());

                if (mode is enTypeMode.Doctor)
                {
                    Qtype type = Questions.SelectQuestionType(Questions.GetQuestionType());
                    int length = HowManyQuestion();
                    for (int i = 0; i < length; i++)
                    {
                        if (type is Qtype.TrueOrFalse)
                        {
                            Questions TFQuestions = new TrueOrFalse();
                            TFQuestions.AddQuestion(length, TFQuestions);
                        }
                        else if (type is Qtype.ChooseOneQuestion)
                        {
                            Questions ChQuestions = new ChooseOneChoice();
                            ChQuestions.AddQuestion(length, ChQuestions);
                        }
                        else if (type is Qtype.MultiplecationQuestion)
                        {
                            Questions MCQuestions = new MultipleChoiceQuestions();
                            MCQuestions.AddQuestion(length, MCQuestions);
                        }
                    }
                }
                else if (mode is enTypeMode.Student)
                {
                    if (Questions.AllQuestion.Count() != 0)
                    {
                        enFinalOrPractical typo = Exam.ChooseExam();
                        if (typo is enFinalOrPractical.Practical)
                        {
                            Exam exam = new Practical();
                            List<Questions> randomizeQuestions = exam.GenerateRandomNumber(Questions.AllQuestion);
                            double studentMarks = exam.CalculateTotalMarks(exam.ShowQuestionExam(randomizeQuestions), randomizeQuestions);
                            double totalMarks = exam.GetTotalMarkForEachQuestion(randomizeQuestions);
                            exam.ShowModelAnswer(studentMarks, totalMarks);
                            //exam.DeterminePassOrFailed(exam.CalculateTotalMarks(exam.ShowQuestionExam(randomizeQuestions), randomizeQuestions), randomizeQuestions);
                        }
                        else if (typo is enFinalOrPractical.Final)
                        {
                            Exam exam = new Final();
                            List<Questions> randomizeQuestions = exam.GenerateRandomNumber(Questions.AllQuestion);
                            double studentMarks = exam.CalculateTotalMarks(exam.ShowQuestionExam(randomizeQuestions), randomizeQuestions);
                            double totalMarks = exam.GetTotalMarkForEachQuestion(randomizeQuestions);
                            exam.ShowModelAnswer(studentMarks, totalMarks);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Exams havenot been added yet");
                    }
                }
            } while (mode != enTypeMode.Exit);
        }

        private static int HowManyQuestion()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("How Many Questions Do you want ? :");
                    int length = Convert.ToInt32(Console.ReadLine());
                    return length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
