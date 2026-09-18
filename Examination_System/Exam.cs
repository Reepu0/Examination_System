using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal abstract class Exam
    {
        public List<Question>? Questions { get; private set; }
        public TimeSpan TimeOfExam { get; private set; }
        public int NumberOfQuestions { get; private set; }
        public Exam(TimeSpan timeOfExam, int numberOfQuestions)
        {
            Questions = new List<Question>(NumberOfQuestions);
        }
        public abstract void AddQuestion(Question q);
        public abstract void ShowExam();
    }
}
