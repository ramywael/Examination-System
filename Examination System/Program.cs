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
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                }
            } while (userInput > 3 || userInput <=0);
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
            // Qtype type = Questions.SelectQuestionType(Questions.ShowQuestions(SelectMode(ShowMode())));
            enTypeMode mode;

            do
            {
                 mode = SelectMode(ShowMode());
                if (mode is enTypeMode.Doctor)
                {
                    Qtype type = Questions.SelectQuestionType(Questions.ShowQuestions(mode));
                    Console.WriteLine("How Many Questions Do you want ? :");
                    int length = Convert.ToInt32(Console.ReadLine());
                    if (type is Qtype.TrueOrFalse)
                    {
                        Questions TFQuestions = new TrueOrFalse();
                        TFQuestions.AddQuestion(length);
                    }
                    else if (type is Qtype.ChooseOneQuestion)
                    {
                        Questions ChQuestions = new ChooseOneChoice();
                        ChQuestions.AddQuestion(length);
                    }else if(type is Qtype.MultiplecationQuestion)
                    {
                        Questions MCQuestions = new MultipleChoiceQuestions();
                        MCQuestions.AddQuestion(length);
                    }


                }
                else if(mode is enTypeMode.Student)
                {
                    enFinalOrPractical typo = Exam.ChooseExam();
                    if (typo is enFinalOrPractical.Practical)
                    {
                        Practical exam = new Practical();
                        List < Questions > randomizeQuestions = exam.GenerateRandomNumber(Questions.AllQuestion, 4);
                        Console.WriteLine(exam.DeterminePassOrFailed(exam.CalculateTotalMarks(exam.ShowQuestionExam(randomizeQuestions), randomizeQuestions), randomizeQuestions));
                    }
                }
            } while (mode != enTypeMode.Exit);
  















        }
    }
}
