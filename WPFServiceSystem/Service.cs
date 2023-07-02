using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFServiceSystem
{
    public class Service
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int CounterID { get; set; }
        public List<Question> Question { get; set; }
        List<Answer> Answers = new List<Answer>();

        public OutResponse<List<Question>> question = new OutResponse<List<Question>>();

        public OutResponse<string> response = new OutResponse<string>();
        public ICommand OnServiceSelect { get; set; }
        public Service(Action action)
        {
            OnServiceSelect = new RelayCommand(action);
        }

    }
}
