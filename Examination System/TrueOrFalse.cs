namespace Examination_System
{
    class TrueOrFalse : Questions
    {
        public TrueOrFalse(Qtype qtype = Qtype.TrueOrFalse, Qlevel qlevel = Qlevel.Hard, double mark = 0, string questionHeader = " ", QTF answer = QTF.False) : base(qtype, qlevel, mark, questionHeader)
        {
            this.Qanswer = answer;
        }
        public QTF Qanswer { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} \n 1-{QTF.True} 2-{QTF.False}";
        }

        protected override void AddQuestionSpecifics()
        {

            Console.WriteLine($"Answer? Choose 1-{QTF.True}, 2-{QTF.False}");
            byte userInputAnswer = Convert.ToByte(Console.ReadLine());
            if (userInputAnswer < 1 || userInputAnswer > 2 )
            {
                throw new ArgumentException("Invalid Input,Please Enter 1 or 2");
            }
            Qanswer = (QTF)userInputAnswer;
        }
    }


}
