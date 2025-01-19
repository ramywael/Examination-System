namespace Examination_System
{
    class MultipleChoiceQuestions : Questions
    {
        private List<string> Choices { get; set; }
        public List<byte> UserAnswer { get; set; }
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

        public bool AddMoreAnswers(MultipleChoiceQuestions MCQuestions, List<byte> answers)
        {
            while (true) 
            {
                try
                {
                    Console.WriteLine("Question Answer (Enter the number of the correct choice, e.g., 1, 2, 3, or 4):");
                    byte userInputTypeAnswer = Convert.ToByte(Console.ReadLine());

                    if (userInputTypeAnswer < 1 || userInputTypeAnswer > 4)
                    {
                        throw new ArgumentException("Invalid answer. Please choose a number between 1 and 4.");
                    }

                    if (!DetermineIsInArray(answers, userInputTypeAnswer))
                    {
                        answers.Add(userInputTypeAnswer);
                    }

                    Console.WriteLine("Do You Want To Add More Answers? (1-Yes, 2-No)");
                    byte addMoreChoice = Convert.ToByte(Console.ReadLine());

                    if (addMoreChoice < 1 || addMoreChoice > 2)
                    {
                        throw new ArgumentException("Invalid choice. Please choose 1 for Yes or 2 for No.");
                    }

                    if (addMoreChoice == 2)
                    {
                        return false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
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
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{Choices[0]} \n 2-{Choices[1]} \n 3-{Choices[2]}\n 4-{Choices[3]}";
        }

        protected override void AddQuestionSpecifics()
        {
             base.AddChoices(Choices);
            AddMoreAnswers(this, UserAnswer);
        }
    }


}
