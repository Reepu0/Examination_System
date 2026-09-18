using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal abstract class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public decimal Mark {  get; set; }

        public Answer[] AnswerList = new Answer[2];
        public Answer CorrectAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        public Question(string header, string body, decimal mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
    }
}
