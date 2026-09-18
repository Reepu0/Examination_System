using System.Diagnostics;
using System.Numerics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject? Sub1 = new Subject(1,"OOP");

            Console.WriteLine("Enter The type of exam (1 for Practical, 2 for Final)");
            int.TryParse(Console.ReadLine(), out int ExamType);
            
            Console.WriteLine("Please enter the time for the exam (from 30 to 180 minutes)");
            
            if(!int.TryParse(Console.ReadLine(), out int Minutes)|| Minutes <30 || Minutes >180)
            {
                 throw new ArgumentOutOfRangeException(nameof(Minutes), "Invalid input");
            }
            TimeSpan ExamTime = TimeSpan.FromMinutes(Minutes);
            Console.WriteLine("Please enter the number of questions ");
            int.TryParse(Console.ReadLine(), out int QuestionNum);
            
            Exam OOP = Sub1.CreateExam(ExamType,ExamTime, QuestionNum);

            Console.Clear();

            if (ExamType == 1)
            {
                for (int i = 0; i < QuestionNum; i++)
                {
                    Console.WriteLine("Please enter the Question body: ");
                    string? Body = Console.ReadLine();
                    Console.WriteLine("Please enter the Question mark");
                    int.TryParse(Console.ReadLine(), out int Mark);
                    
                    
                    Question Q = new MCQQuestion("MCQ Question ",Body!,Mark);
                    
                    
                    for(int j = 0; j< Q.AnswerList.Length; j++)
                    {
                        Console.WriteLine($"Please enter choice number {j+1}: ");
                        Q.AnswerList[j] = new Answer(j + 1, Console.ReadLine()!);
                    }


                    Console.WriteLine("Please enter the ID of the correct answer (1 to 4)");
                    int.TryParse(Console.ReadLine(), out int ans);
                    Q.CorrectAnswer = Q.AnswerList[ans-1];

                    OOP.AddQuestion(Q);
                }
            } else if(ExamType == 2)
            {
                for (int i = 0; i < QuestionNum; i++)
                {
                    Console.WriteLine("Please enter the Question body: ");
                    string? Body = Console.ReadLine();
                    Console.WriteLine("Please enter the Question mark");
                    int.TryParse(Console.ReadLine(), out int Mark);
                    Console.WriteLine("Choose Question Type: 1 for MCQ, 2 for True/False");
                    int.TryParse(Console.ReadLine(), out int Type);

                    Question Q;
                    if (Type == 1)
                    {
                        Q = new MCQQuestion("MCQ Question ", Body!, Mark);
                    }
                    else
                    {
                        Q = new TFQuestion("T/F Question ", Body!, Mark);
                    }

                    if (Q is MCQQuestion)
                    {
                        for (int j = 0; j < Q.AnswerList.Length; j++)
                        {
                            Console.WriteLine($"Please enter choice number {j + 1}: ");
                            Q.AnswerList[j] = new Answer(j + 1, Console.ReadLine()!);
                        }
                    }

                    if (Q is MCQQuestion)
                    {
                        Console.WriteLine("Please enter the ID of the correct answer (1 to 4)");
                        int.TryParse(Console.ReadLine(), out int ans);
                        Q.CorrectAnswer = Q.AnswerList[ans - 1];
                    }
                    else
                    {
                        Console.WriteLine("Please enter the ID of the correct answer (1 for True or 2 for False)");
                        int.TryParse(Console.ReadLine(), out int ans);
                        Q.CorrectAnswer = Q.AnswerList[ans - 1];
                    }
                    OOP.AddQuestion(Q);
                }

            }
            Console.WriteLine("Do you want to start the exam? (Y | N)");
            char.TryParse(Console.ReadLine()!.ToUpper(), out char start);
            
            if(start == 'Y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                decimal YourGrade = 0;
                decimal TotalGrade = 0;
                Console.Clear();
                Console.WriteLine(OOP.GetType().Name);
                for(int i=0; i < QuestionNum; i++)
                {
                    Console.WriteLine($"Question {i+1}: {OOP.Questions![i].Body}");
                    Console.WriteLine($"{OOP.Questions[i].GetType().Name}:     Mark {OOP.Questions[i].Mark}");
                    Console.WriteLine($"{string.Join("\n", OOP.Questions[i].AnswerList)}");
                    Console.WriteLine("Enter your answer ID");
                    int.TryParse(Console.ReadLine()!, out int ans);
                    OOP.Questions[i].UserAnswer = OOP.Questions[i].AnswerList[ans-1];
                    for(int j =0; j < QuestionNum; j++)
                    {
                        if (OOP.Questions[i].UserAnswer == OOP.Questions[j].CorrectAnswer)
                        {
                            YourGrade += OOP.Questions[i].Mark;
                        }
                    }
                    TotalGrade += OOP.Questions[i].Mark;
                }

                sw.Stop();

                OOP.ShowExam();
                Console.WriteLine($"Your Grade is {YourGrade} from {TotalGrade}");
                Console.WriteLine($"Time = {sw:hh\\:mm\\:ss}");
                Console.WriteLine("Thank you");





            }
            else if(start == 'N')
            {
                Console.WriteLine("Closing the program.");
                return;
            }
            else
            {
                throw new Exception("Not valid argument");
            }
        }
    }
}
