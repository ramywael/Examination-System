namespace Examination_System
{
    class ChooseOneChoice : Questions
    {
        private List<string> Choices { get; set; }
        public byte UserAnswer { get; set; }
        public ChooseOneChoice(Qtype qtype = Qtype.ChooseOneQuestion, Qlevel qlevel = Qlevel.Easy, double mark = 0, string questionHeader = " ", byte userAnswer = 1) : base(qtype, qlevel, mark, questionHeader)
        {
            Choices = new List<string>();
            this.UserAnswer = userAnswer;
        }

       
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{Choices[0]} \n 2-{Choices[1]} \n 3-{Choices[2]}\n 4-{Choices[3]}";
        }

        protected override void AddQuestionSpecifics()
        {
            base.AddChoices(Choices);
            Console.WriteLine("Question Answer? (Enter the number of the correct choice, e.g., 1, 2, 3, or 4):");
            byte userInputTypeAnswer = Convert.ToByte(Console.ReadLine());


            if (userInputTypeAnswer < 1 || userInputTypeAnswer > 4)
            {
                throw new ArgumentException("Invalid answer. Please choose a number between 1 and 4.");
            }
            UserAnswer = userInputTypeAnswer;
        }
    }


}
