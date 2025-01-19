using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {

        public abstract List<byte> ShowQuestionExam(List<Questions> questions);


        public abstract void ShowModelAnswer(double studentMarks, double totalMarks);


        public static enFinalOrPractical ChooseExam()
        {
            byte userChoice = 0;
            Console.WriteLine($"1-{enFinalOrPractical.Final}");
            Console.WriteLine($"2-{enFinalOrPractical.Practical}");
            userChoice = Convert.ToByte(Console.ReadLine());
            return (enFinalOrPractical)userChoice;
        }

        public List<Questions> GenerateRandomNumber(List<Questions> questions)
        {
           
            Random random = new Random();
            return questions.OrderBy(q => random.Next()).Take(questions.Count()).ToList();
        }


        public double CalculateTotalMarks(List<byte> userAnswer, List<Questions> randomizeQuestions)
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
                }
                else if (randomizeQuestions[i] is MultipleChoiceQuestions mcq)
                {
                    if (mcq.UserAnswer.Contains(userAnswer[i]))
                    {
                        sum += randomizeQuestions[i].Mark;
                    }
                }
            }
            return sum;
        }

        public double GetTotalMarkForEachQuestion(List<Questions> questions)
        {
            double totalMarksForAllQuestions = 0;
            foreach (Questions item in questions)
            {
                totalMarksForAllQuestions += item.Mark;
            }
            return totalMarksForAllQuestions;
        }
      



    }
}



