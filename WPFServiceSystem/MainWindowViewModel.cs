using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFServiceSystem
{
    public class MainWindowViewModel : BaseViewModel
    {
        public List<QNA> QNA { get; set; } = new List<QNA>();
        public List<Service> serviceList { get; set; }
        public Service Service { get; set; }
        public BaseViewModel ActiveView { get; set; }
        List<Question> questions = new List<Question>();
        public MainWindowViewModel()
        {
            serviceList = new List<Service>();
            GetServices(GetBranch());

            ServiceScreen();
        }
        public void GetQuestions()
        {
            OutResponse<List<Question>> res = new OutResponse<List<Question>>();
            using (HttpClient client = new HttpClient())
            {
                res = client.GetFromJsonAsync<OutResponse<List<Question>>>($"https://localhost:44391/api/Question?serviceID={Service.ServiceID}").Result;

                foreach (var item in res.ResData)
                {
                    Question question = new Question();
                    question.QuestionID = item.QuestionID;
                    question.QuestionString = item.QuestionString;
                    questions.Add(question);
                }
            }
            InitialisingQNA();
        }
        private void InitialisingQNA()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                QNA qna = new QNA(SaveAnswer)
                {
                    QuestionID = questions[i].QuestionID,
                    QuestionString = questions[i].QuestionString
                };
                QNA.Add(qna);
            }
            OnPropertyChanged(nameof(QNA));
            QuestionScreen();
        }
        private void SaveAnswer()
        {

        }
        void QuestionScreen()
        {
            ActiveView = new DisplayQuestionViewModel(QNA);
            OnPropertyChanged(nameof(ActiveView));
        }
        void ServiceScreen()
        {
            ActiveView = new ServiceWindowViewModel(serviceList);
            OnPropertyChanged(nameof(ActiveView));
        }
        private void GetServices(int branchID)
        {
            string BranchName = "";
            using (HttpClient client = new HttpClient())
            {
                var res = client.GetFromJsonAsync<OutResponse<List<ServicesDTO>>>($"https://localhost:44391/api/Service/{branchID}").Result;

                foreach (var item in res.ResData)
                {
                    Service = new Service(GetQuestions)
                    {
                        BranchID = branchID,
                        BranchName = item.BranchName,
                        ServiceID = item.ServiceID,
                        ServiceName = item.ServiceName
                    };
                    serviceList.Add(Service);
                    BranchName = item.BranchName;
                }
            }
            OnPropertyChanged(nameof(serviceList));
        }

        public int GetBranch()
        {
            int BranchID = 0;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/branch.txt";
            string val = "";
            if (File.Exists(path))
            {
                val = File.ReadAllText(path);
            }
            if (val != null || val != "")
            {
                string[] temp = val.Split('=');
                BranchID = int.Parse(temp[1]);
            }
            return BranchID;
        }
    }
}
