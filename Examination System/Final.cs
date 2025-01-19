namespace Examination_System
{
    class Final : Exam
    {
        List<byte> studentAnswerList;
        public Final()
        {

            studentAnswerList = new List<byte>();
        }

        public override void ShowModelAnswer(double studentResult, double totalMarks)
        {
            Console.WriteLine($"Your Score is :{studentResult}/{totalMarks}");
            if (studentResult >= (totalMarks * 0.5))
            {
                Console.WriteLine("Congratulation You are passed");
            }
            else
            {
                Console.WriteLine("Study Hard");
            }
        }

        public override List<byte> ShowQuestionExam(List<Questions> questions)
        {
            byte studentAnswer = 0;
            Console.WriteLine($"\t\t Final Exam {questions.Count()}");
            foreach (Questions item in questions)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"{item.ToString()}");
                        Console.Write("Your Answer :");
                        studentAnswer = Convert.ToByte(Console.ReadLine());
                        if (item is TrueOrFalse tf)
                        {
                            if (studentAnswer < 1 || studentAnswer > 2)
                            {
                                throw new ArgumentException("Invaild Input,Please Enter number (1 or 2)");
                            }
                            else
                                Console.WriteLine($"Correct Answer is :{tf.Qanswer}");
                        }
                        else if (item is ChooseOneChoice ch)
                        {
                            if (studentAnswer < 1 || studentAnswer > 4)
                            {
                                throw new ArgumentException("Invaild Input,Please Enter number between 1 and 4");
                            }
                            else
                                Console.WriteLine($"Correct Answer is : {ch.UserAnswer}");
                        }
                        else if (item is MultipleChoiceQuestions mcq)
                        {
                            if (studentAnswer < 1 || studentAnswer > 4)
                            {
                                throw new ArgumentException("Invaild Input,Please Enter number between 1 and 4");
                            }
                            else
                            {
                                Console.Write($"Correct Answer are(one of them is correct : ");
                                foreach (byte answer in mcq.UserAnswer)
                                {
                                    Console.Write($" {answer} ");
                                }
                                Console.WriteLine();
                            }
                        }
                        studentAnswerList.Add(studentAnswer);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invaild Input,Please Enter A Valid Number");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Input is too large or too small. Please enter a valid number.");
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
            return studentAnswerList;
        }
    }
}



