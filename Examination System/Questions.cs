using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal enum Qtype
    {
        TrueOrFalse = 1,
        ChooseOneQuestion = 2,
        MultiplecationQuestion = 3
    }
    internal enum QTF
    {
        True = 1,
        False = 2,
    }
    internal enum Qlevel
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
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

        public static byte ShowQuestions(enTypeMode mode)
        {
            Console.WriteLine($"1-{Qtype.TrueOrFalse}");
            Console.WriteLine($"2-{Qtype.ChooseOneQuestion}");
            Console.WriteLine($"3-{Qtype.MultiplecationQuestion}");
            Console.WriteLine("Choose Between 3 numbers (1-2-3)");
            byte userInoutTypeQuestion = Convert.ToByte(Console.ReadLine());
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

        public abstract void AddQuestion(int lenght);

        public abstract void ShowAllTFQuestions();

        public static List<Questions> CombineTwoList(List<Questions> givenList)
        {
            AllQuestion.AddRange(givenList);
            return AllQuestion;
        }

    }

    class TrueOrFalse : Questions
    {
        List<Questions> QuestionsTorF = new List<Questions>();
        public TrueOrFalse(Qtype qtype = Qtype.TrueOrFalse, Qlevel qlevel = Qlevel.Hard, double mark = 0, string questionHeader = " ", QTF answer = QTF.False) : base(qtype, qlevel, mark, questionHeader)
        {
            this.Qanswer = answer;
        }

        public QTF Qanswer { get; set; }

        public override void AddQuestion(int lenght)
        {
            byte userInputTypeLevel = 0;
            byte userInputTypeAnswer = 0;

            for (int i = 0; i < lenght; i++)
            {
                TrueOrFalse TFQuestions = new TrueOrFalse();
                Console.WriteLine($"Choose The Level of the Question 1-{Qlevel.Easy} 2- {Qlevel.Medium} 3- {Qlevel.Hard}");
                userInputTypeLevel = Convert.ToByte(Console.ReadLine());
                TFQuestions.Qlevel = (Qlevel)userInputTypeLevel;
                Console.WriteLine("Enter The Question Please :");
                TFQuestions.QuestionHeader = Console.ReadLine();
                Console.WriteLine("Please Enter The Maek :");
                TFQuestions.Mark = Convert.ToByte(Console.ReadLine());
                Console.WriteLine($"Answer ? Choose 1-{QTF.True} 2-{QTF.False}");
                userInputTypeAnswer = Convert.ToByte(Console.ReadLine());
                TFQuestions.Qanswer = (QTF)userInputTypeAnswer;
                QuestionsTorF.Add(TFQuestions);
            }
            Questions.CombineTwoList(QuestionsTorF);
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{QTF.True} 2-{QTF.False}";
        }
        public override void ShowAllTFQuestions()
        {
            for (int j = 0; j < QuestionsTorF.Count; j++)
            {
                Console.WriteLine($"Question{j + 1} : {QuestionsTorF[j].QuestionHeader} And The Mark is {QuestionsTorF[j].Mark}");
            }
        }
    }

    class ChooseOneChoice : Questions
    {
        private List<string> Choices { get; set; }
        public byte UserAnswer { get; set; }

        List<Questions> ChooseOneChoiceQuestion { get; set; } = new List<Questions>();
        public ChooseOneChoice(Qtype qtype = Qtype.ChooseOneQuestion, Qlevel qlevel = Qlevel.Easy, double mark = 0, string questionHeader = " ", byte userAnswer = 1) : base(qtype, qlevel, mark, questionHeader)
        {
            Choices = new List<string>();
            this.UserAnswer = userAnswer;
        }

        public override void AddQuestion(int lenght)
        {
            byte userInputTypeLevel = 0;
            byte userInputTypeAnswer = 0;

            for (int i = 0; i < lenght; i++)
            {
                ChooseOneChoice CHQuestions = new ChooseOneChoice();
                Console.WriteLine($"Choose The Level of the Question 1-{Qlevel.Easy} 2- {Qlevel.Medium} 3- {Qlevel.Hard}");
                userInputTypeLevel = Convert.ToByte(Console.ReadLine());
                CHQuestions.Qlevel = (Qlevel)userInputTypeLevel;
                Console.WriteLine("Enter The Question Please :");
                CHQuestions.QuestionHeader = Console.ReadLine();
                Console.WriteLine("Please Enter The Maek :");
                CHQuestions.Mark = Convert.ToByte(Console.ReadLine());

                for (int r = 0; r < 4; r++)
                {
                    Console.WriteLine($"Enter The Choose Number {r + 1} :");
                    CHQuestions.Choices.Add(Console.ReadLine());
                }
                Console.WriteLine("Question Answer : ?");
                //Console.WriteLine($"Answer ? Choose 1-{QTF.True} 2-{QTF.False}");
                CHQuestions.UserAnswer = Convert.ToByte(Console.ReadLine());
                ChooseOneChoiceQuestion.Add(CHQuestions);
            }
            Questions.CombineTwoList(ChooseOneChoiceQuestion);
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{Choices[0]} \n 2-{Choices[1]} \n 3-{Choices[2]}\n 4-{Choices[3]}";
        }
        public override void ShowAllTFQuestions()
        {
            for (int j = 0; j < ChooseOneChoiceQuestion.Count; j++)
            {
                Console.WriteLine($"Question{j + 1} : {ChooseOneChoiceQuestion[j].QuestionHeader} And The Mark is {ChooseOneChoiceQuestion[j].Mark}");
            }
        }
    }





    class MultipleChoiceQuestions : Questions
    {
        private List<string> Choices { get; set; }
        public List<byte> UserAnswer { get; set; }

        List<Questions> MultipleChoiceQuestion { get; set; } = new List<Questions>();
        public MultipleChoiceQuestions(Qtype qtype = Qtype.MultiplecationQuestion, Qlevel qlevel = Qlevel.Easy, double mark = 0, string questionHeader = " ") : base(qtype, qlevel, mark, questionHeader)
        {
            Choices = new List<string>();
            UserAnswer = new List<byte>();
        }


        public short IsNumberInArray(List<byte> answers, byte number)
        {
            for (int i = 0; i < answers.Count(); i++)
            {
                if (number == answers[i])
                {
                    Console.WriteLine("This Answer IS Already Stored");
                    return answers[i];
                }
            }
            return -1;
        }

        public bool DetermineIsInArray(List<byte> answers, byte number)
        {
            return IsNumberInArray(answers, number) != -1;
        }

        public bool AddMoreAnswers(byte userInputTypeAnswer, MultipleChoiceQuestions MCQuestions,List<byte> answers)
        {
            bool AddMore = true;
            do
            {
                Console.WriteLine("Question Answer : ");
                userInputTypeAnswer = Convert.ToByte(Console.ReadLine());
                if (!DetermineIsInArray(answers, userInputTypeAnswer))
                {  
                    answers.Add(userInputTypeAnswer);
                }
                Console.WriteLine("Do You Want To Add More Answers type 1-Yes,2-No");
                AddMore = Convert.ToBoolean(Console.ReadLine());
            } while (AddMore);
            return AddMore;
        }

  
        public override void AddQuestion(int lenght)
        {
            byte userInputTypeLevel = 0;
            byte userInputTypeAnswer = 0;

            for (int i = 0; i < lenght; i++)
            {
                MultipleChoiceQuestions MCQuestions = new MultipleChoiceQuestions();
                Console.WriteLine($"Choose The Level of the Question 1-{Qlevel.Easy} 2- {Qlevel.Medium} 3- {Qlevel.Hard}");
                userInputTypeLevel = Convert.ToByte(Console.ReadLine());
                MCQuestions.Qlevel = (Qlevel)userInputTypeLevel;

                Console.WriteLine("Enter The Question Please :");
                MCQuestions.QuestionHeader = Console.ReadLine();

                Console.WriteLine("Please Enter The Mark :");
                MCQuestions.Mark = Convert.ToByte(Console.ReadLine());

                for (int r = 0; r < 4; r++)
                {
                    Console.WriteLine($"Enter The Choose Number {r + 1} :");
                    MCQuestions.Choices.Add(Console.ReadLine());
                }
                AddMoreAnswers(userInputTypeAnswer, MCQuestions, MCQuestions.UserAnswer);

                //Console.WriteLine($"Answer ? Choose 1-{QTF.True} 2-{QTF.False}");
                //Questions.UserAnswer = Convert.ToByte(Console.ReadLine());
                //ChooseOneChoiceQuestion.Add(CHQuestions);
               MultipleChoiceQuestion.Add(MCQuestions);
            }
            Questions.CombineTwoList(MultipleChoiceQuestion);
        }
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{Choices[0]} \n 2-{Choices[1]} \n 3-{Choices[2]}\n 4-{Choices[3]}";
        }
        public override void ShowAllTFQuestions()
        {
            for (int j = 0; j < MultipleChoiceQuestion.Count(); j++)
            {
                Console.WriteLine($"Question{j + 1} : {MultipleChoiceQuestion[j].QuestionHeader} And The Mark is {MultipleChoiceQuestion[j].Mark}");
            }
        }
    }


}
