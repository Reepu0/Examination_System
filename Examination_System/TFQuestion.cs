using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string header, string body, decimal mark) : base("True or False", body, mark)
        {
            AnswerList = new Answer[2];
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }
    }
}
