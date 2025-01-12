using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    enum enPassOrFail
    {
        Pass,
        Fail,
    }

    enum enFinalOrPractical
    {
        Final = 1,
        Practical = 2,
    }
    internal abstract class Exam
    {
        public abstract void ShowModelAnswer(List<Questions> questions);

        public abstract List<byte> ShowQuestionExam(List<Questions> questions);

        public abstract double CalculateTotalMarks(List<byte> userAnswer, List<Questions> randomizeQuestions);


        public static enFinalOrPractical ChooseExam()
        {
            byte userChoice = 0;
            Console.WriteLine($"1-{enFinalOrPractical.Final}");
            Console.WriteLine($"2-{enFinalOrPractical.Practical}");
            userChoice = Convert.ToByte(Console.ReadLine());
            return (enFinalOrPractical)userChoice;
        }
    }


    class Practical : Exam
    {
        List<byte> userAnswer;
        //const byte numberOFQuestions= 2;

        public Practical()
        {
            userAnswer = new List<byte>();
        }

        public override double CalculateTotalMarks(List<byte> userAnswer, List<Questions> randomizeQuestions)
        {
            double sum = 0;
            for (int i = 0; i < userAnswer.Count(); i++)
            {
                if (randomizeQuestions[i] is TrueOrFalse tf)
                {
                    if ((byte)tf.Qanswer == userAnswer[i])
                    {
                        sum += randomizeQuestions[i].Mark;
                    }
                }
                else if (randomizeQuestions[i] is ChooseOneChoice ch)
                {
                    if (ch.UserAnswer == userAnswer[i])
                    {
                        sum += randomizeQuestions[i].Mark;
                    }
                }else if (randomizeQuestions[i] is MultipleChoiceQuestions mcq)
                {
                    if (mcq.UserAnswer.Contains(userAnswer[i]))
                    {
                        sum += randomizeQuestions[i].Mark;
                    }
                }
            }
            return sum;
        }
        public enPassOrFail DeterminePassOrFailed(double result, List<Questions> randomizeQuestions)
        {
            double totalMarks = 0;
            foreach (Questions item in randomizeQuestions)
            {
                totalMarks += item.Mark;
            }
            if (result >= (totalMarks * 0.5))
            {
                Console.WriteLine($"-------------------------You have passed the exam Congratulations Your grade is {result} / {totalMarks}----------------------------");
                return enPassOrFail.Pass;
            }
            Console.WriteLine($"-------------------------You have Failed the exam Sorry Your grade is {result} / {totalMarks}----------------------------");
            return enPassOrFail.Fail;
        }


        public override void ShowModelAnswer(List<Questions> questions)
        {
            Console.WriteLine("************************************ Model Answer*********************************************");
            for(int i = 0; i < questions.Count(); i++)
            {
                Console.WriteLine("\t\t\t\t");
                if (questions[i] is TrueOrFalse tf)
                {
                    Console.WriteLine($"{i+1}.{tf.Qanswer}");
                }
                else if (questions[i] is ChooseOneChoice ch)
                {
                    Console.WriteLine($"{i+1}.{ch.UserAnswer}");
                }
                else if (questions[i] is MultipleChoiceQuestions mcq)
                {
                    Console.Write($"{i+1}.");
                    for (int j = 0; j < mcq.UserAnswer.Count(); j++)
                    {
                        Console.Write($"{mcq.UserAnswer[j]} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Unavialibale type of Questions");
                }
            }

            //foreach (Questions question in questions)
            //{

            //    if (question is TrueOrFalse tf)
            //    {
            //        Console.WriteLine($"\t\t\t\t{tf.Qanswer}");
            //    }
            //    else if (question is ChooseOneChoice ch)
            //    {
            //        Console.WriteLine($"\t\t\t\t{ch.UserAnswer}");
            //    }
            //    else if (question is MultipleChoiceQuestions mcq)
            //    {
            //        for (int i = 0; i < mcq.UserAnswer.Count(); i++)
            //        {
            //            Console.WriteLine("\t\t\t\t");
            //            Console.Write($"{mcq.UserAnswer[i]}-");
            //        }
            //        Console.WriteLine();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Unavialibale type of Questions");
            //    }
            //}


        }

        public List<Questions> GenerateRandomNumber(List<Questions> questions, int numberOfQuestions)
        {
            //Random random = new Random();
            //int randNumber = random.Next(0, numberOFQuestions);
            //return randNumber;
            Random random = new Random();
            return questions.OrderBy(q => random.Next()).Take(numberOfQuestions).ToList();
        }

        public override List<byte> ShowQuestionExam(List<Questions> questions)
        {
            Console.WriteLine($"\t\t{enFinalOrPractical.Practical} - {questions.Count()}");
            Console.WriteLine($"The Number of Questions is {questions.Count()} ");
            //  List<Questions> selectedRandomQuestions = GenerateRandomNumber(questions,numberOFQuestions);
            foreach (Questions item in questions)
            {
                Console.WriteLine(item.ToString());
                try
                {
                    byte answer = Convert.ToByte(Console.ReadLine());
                    if (answer < 1 || answer > 4) // Adjust as per valid answer range
                    {
                        throw new ArgumentException("Invalid choice. Please choose a valid option.");
                    }
                    userAnswer.Add(answer);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            ShowModelAnswer(questions);
            return userAnswer;
        }
    }

}



