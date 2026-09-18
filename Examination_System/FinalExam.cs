using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void AddQuestion(Question q)
        {
           Questions?.Add(q);
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam Results:");
            for (int i = 0; i < Questions?.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}?");
                Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.ToString()}");
                Console.WriteLine($"Correct Answer {Questions[i].CorrectAnswer.ToString()}");
                Console.WriteLine();

            }
        }
    }
}
