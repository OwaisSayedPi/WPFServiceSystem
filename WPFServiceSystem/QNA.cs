using System;
using System.Windows.Input;

namespace WPFServiceSystem
{
    public class QNA
    {
        public int QuestionID { get; set; }
        public string QuestionString { get; set; }
        public int AnswerID { get; set; }
        public string Answers { get; set; }
        public ICommand Save { get; set; }
        public QNA(Action action)
        {
            Save = new RelayCommand(action);
        }
    }
}