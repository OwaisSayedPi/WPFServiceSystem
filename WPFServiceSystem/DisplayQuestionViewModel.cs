using System;
using System.Collections.Generic;

namespace WPFServiceSystem
{
    public class DisplayQuestionViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public List<QNA> QNA { get; set; }
        public List<Question> Questions { get; }
        public DisplayQuestionViewModel(List<QNA> qna)
        {
            QNA = qna;
        }
    }
}