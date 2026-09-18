using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void AddQuestion(Question q)
        {
            while(q is TFQuestion)
            {
                Console.WriteLine("Sorry, Only MCQ Questions are allowed, try again.");
            }
            Questions?.Add(q);
        }

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam Results:");
            for (int i = 0; i < Questions?.Count; i++) 
            {
                Console.WriteLine($"Correct Answer {Questions[i].CorrectAnswer.ToString()}");
                Console.WriteLine();
            }
        }
    }
}
