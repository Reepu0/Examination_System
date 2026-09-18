using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class Subject
    {
        public int SubjectId { get; set; } 
        public string SubjectName { get; set; }
        public Exam? SubjectExam { get; set; }

        public Subject(int subjectId ,string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public Exam CreateExam(int examtype, TimeSpan time, int numberofQuestions)
        {

            if (examtype == 1) 
                return new PracticalExam(time, numberofQuestions);
            else if (examtype == 2)
                return new FinalExam(time, numberofQuestions);
            else
                throw new Exception("No Exam type found");
        }
    }
}
