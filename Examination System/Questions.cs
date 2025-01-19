using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Questions
    {


        public Qtype QtypeObject { get; set; }
        public Qlevel Qlevel { get; set; }
        public double Mark { get; set; }
        public string QuestionHeader { get; set; }
        public static List<Questions> AllQuestion { get; set; } = new List<Questions>();
        protected Questions(Qtype qtype, Qlevel qlevel, double mark, string questionHeader)
        {
            QtypeObject = qtype;
            Qlevel = qlevel;
            Mark = mark;
            QuestionHeader = questionHeader;
        }
        public override string ToString()
        {
            return $"Question :{QuestionHeader} \t  mark is {Mark}";
        }

        public static byte GetQuestionType()
        {
            byte userInoutTypeQuestion=0;
            do {

                Console.WriteLine($"1-{Qtype.TrueOrFalse}");
                Console.WriteLine($"2-{Qtype.ChooseOneQuestion}");
                Console.WriteLine($"3-{Qtype.MultiplecationQuestion}");
                Console.WriteLine("Please select a question type by entering 1, 2, or 3:");
                try
                {
                    userInoutTypeQuestion = Convert.ToByte(Console.ReadLine());
                }
                catch (Exception )
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    continue;
                }
            } while (userInoutTypeQuestion < 1 || userInoutTypeQuestion > 3);
            return userInoutTypeQuestion;
        }

        public static Qtype SelectQuestionType(byte userInputTypeQuestion)
        {
            Qtype questionType = new Qtype();
            switch (userInputTypeQuestion)
            {
                case 1:
                    questionType = (Qtype)userInputTypeQuestion;
                    Console.WriteLine($"You Entered {questionType}");
                    break;
                case 2:
                    questionType = (Qtype)userInputTypeQuestion;
                    Console.WriteLine($"You Entered {questionType}");
                    break;
                case 3 :
                    questionType = (Qtype)userInputTypeQuestion;
                    Console.WriteLine($"You Entered {questionType}");
                    break;
                default:
                    Console.WriteLine($"You Entered an unavilable type of question");
                    break;

            }
            return questionType;
        }


        protected void AddQuestionDetails()
        {
            Console.WriteLine($"Choose The Level of the Question 1-{Qlevel.Easy}, 2-{Qlevel.Medium}, 3-{Qlevel.Hard}");
            byte userInputTypeLevel = Convert.ToByte(Console.ReadLine());
            if (userInputTypeLevel < 1 || userInputTypeLevel > 3)
            {
                throw new ArgumentException("Invalid level. Please choose a number between 1 and 3.");
            }
            Qlevel = (Qlevel)userInputTypeLevel;
            Console.WriteLine("Enter The Question Please:");
            string questionHeader = Convert.ToString(Console.ReadLine());
            if (string.IsNullOrEmpty(questionHeader))
            {
                throw new ArgumentException("Invalid,Please Enter a valid question");
            }
            QuestionHeader = questionHeader;
            Console.WriteLine("Please Enter The Mark");
           double mark = Convert.ToDouble(Console.ReadLine());
            if (mark <= 0)
            {
                throw new ArgumentException("Mark must be a positive number.");
            }
            Mark = mark;
        }

        protected void HandleExceptions(Exception ex)
        {
            if(ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine("Invalid Input,Please Enter A Valid Number");
            }else if(ex is ArgumentException )
            {
                Console.WriteLine(ex.Message);
            }
            else
            {
                Console.WriteLine($"UnExpected Error has occured{ex.Message}");
            }
        }

        protected abstract void AddQuestionSpecifics();
        public void AddQuestion(int lenght,Questions questionType)
        {
                while (true)
                {
                    try
                    {
                        AddQuestionDetails();
                        AddQuestionSpecifics(); 
                        Questions.AllQuestion.Add(questionType);
                        break;
                    }
                    catch (Exception e)
                    {
                        HandleExceptions(e);
                    }

                }
            
       }

        protected void AddChoices(List<string> Choices)
        {
            for (int r = 0; r < 4; r++)
            {
                Console.WriteLine($"Enter The Choice Number {r + 1}:");
                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    throw new ArgumentException("Choice cannot be empty.");
                }
                Choices.Add(choice);
            }
        }
    }


}
