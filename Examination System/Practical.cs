namespace Examination_System
{
    class Practical : Exam
    {
        List<byte> userAnswer;
        public Practical()
        {
            userAnswer = new List<byte>();
        }

        public void ShowCorrectList(List<Questions> questions)
        {
            Console.WriteLine("************************************ Model Answer*********************************************");
            for (int i = 0; i < questions.Count(); i++)
            {
                Console.WriteLine("\t\t\t\t");
                if (questions[i] is TrueOrFalse tf)
                {
                    Console.WriteLine($"{i + 1}.{tf.Qanswer}");
                }
                else if (questions[i] is ChooseOneChoice ch)
                {
                    Console.WriteLine($"{i + 1}.{ch.UserAnswer}");
                }
                else if (questions[i] is MultipleChoiceQuestions mcq)
                {
                    Console.Write($"{i + 1}.");
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
        }

        public override void ShowModelAnswer(double studentMarks, double totalMarks)
        {
            if (studentMarks >= (totalMarks * 0.5))
            {
                Console.WriteLine($"-------------------------You have passed the exam Congratulations Your grade is {studentMarks} / {totalMarks}----------------------------");
            }
            else
            {
                Console.WriteLine($"-------------------------You have Failed the exam Sorry Your grade is {studentMarks} / {totalMarks}----------------------------");
            }
        }


        public override List<byte> ShowQuestionExam(List<Questions> questions)
        {
            Console.WriteLine($"\t\t{enFinalOrPractical.Practical} - {questions.Count()}");

            foreach (Questions item in questions)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine(item.ToString());
                        Console.Write("Your Answer: ");
                        byte answer = Convert.ToByte(Console.ReadLine());
                        if (item is TrueOrFalse && (answer < 1 || answer > 2))
                        {
                            throw new ArgumentException("Invalid choice. Please enter 1 for True or 2 for False.");
                        }
                        else if ((item is ChooseOneChoice || item is MultipleChoiceQuestions) && (answer < 1 || answer > 4))
                        {
                            throw new ArgumentException("Invalid choice. Please enter a number between 1 and 4.");
                        }

                        userAnswer.Add(answer);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Input is too large or too small. Please enter a number between 1 and 4.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }

            ShowCorrectList(questions);
            return userAnswer;
        }

    }
}



