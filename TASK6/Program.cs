using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace TASK6
{
    public enum Level { Easy = 1, Medium = 2, Hard = 3 }
    public abstract class Question
    {
        public Question(string header, int marks, Level level)
        {
            Header = header;
            Marks = marks;
            this.level = level;
        }



        public string Header { get; set; }
        public int Marks { get; set; }
        public Level level { get; set; }
        public abstract void Display();
        public abstract bool CheckAnswer(string choice);


    }
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(bool correctAnswer, int marks, string header, Level level) : base(header, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }
        public override void Display()
        {
            Console.WriteLine($"[{level}] {Header} ({Marks} Marks)");
            Console.WriteLine("1. True ");
            Console.WriteLine("2.False");
        }
        public override bool CheckAnswer(string choice)
        {

            bool Choice = choice == "1";
            return Choice == CorrectAnswer;
        }

    }
    public class ChoseOneQuestion : Question
    {
        public ChoseOneQuestion(string header, int marks, Level level, string[] choices, int correctChoice) : base(header, marks, level)
        {
            Choices = choices;
            CorrectChoice = correctChoice;
        }

        public string[] Choices { get; set; } = new string[4];
        public int CorrectChoice { get; set; }

        public override void Display()
        {
            Console.WriteLine($"[{level}] {Header} ({Marks} Marks)");
            for (int i = 0; i < Choices.Length; i++)
                Console.WriteLine($"{i + 1}. {Choices[i]}");
        }
        public override bool CheckAnswer(string input)
        {
            return Convert.ToInt32(input) == CorrectChoice;
        }

    }
    public class MultipleChoiceQuestion : Question
    {
        public string[] Choices { get; set; }
        public string CorrectAnswers { get; set; }
        public MultipleChoiceQuestion(string header, int marks, Level level, string[] choices, string correct) : base(header, marks, level)
        {
            Choices = choices;
            CorrectAnswers = correct;
        }

        public override void Display()
        {
            Console.WriteLine($"[Multiple Choice] {Header} ({Marks} Marks)");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }
        public override bool CheckAnswer(string choice) => choice == CorrectAnswers;



        internal class Program
        {

            static void Main(string[] args)
            {
                List<Question> QBank = new List<Question>();

                while (true)
                {

                    Console.WriteLine("1. Doctor Mode");
                    Console.WriteLine("2. Student Mode");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choice: ");
                    int mainOption = Convert.ToInt32(Console.ReadLine());

                    if (mainOption == 1)
                    {
                        Console.Write("Enter number of questions: ");
                        int count = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine("Type: 1.True or False , 2.Choose One, 3.Multiple Choice");
                            int type = Convert.ToInt32(Console.ReadLine());


                            Console.Write("Level (1.Easy, 2.Medium, 3.Hard): ");
                            Level level = (Level)Convert.ToInt32(Console.ReadLine());

                            Console.Write("Header: ");
                            string header = Console.ReadLine();

                            Console.Write("Marks: ");
                            int marks = Convert.ToInt32(Console.ReadLine());

                            if (type == 1)
                            {
                                Console.Write("Correct (1 : True, 2 : False): ");
                                bool correctanswer = Console.ReadLine() == "1";
                                QBank.Add(new TrueFalseQuestion(correctanswer, marks, header, level));
                            }
                            else if (type == 2)
                            {
                                string[] choices = new string[4];
                                for (int o = 0; o < 4; o++) { Console.Write($"Choice {o + 1}: "); choices[o] = Console.ReadLine(); }
                                Console.Write("Correct Choice Number: ");
                                int correctanswer = Convert.ToInt32(Console.ReadLine());
                                QBank.Add(new ChoseOneQuestion(header, marks, level, choices, correctanswer));
                            }
                            else if (type == 3)
                            {
                                string[] choices = new string[4];
                                for (int p = 0; p < 4; p++) { Console.Write($"Choice {p + 1}: "); choices[p] = Console.ReadLine(); }
                                Console.Write("Correct Answers : ");
                                string correctanswer = Console.ReadLine();
                                QBank.Add(new MultipleChoiceQuestion(header, marks, level, choices, correctanswer));
                            }
                        }
                    }
                    else if (mainOption == 2)  
                    {
                        
                        Console.Write("Exam Level (1:Easy, 2:Med, 3:Hard): ");
                        Level searchLvl = (Level)Convert.ToInt32(Console.ReadLine());

                        int score = 0;
                        foreach (Question q in QBank)
                        {
                            if (q.level == searchLvl)
                            {
                                q.Display();
                                Console.Write("Your Answer: ");
                                if (q.CheckAnswer(Console.ReadLine())) score += q.Marks;
                            }
                        }
                        Console.WriteLine("Score: " + score);
                    }
                    else break;
                    //https://docs.google.com/document/d/1MEIccIte27EVYn2c1Y8p2UY4EML7VIB0rBSApQx2jbg/edit?usp=sharing
                    //search task
                    //search task
                    //search task
                    //search task
                    //search task
                    //search task
                    //search task
                }


            }
            }
        }
    }

