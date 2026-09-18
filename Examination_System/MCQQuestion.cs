using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, decimal mark) : base("MCQ Question", body, mark)
        {
            AnswerList = new Answer[4];
        }
    }
}
